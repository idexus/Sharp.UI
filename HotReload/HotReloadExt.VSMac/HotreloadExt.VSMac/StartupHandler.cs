using System.IO;
using System.Linq;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Core;
using MonoDevelop.Utilities;
using System;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Projects;
using System.IO.Pipes;
using MonoDevelop.Core.Assemblies;
using MonoDevelop.Projects.MSBuild;
using EnvDTE;
using Gtk;
using Microsoft.VisualStudio.OLE.Interop;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using MonoDevelop.Ide.TypeSystem;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Text;
using Pango;

namespace HotReload
{
    public class HotReloadRequest
    {
        public string[] TypeNames { get; set; }
    }

    class HotReloadData
    {
        public string[] TypeNames { get; set; }
        public byte[] AssemblyData { get; set; }
        public byte[] PdbData { get; set; }
    }

    public class StartupHandler : CommandHandler
	{
        static int asseblyVersion = 0;

        protected override void Run ()
		{
            IdeServices.ProjectOperations.BeforeStartProject += ProjectOperations_BeforeStartProject;
        }

        DotNetProject ActiveProject
            => (IdeApp.ProjectOperations.CurrentSelectedSolution?.StartupItem
                ?? IdeApp.ProjectOperations.CurrentSelectedBuildTarget)
                as DotNetProject;

        DotNetProject _hotReloadedProject = null;
        DotNetProject HotReloadedProject
        {
            get => _hotReloadedProject;
            set
            {
                if (_hotReloadedProject != null) _hotReloadedProject.FileChangedInProject -= ActiveProject_FileChangedInProject;
                _hotReloadedProject = value;
            }
        }

        void StartHotReloadSession()
        {
            if (ActiveProject != null && HotReloadedProject == null)
            {
                HotReloadedProject = ActiveProject;                
                HotReloadedProject.FileChangedInProject += ActiveProject_FileChangedInProject;  
            }
        }

        void ProjectOperations_BeforeStartProject(object sender, EventArgs e)
        {
            StartHotReloadSession();
        }

        string GetClassNameWithNamespace(ClassDeclarationSyntax syntax)
        {
            var namespaceString =
                        (syntax.Parent as FileScopedNamespaceDeclarationSyntax)?.Name.ToString()
                        ?? (syntax.Parent as NamespaceDeclarationSyntax)?.Name.ToString();

            namespaceString = string.IsNullOrEmpty(namespaceString) ? "" : $"{namespaceString}.";

            return $"{namespaceString}{syntax.Identifier.Text}";
        }

        IEnumerable<string> GetClassNames(SyntaxTree syntaxTree)
        {
            return syntaxTree
                .GetRoot()
                .DescendantNodes().OfType<ClassDeclarationSyntax>()
                .Where(e => e.Parent is NamespaceDeclarationSyntax || e.Parent is FileScopedNamespaceDeclarationSyntax)
                .Select(e => GetClassNameWithNamespace(e));                
        }

        List<string> GetClassNamesForChangedSyntaxTrees(List<SyntaxTree> changedFilesSyntaxTreeList)
        {
            var classList = new List<string>();

            foreach (var syntaxTree in changedFilesSyntaxTreeList)
                classList.AddRange(GetClassNames(syntaxTree));

            return classList.Distinct().ToList();
        }

        string GetFrameworkShortName()
        {
            dynamic dynamic_target = IdeApp.Workspace.ActiveExecutionTarget;
            return dynamic_target.FrameworkShortName; // e.g. "net7.0-maccatalyst"
        }

        string GetDllOutputhPath(string activeProjectName)
        {
            var basePath = ActiveProject.MSBuildProject.BaseDirectory;

            var configuration = IdeApp.Workspace.ActiveConfiguration;
            var configurationName = configuration.ToString();

            dynamic dynamic_target = IdeApp.Workspace.ActiveExecutionTarget;
            string frameworkShortName = dynamic_target.FrameworkShortName; // e.g. "net7.0-maccatalyst"
            string runtimeIdentifier = dynamic_target.RuntimeIdentifier; // "maccatalyst-x64"

            var runtimeTail = !string.IsNullOrEmpty(runtimeIdentifier) ? $"/{runtimeIdentifier}" : "";

            return $"{basePath}/bin/{configurationName}/{frameworkShortName}{runtimeTail}/{activeProjectName}.dll";
        }

        async Task<(Compilation compilation, IEnumerable<string> changedClassNames)> Compile(HotReloadRequest hotReloadRequest, string activeProjectName, string dllOutputhPath, string frameworkShortName, IEnumerable<string> changedFilePaths)
        {
            // ------ Microsoft.CodeAnalysis projects ------

            var typeService = await Runtime.GetService<TypeSystemService>();
            var solution = typeService.Workspace.CurrentSolution;
            var projects = solution.Projects;
            var activeProject = solution.Projects.FirstOrDefault(e => e.AssemblyName.Equals(activeProjectName) && e.Name.Contains(frameworkShortName));
            var referencedProjects = activeProject.ProjectReferences?.Select(e => solution.Projects.FirstOrDefault(x => x.Id == e.ProjectId));
            var generators = activeProject.AnalyzerReferences.SelectMany(e => e.GetGeneratorsForAllLanguages());
            var includedProjects = referencedProjects?.ToList() ?? new List<Microsoft.CodeAnalysis.Project>();
            includedProjects.Add(activeProject);

            var compilation = await activeProject?.GetCompilationAsync();

            // --------- syntax tree ----------

            List<SyntaxTree> syntaxTreeList = new List<SyntaxTree>();
            List<SyntaxTree> changedFilesSyntaxTreeList = new List<SyntaxTree>();

            // assembly name
            var versionSyntaxTree = CSharpSyntaxTree.ParseText($"[assembly: System.Reflection.AssemblyVersionAttribute(\"1.0.{asseblyVersion}\")]");

            // global usings
            var usings = compilation.SyntaxTrees
                    .SelectMany(e => e
                        .GetRoot()
                        .DescendantNodes().OfType<UsingDirectiveSyntax>()
                        .Where(e => e.GlobalKeyword.ValueText == "global"))
                    .Select(e => e.ToString())
                    .Distinct()
                    .ToList();
            var usingsText = string.Join("\n", usings);
            var usingsSyntaxTree = CSharpSyntaxTree.ParseText(usingsText);
            syntaxTreeList.Add(usingsSyntaxTree);

            // collect changed and requested file paths
            var changedAndRequestedFilePaths = compilation.SyntaxTrees
                .Where(e =>
                    !e.FilePath.EndsWith(".g.cs") &&
                    (changedFilePaths.Contains(e.FilePath) ||
                    GetClassNames(e).Intersect(hotReloadRequest.TypeNames).Count() > 0))
                .Select(e => e.FilePath)
                .ToList();

            // go through changed and requested files
            foreach (var filePath in changedAndRequestedFilePaths)
            {
                var codeText = await File.ReadAllTextAsync(filePath);
                var syntaxTree = CSharpSyntaxTree.ParseText(codeText);
                syntaxTreeList.Add(syntaxTree);
                changedFilesSyntaxTreeList.Add(syntaxTree);
            }

            var changedClassNames = GetClassNamesForChangedSyntaxTrees(changedFilesSyntaxTreeList);

            // partial classes
            var partialSyntaxTrees = compilation.SyntaxTrees
                    .Where(e =>
                        !e.FilePath.EndsWith(".g.cs") &&
                        GetClassNames(e).Intersect(changedClassNames).Count() > 0 &&
                        !changedAndRequestedFilePaths.Contains(e.FilePath));
            syntaxTreeList.AddRange(partialSyntaxTrees);

            // --------- metadata reference ---------

            List<MetadataReference> metadataReferences = new List<MetadataReference>();
            metadataReferences.AddRange(includedProjects.Select(e => MetadataReference.CreateFromFile(dllOutputhPath)));
            metadataReferences.AddRange(compilation.References);

            // --------- new compilation ------------

            var outputAssemblyName = $"{activeProjectName}-{asseblyVersion}";

            CSharpCompilation newCompilation =
                CSharpCompilation.Create(outputAssemblyName, syntaxTreeList, metadataReferences,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var generatorDriver = CSharpGeneratorDriver.Create(generators);
            generatorDriver.RunGeneratorsAndUpdateCompilation(newCompilation, out var newCompilationWithGenetators, out var diagnostics);

            return (newCompilationWithGenetators, changedClassNames);
        }

        async Task CompileAndEmitChanges(string activeProjectName, IEnumerable<string> changedFilePaths)
        {
            try
            {
                asseblyVersion++;

                var dllOutputhPath = GetDllOutputhPath(activeProjectName);
                var frameworkShortName = GetFrameworkShortName();

#pragma warning disable CA1416
                using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", activeProjectName, PipeDirection.InOut))
                {
                    // pipe connection
                    await pipeClient.ConnectAsync();
#pragma warning restore CA1416

                    // ------- reequest types ---------

                    var streamReader = new StreamReader(pipeClient);
                    var jsonData = await streamReader.ReadLineAsync();
                    var hotReloadRequest = JsonSerializer.Deserialize<HotReloadRequest>(jsonData);

                    // ------- compilation ---------

                    var compilationData = await Compile(hotReloadRequest, activeProjectName, dllOutputhPath, frameworkShortName, changedFilePaths);

                    // ------- send data assembly ---------

                    var streamWriter = new StreamWriter(pipeClient);
                    streamWriter.AutoFlush = true;

                    using (var dllStream = new MemoryStream())
                    using (var pdbStream = new MemoryStream())
                    {
                        var emitResult = compilationData.compilation.Emit(dllStream, pdbStream);
                        if (emitResult.Success)
                        {
                            var hotReloadData = new HotReloadData
                            {
                                TypeNames = compilationData.changedClassNames.ToArray(),
                                AssemblyData = dllStream.GetBuffer(),
                                PdbData = pdbStream.GetBuffer()
                            };

                            var json = JsonSerializer.Serialize(hotReloadData);

                            // send file location
                            await streamWriter.WriteLineAsync(json);
                        }
                    }
                }
            }
#pragma warning disable CS0168
            catch (Exception ex)
            {

            }
#pragma warning restore CS0168
        }

        static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        async void ActiveProject_FileChangedInProject(object sender, ProjectFileEventArgs args)
        {
            if (IdeServices.ProjectOperations.CurrentRunOperation.IsCompleted) HotReloadedProject = null;

            await semaphore.WaitAsync();

            var configuration = IdeApp.Workspace.ActiveConfiguration;
            var dllName = ActiveProject.GetOutputFileName(configuration).FileNameWithoutExtension;

            var changedFilePaths = args
                .Where(e => !e.ProjectFile.FilePath.FullPath.ToString().Contains(".g.cs"))
                .Select(e => e.ProjectFile.FilePath.FullPath.ToString());

            await CompileAndEmitChanges(dllName, changedFilePaths);

            semaphore.Release();
        }
	}
}
