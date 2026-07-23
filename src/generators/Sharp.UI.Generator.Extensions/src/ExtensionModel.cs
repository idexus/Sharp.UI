//
// MIT License
// Copyright Pawel Krzywdzinski
//
using Sharp.UI.Generator;

namespace Sharp.UI.Generator.Extensions
{
    // ---------------------------------------------------------------------
    // Models - data only, no ISymbol / Compilation.
    // ---------------------------------------------------------------------

    /// <summary>
    /// Equivalent of the former ExtensionGenerator.PropertyInfo class plus the
    /// "what to generate for this property" decisions.
    /// </summary>
    internal sealed record PropertyModel(
        // --- data ---
        string PropertyName,
        string CamelCaseName,
        string PropertyTypeName,
        string BindablePropertyName,
        string AccessedWith,
        bool IsBindableProperty,
        string ValueAssignment,
        string DataTemplateAssignment,

        // --- what to emit ---
        bool EmitValue,
        bool EmitThickness,
        bool EmitBindablePropertyBuilder,
        bool EmitSetters,
        bool EmitSettersThickness,
        bool EmitSettersBuilder,
        bool EmitDataTemplate,
        bool EmitGetValue,
        string AnimateTransformName,   // null | "DoubleTransform" | "ColorTransform"
        bool EmitList,
        string ListElementTypeName);

    internal sealed record EventModel(
        string Name,
        string HandlerTypeName);

    internal sealed record ExtensionModel(
        // --- identity / file header ---
        string HintName,
        string TargetNamespace,        // "Sharp.UI" for Microsoft.Maui.* types, otherwise the type's own namespace
        string ExtensionClassName,     // GetNormalizedClassName(...) + "Extension"
        string SymbolTypeName,         // mainSymbol.ToDisplayString()
        bool IncludeSharpUIUsing,
        bool IsSealed,

        // --- content ---
        EquatableArray<PropertyModel> Properties,          // from class members
        EquatableArray<EventModel> Events,
        bool EmitITextAlignment,
        EquatableArray<PropertyModel> InterfaceProperties) // bindable / attached, from interfaces
    {
        public bool HasContent =>
            Properties.Count > 0 ||
            Events.Count > 0 ||
            EmitITextAlignment ||
            InterfaceProperties.Count > 0;
    }

    /// <summary>
    /// Model plus an optional error. An exception breaks the whole step in an
    /// incremental pipeline, so failures are reported as diagnostics instead.
    /// </summary>
    internal sealed record ExtensionModelResult(
        ExtensionModel Model,
        string ErrorTarget,
        string ErrorMessage);
}
