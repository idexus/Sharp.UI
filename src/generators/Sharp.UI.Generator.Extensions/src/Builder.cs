//
// MIT License
// Copyright Pawel Krzywdzinski
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharp.UI.Generator.Extensions
{
    [Generator]
    public class Builder : IIncrementalGenerator
    {
        static readonly DiagnosticDescriptor GeneratorError = new DiagnosticDescriptor(
            id: "SHARPUIEXT001",
            title: "Sharp.UI extensions generator error",
            messageFormat: "Error while generating extensions for '{0}': {1}",
            category: "Sharp.UI",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // -------------------------------------------------------------
            // 1) .NET MAUI types - available ONLY through reference metadata,
            //    reached via the fields of the Sharp.UI.Internal.MauiSymbols marker.
            //
            //    This cannot be hung off a SyntaxProvider: those types have no
            //    declaration in the compilation. That leaves CompilationProvider,
            //    which changes on every edit - but its result (an EquatableArray
            //    of models) is stable, so the expensive emission of hundreds of
            //    files gets skipped.
            // -------------------------------------------------------------

            var mauiModels = context.CompilationProvider
                .Select(static (compilation, ct) => BuildMauiModels(compilation, ct))
                .SelectMany(static (models, ct) => models);

            // -------------------------------------------------------------
            // 2) User types marked with [SharpObject] (outside the Sharp.UI namespace)
            // -------------------------------------------------------------

            var sharpObjectModels = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: static (node, _) =>
                        node is ClassDeclarationSyntax cds &&
                        !cds.Modifiers.Any(SyntaxKind.StaticKeyword) &&
                        cds.AttributeLists.Count > 0,
                    transform: static (ctx, ct) => TransformSharpObject(ctx, ct))
                .Where(static e => e != null);

            // -------------------------------------------------------------
            // 3) Static classes marked with [AttachedInterfaces]
            // -------------------------------------------------------------

            var attachedModels = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: static (node, _) =>
                        node is ClassDeclarationSyntax cds &&
                        cds.Modifiers.Any(SyntaxKind.StaticKeyword) &&
                        cds.AttributeLists.Count > 0,
                    transform: static (ctx, ct) => TransformAttachedInterfaces(ctx, ct))
                .Where(static e => e != null);

            // -------------------------------------------------------------

            context.RegisterSourceOutput(mauiModels, static (spc, model) => Emit(spc, new ExtensionModelResult(model, null, null)));
            context.RegisterSourceOutput(sharpObjectModels, static (spc, result) => Emit(spc, result));
            context.RegisterSourceOutput(attachedModels, static (spc, result) => Emit(spc, result));
        }

        static void Emit(SourceProductionContext context, ExtensionModelResult result)
        {
            if (result.ErrorMessage != null)
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    GeneratorError, Location.None, result.ErrorTarget, result.ErrorMessage));
                return;
            }

            if (result.Model != null)
                new ExtensionGenerator(result.Model).Build(context);
        }

        // -----------------------------------------------------------------
        // branch 1: MAUI
        // -----------------------------------------------------------------

        static EquatableArray<ExtensionModel> BuildMauiModels(Compilation compilation, CancellationToken ct)
        {
            // GetTypeByMetadataName instead of scanning every type in the compilation
            var mauiSymbolsType = compilation.GetTypeByMetadataName("Sharp.UI.Internal.MauiSymbols");
            if (mauiSymbolsType == null)
                return EquatableArray<ExtensionModel>.Empty;

            var mauiSymbols = mauiSymbolsType
                .GetMembers()
                .OfType<IFieldSymbol>()
                .Select(e => e.Type as INamedTypeSymbol)
                .Where(e => e != null)
                .ToList();

            var known = new HashSet<INamedTypeSymbol>(mauiSymbols, SymbolEqualityComparer.Default);
            var allSymbols = new List<INamedTypeSymbol>(mauiSymbols);

            foreach (var symbol in mauiSymbols)
            {
                ct.ThrowIfCancellationRequested();

                Helpers.LoopDownToObject(symbol.BaseType, type =>
                {
                    if (known.Add(type)) allSymbols.Add(type);
                    return false;
                });
            }

            var models = new List<ExtensionModel>();

            foreach (var symbol in allSymbols)
            {
                ct.ThrowIfCancellationRequested();

                if (Helpers.IsSymbolDeprecated(symbol)) continue;

                var result = ExtensionModelBuilder.Build(symbol, ct);
                if (result.Model != null) models.Add(result.Model);
            }

            return new EquatableArray<ExtensionModel>(models.ToArray());
        }

        // -----------------------------------------------------------------
        // branches 2 and 3: types declared in the compilation
        // -----------------------------------------------------------------

        static ExtensionModelResult TransformSharpObject(GeneratorSyntaxContext ctx, CancellationToken ct)
        {
            var symbol = GetPrimarySymbol(ctx, ct);
            if (symbol == null || symbol.IsStatic) return null;

            if (symbol.ContainingNamespace.ToDisplayString().Equals("Sharp.UI", StringComparison.Ordinal))
                return null;

            var hasAttribute = symbol.GetAttributes().Any(e => e.AttributeClass != null &&
                e.AttributeClass.Name.Equals(Shared.SharpObjectAttributeString));

            return hasAttribute ? ExtensionModelBuilder.Build(symbol, ct) : null;
        }

        static ExtensionModelResult TransformAttachedInterfaces(GeneratorSyntaxContext ctx, CancellationToken ct)
        {
            var symbol = GetPrimarySymbol(ctx, ct);
            if (symbol == null || !symbol.IsStatic) return null;

            var hasAttribute = symbol.GetAttributes().Any(e => e.AttributeClass != null &&
                e.AttributeClass.Name.Equals(Shared.AttachedInterfacesAttributeString));

            return hasAttribute ? ExtensionModelBuilder.Build(symbol, ct) : null;
        }

        /// <summary>
        /// Returns the symbol only for the "first" declaration of a partial type,
        /// so that the same hintName is never generated twice.
        /// </summary>
        static INamedTypeSymbol GetPrimarySymbol(GeneratorSyntaxContext ctx, CancellationToken ct)
        {
            var declaration = (ClassDeclarationSyntax)ctx.Node;

            if (!(ctx.SemanticModel.GetDeclaredSymbol(declaration, ct) is INamedTypeSymbol symbol))
                return null;

            var references = symbol.DeclaringSyntaxReferences;
            if (references.Length > 1)
            {
                var primary = references
                    .OrderBy(e => e.SyntaxTree.FilePath, StringComparer.Ordinal)
                    .ThenBy(e => e.Span.Start)
                    .First();

                if (primary.SyntaxTree != declaration.SyntaxTree || primary.Span.Start != declaration.Span.Start)
                    return null;
            }

            return symbol;
        }
    }
}
