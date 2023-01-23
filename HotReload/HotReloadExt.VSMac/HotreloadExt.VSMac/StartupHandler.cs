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
using Microsoft.CodeAnalysis.CSharp;
using System.IO.Pipes;
using MonoDevelop.Core.Assemblies;
using MonoDevelop.Projects.MSBuild;
using EnvDTE;
using Gtk;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace HotReload
{
    public class HotReloadData
    {
        public string DllFileName { get; set; }
        public string[] TypeNames { get; set; }
    }

    public class StartupHandler : CommandHandler
	{
        static DateTime beginTime;

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
                beginTime = DateTime.Now;
                HotReloadedProject = ActiveProject;                
                HotReloadedProject.FileChangedInProject += ActiveProject_FileChangedInProject;  
            }
        }

        void ProjectOperations_BeforeStartProject(object sender, EventArgs e)
        {
            StartHotReloadSession();
        }

        async Task<IEnumerable<string>> GetClassNames(string fileName)
        {
            var data = await File.ReadAllTextAsync(fileName);
            var nodes = CSharpSyntaxTree.ParseText(data).GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>();

            return nodes
                .Where(e => e.Parent is NamespaceDeclarationSyntax || e.Parent is FileScopedNamespaceDeclarationSyntax)
                .Select(e =>
                {
                    var namespaceString =
                        (e.Parent as FileScopedNamespaceDeclarationSyntax)?.Name.ToString()
                        ?? (e.Parent as NamespaceDeclarationSyntax)?.Name.ToString();

                    namespaceString = string.IsNullOrEmpty(namespaceString) ? "" : $"{namespaceString}.";

                    return $"{namespaceString}{e.Identifier.Text}";

                });
        }

        async Task<HotReloadData> AnalyzeFiles(IEnumerable<string> fileNames)
        {
            var classList = new List<string>();

            foreach(var fileName in fileNames)
                classList.AddRange(await GetClassNames(fileName));

            return new HotReloadData { TypeNames = classList.ToArray() };         
        }

        const double timeSpanBetweenCompilations = 2.0;
        static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        async void ActiveProject_FileChangedInProject(object sender, ProjectFileEventArgs args)
        {
            if (IdeServices.ProjectOperations.CurrentRunOperation.IsCompleted) HotReloadedProject = null;

            var lapsedTime = DateTime.Now.Subtract(beginTime).TotalSeconds;
            if (HotReloadedProject is null || lapsedTime < timeSpanBetweenCompilations) return;

            await semaphore.WaitAsync();

            beginTime = DateTime.Now;

            var basePath = ActiveProject.MSBuildProject.BaseDirectory;

            var configuration = IdeApp.Workspace.ActiveConfiguration;
            var configurationName = configuration.ToString();

            //var config = configuration.GetConfiguration(ActiveProject);

            dynamic dynamic_target = IdeApp.Workspace.ActiveExecutionTarget;
            string frameworkShortName = dynamic_target.FrameworkShortName; // e.g. "net7.0-maccatalyst"
            string runtimeIdentifier = dynamic_target.RuntimeIdentifier; // "maccatalyst-x64"

            var runtimeTail = !string.IsNullOrEmpty(runtimeIdentifier) ? $"/{runtimeIdentifier}" : "";

            var dllParentPath = $"{basePath}/bin/{configurationName}/{frameworkShortName}{runtimeTail}";
            var dllName = ActiveProject.GetOutputFileName(configuration).FileNameWithoutExtension;

            var changedFilePaths = args
                .Where(e => !e.ProjectFile.FilePath.FullPath.ToString().Contains(".g.cs"))
                .Select(e => e.ProjectFile.FilePath.FullPath.ToString());

            if (changedFilePaths.Any())
            {
                try
                {
                    var hotReloadData = await AnalyzeFiles(changedFilePaths);

#pragma warning disable

                    System.Diagnostics.Process process = new System.Diagnostics.Process
                    {
                        StartInfo =
                        {
                            FileName = "dotnet",
                            WorkingDirectory = basePath,
                            Arguments = $"msbuild -property:TargetFramework={frameworkShortName} -property:Configuration={configurationName} -t:CoreBuild"
                        }
                    };

                    // build
                    process.Start();
                    await process.WaitForExitAsync();

                    using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "sharpuipipe", PipeDirection.Out))
                    {
                        // pipe connection
                        await pipeClient.ConnectAsync();
                        var streamWriter = new StreamWriter(pipeClient);
                        streamWriter.AutoFlush = true;
#pragma warning restore

                        // base paths
                        var hotReloadPath = $"{dllParentPath}/HotReload";

                        // remove/create directory
                        if (Directory.Exists(hotReloadPath)) Directory.Delete(hotReloadPath, true);
                        Directory.CreateDirectory(hotReloadPath);

                        // dll's
                        var baseDllPath = $"{dllParentPath}/{dllName}";
                        var hotReloadDllPath = $"{hotReloadPath}/{dllName}-{Guid.NewGuid()}";

                        // copy files
                        File.Copy($"{baseDllPath}.dll", $"{hotReloadDllPath}.dll");
                        File.Copy($"{baseDllPath}.pdb", $"{hotReloadDllPath}.pdb");

                        hotReloadData.DllFileName = hotReloadDllPath;

                        var json = JsonSerializer.Serialize(hotReloadData);

                        // send file location
                        await streamWriter.WriteLineAsync(json);
                    }
                }
                catch { }
            }

            semaphore.Release();
        }
	}
}
