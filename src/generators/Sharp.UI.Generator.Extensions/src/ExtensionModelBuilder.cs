//
// MIT License
// Copyright Pawel Krzywdzinski
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.Extensions
{
    /// <summary>
    /// All the semantic analysis of the former ExtensionGenerator.
    /// Result: an ExtensionModel (pure data) - no symbols travel further down the pipeline.
    /// </summary>
    internal static class ExtensionModelBuilder
    {
        public static ExtensionModelResult Build(INamedTypeSymbol symbol, CancellationToken ct)
        {
            try
            {
                return new ExtensionModelResult(BuildCore(symbol, ct), null, null);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new ExtensionModelResult(null, symbol.ToDisplayString(), ex.Message);
            }
        }

        static ExtensionModel BuildCore(INamedTypeSymbol symbol, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var attachedInterfacesAttribute = Shared.GetAttachedInterfacesAttributeData(symbol);

            var mainSymbol = attachedInterfacesAttribute == null
                ? symbol
                : attachedInterfacesAttribute.ConstructorArguments[0].Value as INamedTypeSymbol;

            if (mainSymbol == null)
                return null;

            var isVisualElement = Shared.IsVisualElement(mainSymbol);
            var isBindableObject = Shared.IsBindableObject(mainSymbol);

            var containingNamespace = mainSymbol.ContainingNamespace.ToDisplayString();
            var isMauiNamespace = containingNamespace.StartsWith("Microsoft.Maui", StringComparison.Ordinal);

            var tail =
                (attachedInterfacesAttribute != null ? ".attached" : "") +
                (isMauiNamespace ? "" : ".extension");

            var properties = new List<PropertyModel>();
            var events = new List<EventModel>();
            var interfaceProperties = new List<PropertyModel>();
            var emitTextAlignment = false;

            if (attachedInterfacesAttribute != null)
            {
                CollectAttachedProperties(mainSymbol, attachedInterfacesAttribute, interfaceProperties, ct);
            }
            else
            {
                CollectClassMembers(mainSymbol, isBindableObject, isVisualElement, properties, events, ct);
                emitTextAlignment = Shared.IsBaseImplementationOfInterface(mainSymbol, "ITextAlignment");
                CollectBindableInterfaceProperties(mainSymbol, interfaceProperties, ct);
            }

            return new ExtensionModel(
                HintName: $"{containingNamespace}.{Shared.GetNormalizedFileName(mainSymbol)}{tail}.g.cs",
                TargetNamespace: isMauiNamespace ? "Sharp.UI" : containingNamespace,
                ExtensionClassName: $"{Shared.GetNormalizedClassName(mainSymbol)}Extension",
                SymbolTypeName: mainSymbol.ToDisplayString(),
                IncludeSharpUIUsing: !isMauiNamespace,
                IsSealed: mainSymbol.IsSealed,
                Properties: new EquatableArray<PropertyModel>(properties.ToArray()),
                Events: new EquatableArray<EventModel>(events.ToArray()),
                EmitITextAlignment: emitTextAlignment,
                InterfaceProperties: new EquatableArray<PropertyModel>(interfaceProperties.ToArray()));
        }

        // -----------------------------------------------------------------
        // class members (former GenerateClassExtensionBody)
        // -----------------------------------------------------------------

        static void CollectClassMembers(
            INamedTypeSymbol mainSymbol,
            bool isBindableObject,
            bool isVisualElement,
            List<PropertyModel> properties,
            List<EventModel> events,
            CancellationToken ct)
        {
            var members = mainSymbol.GetMembers();

            var bindablePropertyNames = members
                .Where(e => e.IsStatic && e.Name.EndsWith("Property", StringComparison.Ordinal) &&
                            e.DeclaredAccessibility == Accessibility.Public)
                .Select(e => e.Name.Substring(0, e.Name.Length - "Property".Length))
                .ToList();

            foreach (var member in members.Where(e => e.Kind == SymbolKind.Property &&
                                                      e.DeclaredAccessibility == Accessibility.Public &&
                                                      !e.IsStatic &&
                                                      !Shared.IsSymbolDeprecated(e)))
            {
                ct.ThrowIfCancellationRequested();

                var model = BuildClassPropertyModel(
                    mainSymbol, (IPropertySymbol)member, bindablePropertyNames, isBindableObject, isVisualElement);

                if (model != null)
                    properties.Add(model);
            }

            foreach (var member in members.Where(e => e.Kind == SymbolKind.Event &&
                                                      e.DeclaredAccessibility == Accessibility.Public &&
                                                      !e.IsStatic &&
                                                      !Shared.IsSymbolDeprecated(e)))
            {
                ct.ThrowIfCancellationRequested();

                var model = BuildEventModel(mainSymbol, (IEventSymbol)member);
                if (model != null)
                    events.Add(model);
            }
        }

        static PropertyModel BuildClassPropertyModel(
            INamedTypeSymbol mainSymbol,
            IPropertySymbol property,
            List<string> bindablePropertyNames,
            bool isBindableObject,
            bool isVisualElement)
        {
            var symbolTypeName = mainSymbol.ToDisplayString();

            var propertyName = property.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
            propertyName = propertyName.Equals("class", StringComparison.Ordinal) ? "@class" : propertyName;

            // skip MainPage property for Shell (not bindable and has no setter)
            if (propertyName == "MainPage") return null;
            if (Shared.NotGenerateList.Contains(propertyName)) return null;

            var isBindableProperty = bindablePropertyNames.Contains(propertyName);
            var accessedWith = property.IsStatic ? symbolTypeName : "self";
            var bindablePropertyName = $"{symbolTypeName}.{propertyName}Property";
            var propertyTypeName = property.Type.ToDisplayString();
            var camelCaseName = Shared.CamelCase(propertyName);

            var isGenericIList = Shared.IsGenericIList(property.Type as INamedTypeSymbol, out var elementType);

            var isThickness = (propertyName.Equals("Margin", StringComparison.Ordinal) ||
                               propertyName.Equals("Padding", StringComparison.Ordinal)) &&
                              propertyTypeName.EndsWith(".Thickness", StringComparison.Ordinal);

            var valueAssignment = isBindableProperty
                ? $"self.SetValue({bindablePropertyName}, {camelCaseName});"
                : $"{accessedWith}.{propertyName} = {camelCaseName};";

            var dataTemplateAssignment = isBindableProperty
                ? $"self.SetValue({bindablePropertyName}, new DataTemplate(loadTemplate));"
                : $"{accessedWith}.{propertyName} = new DataTemplate(loadTemplate);";

            // ---- path: "regular property with a setter" ----
            if (!isGenericIList &&
                property.SetMethod != null &&
                property.SetMethod.DeclaredAccessibility == Accessibility.Public &&
                !ExistsInBaseClasses(mainSymbol, propertyName, getterAndSetter: true))
            {
                string animate = null;
                if (isVisualElement)
                {
                    if (propertyTypeName.Equals("double", StringComparison.Ordinal))
                        animate = "DoubleTransform";
                    else if (propertyTypeName.Equals("Microsoft.Maui.Graphics.Color", StringComparison.Ordinal))
                        animate = "ColorTransform";
                }

                return new PropertyModel(
                    PropertyName: propertyName,
                    CamelCaseName: camelCaseName,
                    PropertyTypeName: propertyTypeName,
                    BindablePropertyName: bindablePropertyName,
                    AccessedWith: accessedWith,
                    IsBindableProperty: isBindableProperty,
                    ValueAssignment: valueAssignment,
                    DataTemplateAssignment: dataTemplateAssignment,
                    EmitValue: true,
                    EmitThickness: isThickness,
                    EmitBindablePropertyBuilder: isBindableProperty,
                    EmitSetters: isBindableProperty,
                    EmitSettersThickness: isBindableProperty && isThickness,
                    EmitSettersBuilder: isBindableProperty,
                    EmitDataTemplate: propertyTypeName.Equals("Microsoft.Maui.Controls.DataTemplate", StringComparison.Ordinal),
                    EmitGetValue: false,
                    AnimateTransformName: animate,
                    EmitList: false,
                    ListElementTypeName: null);
            }

            // ---- path: "collection (IList<T>) with a getter" ----
            if (isGenericIList &&
                property.GetMethod != null &&
                property.GetMethod.DeclaredAccessibility == Accessibility.Public &&
                !ExistsInBaseClasses(mainSymbol, propertyName, getterAndSetter: false))
            {
                return new PropertyModel(
                    PropertyName: propertyName,
                    CamelCaseName: camelCaseName,
                    PropertyTypeName: propertyTypeName,
                    BindablePropertyName: bindablePropertyName,
                    AccessedWith: accessedWith,
                    IsBindableProperty: isBindableProperty,
                    ValueAssignment: valueAssignment,
                    DataTemplateAssignment: dataTemplateAssignment,
                    EmitValue: false,
                    EmitThickness: false,
                    EmitBindablePropertyBuilder: isBindableProperty,
                    EmitSetters: false,
                    EmitSettersThickness: false,
                    EmitSettersBuilder: false,
                    EmitDataTemplate: false,
                    EmitGetValue: false,
                    AnimateTransformName: null,
                    EmitList: true,
                    ListElementTypeName: elementType.ToDisplayString());
            }

            return null;
        }

        static EventModel BuildEventModel(INamedTypeSymbol mainSymbol, IEventSymbol eventSymbol)
        {
            if (Shared.NotGenerateList.Contains(eventSymbol.Name))
                return null;

            var existsInBases = false;
            Shared.LoopDownToObject(mainSymbol.BaseType, type =>
            {
                existsInBases = type.GetMembers().Any(e =>
                    e.Kind == SymbolKind.Event &&
                    e.DeclaredAccessibility == Accessibility.Public &&
                    e.Name.Equals(eventSymbol.Name, StringComparison.Ordinal));
                return existsInBases;
            });

            if (existsInBases) return null;

            var handler = eventSymbol.AddMethod?.Parameters.FirstOrDefault();
            if (handler == null) return null;

            return new EventModel(eventSymbol.Name, handler.Type.ToDisplayString());
        }

        static bool ExistsInBaseClasses(INamedTypeSymbol mainSymbol, string propertyName, bool getterAndSetter)
        {
            var exists = false;
            Shared.LoopDownToObject(mainSymbol.BaseType, type =>
            {
                exists = type.GetMembers().Any(e =>
                    e.Kind == SymbolKind.Property &&
                    e.DeclaredAccessibility == Accessibility.Public &&
                    (((IPropertySymbol)e).SetMethod != null || !getterAndSetter) &&
                    e.Name.Equals(propertyName, StringComparison.Ordinal));
                return exists;
            });
            return exists;
        }

        // -----------------------------------------------------------------
        // bindable properties from interfaces
        // -----------------------------------------------------------------

        static void CollectBindableInterfaceProperties(
            INamedTypeSymbol mainSymbol, List<PropertyModel> result, CancellationToken ct)
        {
            var interfaces = mainSymbol.Interfaces
                .Where(e => e.GetAttributes().Any(a => a.AttributeClass != null &&
                    a.AttributeClass.Name.Equals(Shared.BindablePropertiesAttributeString, StringComparison.Ordinal)));

            foreach (var inter in interfaces)
            {
                ct.ThrowIfCancellationRequested();

                foreach (var prop in inter.GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property && !Shared.IsSymbolDeprecated(e)))
                {
                    var model = BuildInterfacePropertyModel(
                        mainSymbol, (IPropertySymbol)prop, bindablePropertyName: null, isAttached: false);

                    if (model != null) result.Add(model);
                }
            }
        }

        // -----------------------------------------------------------------
        // attached properties (former GenerateAttachedPropertiesExtension)
        // -----------------------------------------------------------------

        static void CollectAttachedProperties(
            INamedTypeSymbol mainSymbol,
            AttributeData attachedInterfacesAttribute,
            List<PropertyModel> result,
            CancellationToken ct)
        {
            var interfaces = new List<INamedTypeSymbol>();

            interfaces.AddRange(attachedInterfacesAttribute.ConstructorArguments[1].Values
                .Select(e => e.Value as INamedTypeSymbol)
                .Where(e => e != null && e.GetAttributes().Any(a => a.AttributeClass != null &&
                    a.AttributeClass.Name.Equals(Shared.AttachedPropertiesAttributeString))));

            interfaces.AddRange(mainSymbol.Interfaces
                .Where(e => e.GetAttributes().Any(a => a.AttributeClass != null &&
                    a.AttributeClass.Name.Equals(Shared.AttachedPropertiesAttributeString))));

            foreach (var inter in interfaces)
            {
                ct.ThrowIfCancellationRequested();

                var attribute = inter.GetAttributes().FirstOrDefault(a => a.AttributeClass != null &&
                    a.AttributeClass.Name.Equals(Shared.AttachedPropertiesAttributeString));

                if (attribute == null) continue;

                var attachedType = attribute.ConstructorArguments[0].Value as INamedTypeSymbol;
                if (attachedType == null) continue;
                if (attachedType.ToDisplayString().Equals(mainSymbol.ToDisplayString(), StringComparison.Ordinal))
                    continue;

                foreach (var prop in inter.GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property && !Shared.IsSymbolDeprecated(e)))
                {
                    var propertySymbol = (IPropertySymbol)prop;
                    var attachedName = Shared.GetAttachedPropertyName(propertySymbol);
                    var fullPropertyName = $"{attachedType.ToDisplayString()}.{attachedName}";

                    var model = BuildInterfacePropertyModel(
                        mainSymbol, propertySymbol, fullPropertyName, isAttached: true);

                    if (model != null) result.Add(model);
                }
            }
        }

        // -----------------------------------------------------------------
        // shared by both "from interface" paths
        // -----------------------------------------------------------------

        static PropertyModel BuildInterfacePropertyModel(
            INamedTypeSymbol mainSymbol,
            IPropertySymbol propertySymbol,
            string bindablePropertyName,
            bool isAttached)
        {
            var symbolTypeName = mainSymbol.ToDisplayString();

            var propertyName = propertySymbol.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
            propertyName = propertyName.Equals("class", StringComparison.Ordinal) ? "@class" : propertyName;

            if (Shared.NotGenerateList.Contains(propertyName)) return null;

            var accessedWith = propertySymbol.IsStatic ? symbolTypeName : "self";

            if (bindablePropertyName == null)
                bindablePropertyName = $"{symbolTypeName}.{propertyName}Property";

            var propertyTypeName = propertySymbol.Type.ToDisplayString();
            var camelCaseName = Shared.CamelCase(propertyName);

            var isThickness = (propertyName.Equals("Margin", StringComparison.Ordinal) ||
                               propertyName.Equals("Padding", StringComparison.Ordinal)) &&
                              propertyTypeName.EndsWith(".Thickness", StringComparison.Ordinal);

            return new PropertyModel(
                PropertyName: propertyName,
                CamelCaseName: camelCaseName,
                PropertyTypeName: propertyTypeName,
                BindablePropertyName: bindablePropertyName,
                AccessedWith: accessedWith,
                IsBindableProperty: true,
                ValueAssignment: $"self.SetValue({bindablePropertyName}, {camelCaseName});",
                DataTemplateAssignment: $"self.SetValue({bindablePropertyName}, new DataTemplate(loadTemplate));",
                EmitValue: true,
                EmitThickness: isThickness,
                EmitBindablePropertyBuilder: true,
                EmitSetters: true,
                EmitSettersThickness: isThickness,
                EmitSettersBuilder: true,
                EmitDataTemplate: propertyTypeName.Contains("DataTemplate"),
                EmitGetValue: isAttached,
                AnimateTransformName: null,
                EmitList: false,
                ListElementTypeName: null);
        }
    }
}
