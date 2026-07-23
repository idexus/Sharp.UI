//
// MIT License
// Copyright Pawel Krzywdzinski
//
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Sharp.UI.Generator.Classes
{
    // ---------------------------------------------------------------------
    // Models - ONLY plain, immutable data.
    // No ISymbol / SyntaxNode / Compilation here: they hold a reference
    // to the compilation and destroy the pipeline cache.
    // ---------------------------------------------------------------------

    internal sealed record ParameterModel(
        string TypeName,
        string CamelCaseName);

    internal sealed record ConstructorModel(
        EquatableArray<ParameterModel> Parameters);

    internal sealed record CallbackModel(
        string Key,
        string Value);

    internal sealed record BindablePropertyModel(
        string Name,
        string TypeName,
        bool IsNew,
        string DefaultValueString,
        EquatableArray<CallbackModel> Callbacks);

    internal sealed record ClassModel(
        // --- identity ---
        string Namespace,               // symbol.ContainingNamespace.ToDisplayString()
        string ClassName,               // symbol.Name
        string FullSymbolName,          // symbol.ToDisplayString().Split('.').Last()
        string FullyQualifiedName,      // symbol.ToDisplayString()
        string FileName,                // Helpers.GetNormalizedFileName(symbol)

        // --- kind ---
        bool IsSealed,
        bool IsSharpObject,
        bool IsShell,
        bool IsTopContentSymbol,

        // --- container ---
        string ContentPropertyName,
        string ContainerOfTypeName,
        bool IsSingleItemContainer,
        bool IsNewPropertyContainer,
        bool IsAlreadyContainerOfThis,

        // --- constructors ---
        bool HasImplicitParameterlessCtor,
        bool HasExplicitParameterlessCtor,
        bool HasAnyExplicitPublicCtor,
        bool BaseHasParameterlessCtor,
        EquatableArray<ConstructorModel> Constructors,

        // --- bindable properties ---
        EquatableArray<BindablePropertyModel> BindableProperties);

    // ---------------------------------------------------------------------
    // Diagnostics - Location holds a SyntaxTree, so only the raw coordinates
    // are stored and the Location is rebuilt inside RegisterSourceOutput.
    // ---------------------------------------------------------------------

    internal sealed record LocationInfo(
        string FilePath,
        TextSpan TextSpan,
        LinePositionSpan LineSpan)
    {
        public Location ToLocation() => Location.Create(FilePath, TextSpan, LineSpan);

        public static LocationInfo CreateFrom(ISymbol symbol)
        {
            var location = symbol.Locations.FirstOrDefault(e => e.IsInSource);
            if (location == null) return null;

            var span = location.GetLineSpan();
            return new LocationInfo(span.Path, location.SourceSpan, span.Span);
        }
    }

    internal sealed record DiagnosticInfo(
        DiagnosticDescriptor Descriptor,
        LocationInfo Location,
        EquatableArray<string> MessageArgs)
    {
        public Diagnostic ToDiagnostic() => Diagnostic.Create(
            Descriptor,
            Location?.ToLocation() ?? Microsoft.CodeAnalysis.Location.None,
            MessageArgs.Cast<object>().ToArray());
    }

    /// <summary>
    /// Result of analysing a single class: the model to generate (or null) plus diagnostics.
    /// </summary>
    internal sealed record ClassModelResult(
        ClassModel Model,
        EquatableArray<DiagnosticInfo> Diagnostics);
}
