using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;

namespace MauiWrapperGenerator;

public class MauiExtensionBuilder
{
    private readonly StringBuilder builder;

    private readonly INamedTypeSymbol mainType;

    private readonly List<string> notGenerateList = new List<string>();
    private readonly List<string> bindablePropertiesNames = new List<string>();

    private readonly List<string> attachedProperties = new List<string>();
    private readonly List<INamedTypeSymbol> attachedPropertiesTypes = new List<INamedTypeSymbol>();

    private readonly string typeConformanceName;

    public bool IsMethodsGenerated { get; private set; }

    private bool noBaseType = false;

    public MauiExtensionBuilder(INamedTypeSymbol symbol, StringBuilder builder, AttributeData wrapperAttribute)
    {
        this.builder = builder;
        this.mainType = symbol;
        this.typeConformanceName = $"Sharp.UI.{WrapBuilder.GetInterfaceName(symbol)}";
        this.IsMethodsGenerated = false;

        if (wrapperAttribute != null)
        {
            // only extension methods wrapper
            if (wrapperAttribute.ConstructorArguments[0].Value == null)
            {
                noBaseType = true;
                this.typeConformanceName = symbol.ToDisplayString();
            }

            // [1] doNotGenerate
            var notGenerateValues = wrapperAttribute.ConstructorArguments[1].Values;
            if (!notGenerateValues.IsDefaultOrEmpty)
                this.notGenerateList = notGenerateValues.Select(e => (string)e.Value).ToList();
            else
                this.notGenerateList = new List<string>();

            // [4] attachedProperties
            var attachedPropertiesValues = wrapperAttribute.ConstructorArguments[4].Values;
            if (!attachedPropertiesValues.IsDefaultOrEmpty)
                this.attachedProperties = attachedPropertiesValues.Select(e => (string)e.Value).ToList();
            else
                this.attachedProperties = new List<string>();

            // [5] attachedPropertiesTypes
            var attachedPropertiesTypesValues = wrapperAttribute.ConstructorArguments[5].Values;
            if (!attachedPropertiesTypesValues.IsDefaultOrEmpty)
                this.attachedPropertiesTypes = attachedPropertiesTypesValues.Select(e => (INamedTypeSymbol)e.Value).ToList();
            else
                this.attachedPropertiesTypes = new List<INamedTypeSymbol>();

            if (attachedProperties.Count() != attachedPropertiesTypes.Count())
                throw new ArgumentException($"Attached properties count and types count must be equal for {symbol.Name}");
        }

        notGenerateList.Add("this[]");
        notGenerateList.Add("Handler");
        notGenerateList.Add("LogicalChildren");
        notGenerateList.Add("BindingContext");
    }

    //----------------------------------------
    #region namespace buider
    //----------------------------------------

    public void Build()
    {
        var tail = mainType.IsGenericType ? $"{mainType.TypeArguments.FirstOrDefault().Name}" : "";
        var startWith = mainType.ContainingNamespace.Name.Contains("Compatibility") ? "Compatibility" : "";

        if (noBaseType)
            builder.Append($@"
namespace {mainType.ContainingNamespace}
{{
    using Sharp.UI;

    public static class {mainType.Name}GeneratedExtension
    {{");
        else
        builder.Append($@"
namespace Sharp.UI
{{
    public static class I{startWith}{mainType.Name}{tail}GeneratedExtension
    {{");
        GenerateClassExtensionBody();
        builder.AppendLine($@"
    }}
}}");
    }

    #endregion

    //----------------------------------------
    #region extension generator
    //----------------------------------------

    void GenerateClassExtensionBody()
    {
        var type = mainType;
        do
        {
            var bindableProperties = type
                .GetMembers()
                .Where(e => e.IsStatic && e.Name.EndsWith("Property") && e.DeclaredAccessibility == Accessibility.Public).ToList();

            bindablePropertiesNames.Clear();
            foreach (var prop in bindableProperties)
            {
                var name = prop.Name.Substring(0, prop.Name.Length - "Property".Length);
                bindablePropertiesNames.Add(name);
            }

            var properties = type
                .GetMembers()
                .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public);

            var events = type
                .GetMembers()
                .Where(e => e.Kind == SymbolKind.Event && e.DeclaredAccessibility == Accessibility.Public);

            foreach (var prop in properties) GenerateExtensionMethod(prop);
            foreach (var @event in events) GenerateEventMethod(@event);

            if (!mainType.IsSealed) break;
            type = type.BaseType;
        }
        while (!type.Name.Equals("Object"));

        // generate attached
        for (int i = 0; i < attachedProperties.Count(); i++)
            GenerateExtensionMethod(attachedProperties[i], attachedPropertiesTypes[i].ToDisplayString(), null);

        // generate using bindable interface
        var bindableInterfaces = mainType
            .Interfaces
            .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains("Bindable")) != null);

        foreach (var inter in bindableInterfaces)
        {
            var properties = inter
                .GetMembers()
                .Where(e => e.Kind == SymbolKind.Property);

            foreach (var prop in properties)
            {
                var bindPropName = $"{mainType.ToDisplayString()}.{prop.Name}";
                var typeName = ((IPropertySymbol)prop).Type.ToDisplayString();
                GenerateExtensionMethod(bindPropName, typeName, prop.Name);
            }
        }
    }

    // ----- methods/events methods -----

    class PropertyInfo
    {
        public INamedTypeSymbol mauiType;
        public IPropertySymbol propertySymbol;
        public readonly string propertyName;
        public readonly string bindablePropertyName;
        public readonly string accessedWith;
        public readonly string propertyTypeName;
        public readonly string camelCaseName;
        public readonly string typeTail;
        public readonly string assignmentString;
        public readonly string assignmentDefString;
        public readonly string assignmentDataTemplateString;

        public PropertyInfo(INamedTypeSymbol mauiType, IPropertySymbol propertySymbol)
        {
            this.mauiType = mauiType;
            this.propertySymbol = propertySymbol;
            propertyName = propertySymbol.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
            propertyName = propertyName.Equals("class") ? "@class" : propertyName;
            accessedWith = propertySymbol.IsStatic ? $"{mauiType.ToDisplayString()}" : "mauiObject";
            propertyTypeName = propertySymbol.Type.ToDisplayString();
            camelCaseName = WrapBuilder.CamelCase(propertyName);
            typeTail = propertyTypeName.Contains("?") ? "" : "?";
            assignmentString = $"{accessedWith}.{propertyName} = ({propertyTypeName}){camelCaseName}";
            assignmentDefString = $"mauiObject.{propertyName} = def.GetValue()";
            assignmentDataTemplateString = $"mauiObject.{propertyName} = new Microsoft.Maui.Controls.DataTemplate(loadTemplate)";
            bindablePropertyName = $"{mauiType.ToDisplayString()}.{propertyName}Property";
        }

        public PropertyInfo(string property, string propertyType, string symbolName)
        {
            propertyName = string.IsNullOrEmpty(symbolName) ? property.Replace(".", "") : symbolName;
            accessedWith = "mauiObject";
            propertyTypeName = propertyType;
            camelCaseName = WrapBuilder.CamelCase(property.Split(new[] { '.' }).Last());
            typeTail = "?";
            bindablePropertyName = $"{property}Property";
            assignmentString = $"mauiObject.SetValue({bindablePropertyName}, ({propertyTypeName}){camelCaseName})";
            assignmentDefString = $"mauiObject.SetValue({bindablePropertyName}, def.GetValue())";
            assignmentDataTemplateString = $"mauiObject.SetValue({bindablePropertyName}, new Microsoft.Maui.Controls.DataTemplate(loadTemplate))";
        }
    }

    bool ExistInBaseClasses(string propertyName, bool getterAndSetter)
    {
        var existInBaseClasses = false;
        var type = mainType.BaseType;
        while (!existInBaseClasses && !type.Name.Equals("Object"))
        {
            existInBaseClasses = (type
                        .GetMembers()
                        .FirstOrDefault(e =>
                            e.Kind == SymbolKind.Property &&
                            e.DeclaredAccessibility == Accessibility.Public &&
                            (((IPropertySymbol)e).SetMethod != null || !getterAndSetter) &&
                            e.Name.Equals(propertyName)) != null);

            type = type.BaseType;
        }

        return existInBaseClasses;
    }

    void GenerateExtensionMethod(string propertyName, string PropertyType, string symbolName)
    {
        var info = new PropertyInfo(propertyName, PropertyType, symbolName);
        if (!notGenerateList.Contains(info.propertyName))
        {
            GenerateExtensionMethod_OnlyValue(info);
            GenerateExtensionMethod_ValueAndBindableDef(info);
            GenerateExtensionMethod_OnlyBindableDef(info);

            if (info.propertyTypeName.Contains("DataTemplate"))
                GenerateExtensionMethod_DataTemplate(info);
        }
    }

    void GenerateExtensionMethod(ISymbol property)
    {
        var info = new PropertyInfo(mainType, (IPropertySymbol)property);
        if (!notGenerateList.Contains(info.propertyName))
        {
            if (info.propertySymbol.SetMethod != null &&
                info.propertySymbol.SetMethod.DeclaredAccessibility == Accessibility.Public &&
                !ExistInBaseClasses(info.propertyName, getterAndSetter: true))
            {
                GenerateExtensionMethod_OnlyValue(info);
                if (bindablePropertiesNames.Contains(info.propertyName))
                {
                    GenerateExtensionMethod_ValueAndBindableDef(info);
                    GenerateExtensionMethod_OnlyBindableDef(info);
                }
                else
                {
                    GenerateExtensionMethod_ValueAndDef(info);
                    GenerateExtensionMethod_OnlyDef(info);
                }

                if (info.propertySymbol.Type.Name.Equals("DataTemplate"))
                    GenerateExtensionMethod_DataTemplate(info);
            }
            else
            {
                if (info.propertySymbol.Type is INamedTypeSymbol)
                {
                    var propertyType = (INamedTypeSymbol)info.propertySymbol.Type;
                    var isGenericIList = WrapBuilder.IsGenericIList(propertyType, out var typeName);

                    if (info.propertySymbol.GetMethod != null &&
                        info.propertySymbol.GetMethod.DeclaredAccessibility == Accessibility.Public &&
                        isGenericIList &&
                        !ExistInBaseClasses(info.propertyName, getterAndSetter: false))
                    {
                        GenerateExtensionMethod_List(info, typeName);
                    }
                }
            }
        }
    }

    void GenerateExtensionMethod_List(PropertyInfo info, string typeName)
    {
        IsMethodsGenerated = true;
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName} {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            foreach (var item in {info.camelCaseName}) {info.accessedWith}.{info.propertyName}.Add(item);
            return obj;
        }}

        public static T {info.propertyName}<T>(this T obj,
            params {typeName}[] {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            foreach (var item in {info.camelCaseName}) {info.accessedWith}.{info.propertyName}.Add(item);
            return obj;
        }}

        public static T {info.propertyName}<T>(this T obj,
            Func<Def<{info.propertyTypeName}>, Def<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            var def = definition(new Def<{info.propertyTypeName}>());
            if (def.ValueIsSet())
            {{
                var items = def.GetValue();
                foreach (var item in items) {info.accessedWith}.{info.propertyName}.Add(item);
            }}
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_OnlyValue(PropertyInfo info)
    {
        IsMethodsGenerated = true;
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            if ({info.camelCaseName} != null) {info.assignmentString};
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_ValueAndBindableDef(PropertyInfo info)
    {
        IsMethodsGenerated = true;
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName},
            Func<BindableDef<{info.propertyTypeName}>, BindableDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            if ({info.camelCaseName} != null) {info.assignmentString};
            var def = definition(new BindableDef<{info.propertyTypeName}>(mauiObject, {info.bindablePropertyName}));
            if (def.ValueIsSet()) {info.assignmentDefString};
            def.BindProperty();
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_OnlyBindableDef(PropertyInfo info)
    {
        IsMethodsGenerated = true;
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            Func<BindableDef<{info.propertyTypeName}>, BindableDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            var def = definition(new BindableDef<{info.propertyTypeName}>(mauiObject, {info.bindablePropertyName}));
            if (def.ValueIsSet()) {info.assignmentDefString};
            def.BindProperty();
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_ValueAndDef(PropertyInfo info)
    {
        IsMethodsGenerated = true;
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName},
            Func<ValueDef<{info.propertyTypeName}>, ValueDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            if ({info.camelCaseName} != null) {info.assignmentString};
            var def = definition(new ValueDef<{info.propertyTypeName}>());
            if (def.ValueIsSet()) mauiObject.{info.propertyName} = def.GetValue();
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_OnlyDef(PropertyInfo info)
    {
        IsMethodsGenerated = true;
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            Func<ValueDef<{info.propertyTypeName}>, ValueDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            var def = definition(new ValueDef<{info.propertyTypeName}>());
            if (def.ValueIsSet()) mauiObject.{info.propertyName} = def.GetValue();
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_DataTemplate(PropertyInfo info)
    {
        IsMethodsGenerated = true;
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj, Func<object> loadTemplate) where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            {info.assignmentDataTemplateString};
            return obj;
        }}
        ");
    }

    //--------------------

    void GenerateEventMethod(ISymbol @event)
    {
        var eventSymbol = (IEventSymbol)@event;
        var eventHandler = eventSymbol.AddMethod.Parameters.First();
        var methodArgTypeName = ((INamedTypeSymbol)eventHandler.Type).DelegateInvokeMethod.Parameters.Last().ToDisplayString();

        var existInBases = false;
        var type = mainType.BaseType;
        while (!existInBases && !type.Name.Equals("Object"))
        {
            existInBases = (type
                        .GetMembers()
                        .FirstOrDefault(e =>
                            e.Kind == SymbolKind.Event &&
                            e.DeclaredAccessibility == Accessibility.Public &&
                            e.Name.Equals(eventSymbol.Name)) != null);

            type = type.BaseType;
        }

        if (!existInBases && !notGenerateList.Contains(eventSymbol.Name))
        {
            if (methodArgTypeName.Equals("System.EventArgs"))
                GenerateEventMethodNoArgs(eventSymbol);
            else
                GenerateEventMethodWithArgs(eventSymbol, methodArgTypeName);
        }
    }

    void GenerateEventMethodNoArgs(IEventSymbol eventSymbol)
    {
        IsMethodsGenerated = true;
        builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T obj, OnEventAction<T> action)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            mauiObject.{eventSymbol.Name} += (o, arg) => action(obj);
            return obj;
        }}
        ");
    }

    void GenerateEventMethodWithArgs(IEventSymbol eventSymbol, string methodArgTypeName)
    {
        IsMethodsGenerated = true;
        builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T obj, OnEventAction<T, {methodArgTypeName}> action)
            where T : {typeConformanceName}
        {{            
            var mauiObject = MauiWrapper.GetObject<{mainType.ToDisplayString()}>(obj);
            mauiObject.{eventSymbol.Name} += (o, arg) => action(obj, arg);
            return obj;
        }}
        ");
    }

    #endregion
}
