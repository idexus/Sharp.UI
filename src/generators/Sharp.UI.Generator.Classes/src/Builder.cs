//
// MIT License
// Copyright Pawel Krzywdzinski
//
using System;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharp.UI.Generator.Classes
{
    [Generator]
    public class Builder : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var results = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: static (node, _) => IsCandidate(node),
                    transform: static (ctx, ct) => Transform(ctx, ct))
                .Where(static result => result != null);

            context.RegisterSourceOutput(results, static (spc, result) =>
            {
                foreach (var diagnostic in result.Diagnostics)
                    spc.ReportDiagnostic(diagnostic.ToDiagnostic());

                if (result.Model != null)
                    new ClassGenerator(result.Model).Build(spc);
            });
        }

        // -----------------------------------------------------------------
        // stage 1: cheap syntactic filter (no semantics)
        // -----------------------------------------------------------------

        static bool IsCandidate(SyntaxNode node)
        {
            // ClassDeclarationSyntax - if you also support 'record',
            // switch this to TypeDeclarationSyntax
            if (!(node is ClassDeclarationSyntax cds))
                return false;

            return !cds.Modifiers.Any(SyntaxKind.StaticKeyword);
        }

        // -----------------------------------------------------------------
        // stage 2: semantics -> ClassModel (no symbols beyond this point)
        // -----------------------------------------------------------------

        static ClassModelResult Transform(GeneratorSyntaxContext ctx, CancellationToken ct)
        {
            var declaration = (ClassDeclarationSyntax)ctx.Node;

            if (!(ctx.SemanticModel.GetDeclaredSymbol(declaration, ct) is INamedTypeSymbol symbol))
                return null;

            if (symbol.IsStatic)
                return null;

            // A 'partial' class has several declarations, while AddSource requires a unique hintName.
            // Only the "first" declaration in a deterministic order is processed.
            if (!IsPrimaryDeclaration(symbol, declaration))
                return null;

            ct.ThrowIfCancellationRequested();

            var hasSharpObjectAttribute = symbol.GetAttributes()
                .Any(e => e.AttributeClass != null &&
                          e.AttributeClass.Name.Equals(Shared.SharpObjectAttributeString));

            var isTopContentSymbol = symbol.IsSealed &&
                (Shared.IsContentPage(symbol) || Shared.IsShell(symbol));

            if (!hasSharpObjectAttribute && !isTopContentSymbol)
                return null;

            return ClassModelBuilder.Build(symbol, ct);
        }

        static bool IsPrimaryDeclaration(INamedTypeSymbol symbol, ClassDeclarationSyntax declaration)
        {
            var references = symbol.DeclaringSyntaxReferences;
            if (references.Length <= 1)
                return true;

            var primary = references
                .OrderBy(e => e.SyntaxTree.FilePath, StringComparer.Ordinal)
                .ThenBy(e => e.Span.Start)
                .First();

            return primary.SyntaxTree == declaration.SyntaxTree
                && primary.Span.Start == declaration.Span.Start;
        }
    }
}
