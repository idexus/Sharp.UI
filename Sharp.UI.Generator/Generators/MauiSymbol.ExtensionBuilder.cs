//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator
{
	public partial class MauiSymbol
	{
        public bool IsExtensionMethodsGenerated { get; private set; }

        //----------------------------------------
        #region namespace buider
        //----------------------------------------

        public void BuildExtension(StringBuilder builder)
        {
            this.builder = builder;

            if (IsUserDefiniedType)
                GenerateUserDefinedTypeExtensionNameSpace();
            else
                GenerateSharpUIExtentionNameSpace();
        }

        // -------- Sharp.UI namespace ---------

        void GenerateSharpUIExtentionNameSpace()
        {
            builder.Append($@"
namespace Sharp.UI
{{
    public static class {GetNormalizedName()}GeneratedExtension
    {{");
            GenerateClassExtensionBody();
            builder.AppendLine($@"
    }}
}}");
        }

        // --------- user definied type ---------

        void GenerateUserDefinedTypeExtensionNameSpace()
        {
            builder.Append($@"
namespace {mainSymbol.ContainingNamespace}
{{
    using Sharp.UI;

    public static class {GetNormalizedName()}GeneratedExtension
    {{");         
            GenerateClassExtensionBody();
            builder.AppendLine($@"
    }}
}}");
        }

        #endregion

        // ------- extension builder file name -----

        public string ExtensionBuilderFileName()
        {
            var type = extensionType;
            var tail = type.IsGenericType ? $".{type.TypeArguments.FirstOrDefault().Name}" : "";
            var extension = IsUserDefiniedType ? ".extension" : "";
            return $"{type.ContainingNamespace}.{type.Name}{tail}{extension}.g.cs";
        }

        //----------------------------------------
        #region extension generator
        //----------------------------------------

        private readonly List<string> extensionBindablePropertiesGenerated = new List<string>();

        void GenerateClassExtensionBody()
        {
            // loop for sealed
            Helpers.LoopDownToObject(extensionType, type =>
            {
                var bindableProperties = type
                    .GetMembers()
                    .Where(e => e.IsStatic && e.Name.EndsWith("Property") && e.DeclaredAccessibility == Accessibility.Public).ToList();

                extensionBindablePropertiesGenerated.Clear();
                foreach (var prop in bindableProperties)
                {
                    var name = prop.Name.Substring(0, prop.Name.Length - "Property".Length);
                    extensionBindablePropertiesGenerated.Add(name);
                }

                var properties = type
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public);

                var events = type
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Event && e.DeclaredAccessibility == Accessibility.Public);

                foreach (var prop in properties) GenerateExtensionMethod(prop);
                foreach (var @event in events) GenerateEventMethod(@event);

                return IsWrappedType ? !WrappedType.IsSealed : true;
            });

            GenerateBindablePropertiesExtension();
            GenerateAttachedPropertiesExtension();
        }

        void GenerateBindablePropertiesExtension()
        {
            // generate using bindable interface
            var interfaces = extensionType
                .Interfaces
                .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains(BindableAttributeString)) != null);

            foreach (var inter in interfaces)
            {
                var properties = inter
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property);

                foreach (var prop in properties)
                {
                    var bindPropName = $"{extensionType.ToDisplayString()}.{prop.Name}";
                    var typeName = ((IPropertySymbol)prop).Type.ToDisplayString();
                    GenerateExtensionMethod(bindPropName, typeName, prop.Name);
                }
            }
        }

        void GenerateAttachedPropertiesExtension()
        {
            if (mauiWrapperAttribute != null)
            {
                List<INamedTypeSymbol> interfaces = new List<INamedTypeSymbol>();

                if (attachedInterfacesAttribute != null)
                {
                    interfaces.AddRange(attachedInterfacesAttribute.ConstructorArguments[0].Values.Select(e => (INamedTypeSymbol)e.Value).ToList());
                }

                interfaces.AddRange(
                    mainSymbol
                        .Interfaces
                        .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains(AttachedPropertiesAttributeString)) != null));

                foreach (var inter in interfaces)
                {
                    var attribute = inter.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains(AttachedPropertiesAttributeString));
                    if (attribute != null)
                    {
                        var attachedType = attribute.ConstructorArguments[0].Value as INamedTypeSymbol;

                        var properties = inter
                            .GetMembers()
                            .Where(e => e.Kind == SymbolKind.Property);

                        foreach (var prop in properties)
                        {
                            var attachedPropName = prop.Name.Replace(attachedType.Name, "");
                            var bindPropName = $"{attachedType.ToDisplayString()}.{attachedPropName}";
                            var typeName = ((IPropertySymbol)prop).Type.ToDisplayString();
                            GenerateExtensionMethod(bindPropName, typeName, prop.Name);
                        }
                    }
                }
            }
        }

        // ----- methods/events methods -----

        class PropertyInfo
        {
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

            public PropertyInfo(INamedTypeSymbol type, IPropertySymbol propertySymbol)
            {
                this.propertySymbol = propertySymbol;
                propertyName = propertySymbol.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
                propertyName = propertyName.Equals("class") ? "@class" : propertyName;
                accessedWith = propertySymbol.IsStatic ? $"{type.ToDisplayString()}" : "mauiObject";
                propertyTypeName = propertySymbol.Type.ToDisplayString();
                camelCaseName = Helpers.CamelCase(propertyName);
                typeTail = propertyTypeName.Contains("?") ? "" : "?";
                assignmentString = $"{accessedWith}.{propertyName} = ({propertyTypeName}){camelCaseName}";
                assignmentDefString = $"mauiObject.{propertyName} = def.GetValue()";
                assignmentDataTemplateString = $"mauiObject.{propertyName} = new Microsoft.Maui.Controls.DataTemplate(loadTemplate)";
                bindablePropertyName = $"{type.ToDisplayString()}.{propertyName}Property";
            }

            public PropertyInfo(string property, string propertyType, string symbolName)
            {
                propertyName = symbolName;
                accessedWith = "mauiObject";
                propertyTypeName = propertyType;
                camelCaseName = Helpers.CamelCase(property.Split(new[] { '.' }).Last());
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
            Helpers.LoopDownToObject(extensionType.BaseType, type =>
            {
                existInBaseClasses = (type
                            .GetMembers()
                            .FirstOrDefault(e =>
                                e.Kind == SymbolKind.Property &&
                                e.DeclaredAccessibility == Accessibility.Public &&
                                (((IPropertySymbol)e).SetMethod != null || !getterAndSetter) &&
                                e.Name.Equals(propertyName)) != null);

                return existInBaseClasses;
            });
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
            var info = new PropertyInfo(extensionType, (IPropertySymbol)property);
            if (!notGenerateList.Contains(info.propertyName))
            {
                if (info.propertySymbol.SetMethod != null &&
                    info.propertySymbol.SetMethod.DeclaredAccessibility == Accessibility.Public &&
                    !ExistInBaseClasses(info.propertyName, getterAndSetter: true))
                {
                    GenerateExtensionMethod_OnlyValue(info);
                    if (extensionBindablePropertiesGenerated.Contains(info.propertyName))
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
                        var isGenericIList = Helpers.IsGenericIList(propertyType, out var typeName);

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
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName} {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
            foreach (var item in {info.camelCaseName}) {info.accessedWith}.{info.propertyName}.Add(item);
            return obj;
        }}

        public static T {info.propertyName}<T>(this T obj,
            params {typeName}[] {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
            foreach (var item in {info.camelCaseName}) {info.accessedWith}.{info.propertyName}.Add(item);
            return obj;
        }}

        public static T {info.propertyName}<T>(this T obj,
            Func<Def<{info.propertyTypeName}>, Def<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
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
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
            if ({info.camelCaseName} != null) {info.assignmentString};
            return obj;
        }}
        ");
        }

        void GenerateExtensionMethod_ValueAndBindableDef(PropertyInfo info)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName},
            Func<BindableDef<{info.propertyTypeName}>, BindableDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
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
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            Func<BindableDef<{info.propertyTypeName}>, BindableDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
            var def = definition(new BindableDef<{info.propertyTypeName}>(mauiObject, {info.bindablePropertyName}));
            if (def.ValueIsSet()) {info.assignmentDefString};
            def.BindProperty();
            return obj;
        }}
        ");
        }

        void GenerateExtensionMethod_ValueAndDef(PropertyInfo info)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName},
            Func<ValueDef<{info.propertyTypeName}>, ValueDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
            if ({info.camelCaseName} != null) {info.assignmentString};
            var def = definition(new ValueDef<{info.propertyTypeName}>());
            if (def.ValueIsSet()) mauiObject.{info.propertyName} = def.GetValue();
            return obj;
        }}
        ");
        }

        void GenerateExtensionMethod_OnlyDef(PropertyInfo info)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            Func<ValueDef<{info.propertyTypeName}>, ValueDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
            var def = definition(new ValueDef<{info.propertyTypeName}>());
            if (def.ValueIsSet()) mauiObject.{info.propertyName} = def.GetValue();
            return obj;
        }}
        ");
        }

        void GenerateExtensionMethod_DataTemplate(PropertyInfo info)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj, Func<object> loadTemplate) where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
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
            var type = extensionType.BaseType;
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
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T obj, OnEventAction<T> action)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
            mauiObject.{eventSymbol.Name} += (o, arg) => action(obj);
            return obj;
        }}
        ");
        }

        void GenerateEventMethodWithArgs(IEventSymbol eventSymbol, string methodArgTypeName)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T obj, OnEventAction<T, {methodArgTypeName}> action)
            where T : {typeConformanceName}
        {{            
            var mauiObject = MauiWrapper.GetObject<{extensionType.ToDisplayString()}>(obj);
            mauiObject.{eventSymbol.Name} += (o, arg) => action(obj, arg);
            return obj;
        }}
        ");
        }

        #endregion
    }
}