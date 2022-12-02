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

    private readonly INamedTypeSymbol mauiType;

    private readonly List<string> notGenerateList = new List<string>();
    private readonly List<string> bindablePropertiesNames = new List<string>();

    private readonly string typeConformanceName;

    public MauiExtensionBuilder(INamedTypeSymbol symbol, StringBuilder builder)
    {
        this.builder = builder;
        this.mauiType = symbol;
        this.typeConformanceName = $"Sharp.UI.{WrapBuilder.GetInterfaceName(symbol)}";

        notGenerateList.Add("this[]");
        notGenerateList.Add("Handler");
        notGenerateList.Add("LogicalChildren");
        notGenerateList.Add("BindingContext");
    }

    //----------------------------------------
    #region namespace buider
    //----------------------------------------

    public void Buid()
    {
        var tail = mauiType.IsGenericType ? $"{mauiType.TypeArguments.FirstOrDefault().Name}" : "";
        var startWith = mauiType.ContainingNamespace.Name.Contains("Compatibility") ? "Compatibility" : "";

        builder.Append($@"
namespace Sharp.UI
{{
    public static class I{startWith}{mauiType.Name}{tail}GeneratedExtension
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

        var type = mauiType;
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

            if (!mauiType.IsSealed) break;
            type = type.BaseType;
        }
        while (!type.Name.Equals("Object"));
    }

    // ----- methods/events methods -----

    class PropertyInfo
    {
        public INamedTypeSymbol mauiType;
        public IPropertySymbol propertySymbol;
        public readonly string propertyName;
        public readonly string accessedWith;
        public readonly string propertyTypeName;
        public readonly string camelCaseName;
        public readonly string typeTail;

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
        }
    }

    void GenerateExtensionMethod(ISymbol property)
    {
        var info = new PropertyInfo(mauiType, (IPropertySymbol)property);

        var existInBases = false;
        var type = mauiType.BaseType;
        while (!existInBases && !type.Name.Equals("Object"))
        {
            existInBases = (type
                        .GetMembers()
                        .FirstOrDefault(e =>
                            e.Kind == SymbolKind.Property &&
                            e.DeclaredAccessibility == Accessibility.Public &&
                            e.Name.Equals(property.Name)) != null);

            type = type.BaseType;
        }
        

        if (!existInBases && !notGenerateList.Contains(info.propertyName))
        {
            if (!info.propertyName.Equals("this[]"))
            {
                if (info.propertySymbol.SetMethod != null && info.propertySymbol.SetMethod.DeclaredAccessibility == Accessibility.Public)
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
                    if (info.propertySymbol.Name.Contains("Triggers"))
                    {

                    }
                    if (info.propertySymbol.Type is INamedTypeSymbol)
                    {
                        var propertyType = (INamedTypeSymbol)info.propertySymbol.Type;
                        if (info.propertySymbol.GetMethod != null && info.propertySymbol.GetMethod.DeclaredAccessibility == Accessibility.Public &&
                           (WrapBuilder.IsIList(propertyType) && propertyType.TypeArguments.Count() == 1))
                        {
                            GenerateExtensionMethod_List(info);
                        }
                    }
                }
            }
        }
    }

    void GenerateExtensionMethod_List(PropertyInfo info)
    {
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName} {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            foreach (var item in {info.camelCaseName}) {info.accessedWith}.{info.propertyName}.Add(item);
            return obj;
        }}

        public static T {info.propertyName}<T>(this T obj,
            Func<Def<{info.propertyTypeName}>, Def<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
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
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            if ({info.camelCaseName} != null) {info.accessedWith}.{info.propertyName} = ({info.propertyTypeName}){info.camelCaseName};
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_ValueAndBindableDef(PropertyInfo info)
    {
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName},
            Func<BindableDef<{info.propertyTypeName}>, BindableDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            if ({info.camelCaseName} != null) {info.accessedWith}.{info.propertyName} = ({info.propertyTypeName}){info.camelCaseName};
            var def = definition(new BindableDef<{info.propertyTypeName}>(mauiObject, {info.mauiType.ToDisplayString()}.{info.propertyName}Property));
            if (def.ValueIsSet()) mauiObject.{info.propertyName} = def.GetValue();
            def.BindProperty();
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_OnlyBindableDef(PropertyInfo info)
    {
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            Func<BindableDef<{info.propertyTypeName}>, BindableDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            var def = definition(new BindableDef<{info.propertyTypeName}>(mauiObject, {mauiType.ToDisplayString()}.{info.propertyName}Property));
            if (def.ValueIsSet()) mauiObject.{info.propertyName} = def.GetValue();
            def.BindProperty();
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_ValueAndDef(PropertyInfo info)
    {
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName},
            Func<ValueDef<{info.propertyTypeName}>, ValueDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            if ({info.camelCaseName} != null) {info.accessedWith}.{info.propertyName} = ({info.propertyTypeName}){info.camelCaseName};
            var def = definition(new ValueDef<{info.propertyTypeName}>());
            if (def.ValueIsSet()) mauiObject.{info.propertyName} = def.GetValue();
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_OnlyDef(PropertyInfo info)
    {
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            Func<ValueDef<{info.propertyTypeName}>, ValueDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            var def = definition(new ValueDef<{info.propertyTypeName}>());
            if (def.ValueIsSet()) mauiObject.{info.propertyName} = def.GetValue();
            return obj;
        }}
        ");
    }

    void GenerateExtensionMethod_DataTemplate(PropertyInfo info)
    {
        builder.Append($@"
        public static T {info.propertyName}<T>(this T obj, Func<object> loadTemplate) where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            mauiObject.{info.propertyName} = new Microsoft.Maui.Controls.DataTemplate(loadTemplate);
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

        if (!notGenerateList.Contains(eventSymbol.Name))
        {
            if (methodArgTypeName.Equals("System.EventArgs"))
                GenerateEventMethodNoArgs(eventSymbol);
            else
                GenerateEventMethodWithArgs(eventSymbol, methodArgTypeName);
        }
    }

    void GenerateEventMethodNoArgs(IEventSymbol eventSymbol)
    {
        builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T obj, OnEventAction<T> action)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            mauiObject.{eventSymbol.Name} += (o, arg) => action(obj);
            return obj;
        }}
        ");
    }

    void GenerateEventMethodWithArgs(IEventSymbol eventSymbol, string methodArgTypeName)
    {
        builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T obj, OnEventAction<T, {methodArgTypeName}> action)
            where T : {typeConformanceName}
        {{            
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            mauiObject.{eventSymbol.Name} += (o, arg) => action(obj, arg);
            return obj;
        }}
        ");
    }

    #endregion
}
