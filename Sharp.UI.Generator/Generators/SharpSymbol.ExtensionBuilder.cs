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
	public partial class SharpSymbol
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
                .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains(BindablePropertiesAttributeString)) != null);

            foreach (var inter in interfaces)
            {
                var properties = inter
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property);

                foreach (var prop in properties)
                {
                    var propertySymbol = (IPropertySymbol)prop;
                    var fullPropertyName = $"{extensionType.ToDisplayString()}.{prop.Name}";
                    GenerateExtensionMethod(propertySymbol, fullPropertyName);
                }
            }
        }

        void GenerateAttachedPropertiesExtension()
        {
            if (sharpAttribute != null)
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
                            var propertySymbol = (IPropertySymbol)prop;
                            var propName = prop.Name.Replace(attachedType.Name, "");
                            var fullPropertyName = $"{attachedType.ToDisplayString()}.{propName}";
                            GenerateExtensionMethod(propertySymbol, fullPropertyName);
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
            public readonly string propertyCastTypeName;
            public readonly string camelCaseName;
            public readonly string typeTail;
            public readonly string assignmentString;
            public readonly string assignmentDefString;
            public readonly string assignmentDataTemplateString;
            public readonly string mauiValueString;

            public PropertyInfo(INamedTypeSymbol type, IPropertySymbol propertySymbol)
            {
                this.propertySymbol = propertySymbol;

                CheckIfIsWrappedSealedType(propertySymbol.Type, out var isWrappedSealedType, out var isArrayOfWrappedSealedType, out var isObjectType);

                propertyName = propertySymbol.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
                propertyName = propertyName.Equals("class") ? "@class" : propertyName;
                accessedWith = propertySymbol.IsStatic ? $"{type.ToDisplayString()}" : "mauiObject";
                propertyTypeName = isWrappedSealedType ? $"Sharp.UI.{propertySymbol.Type.Name}" : propertySymbol.Type.ToDisplayString();
                propertyCastTypeName = propertySymbol.Type.ToDisplayString();
                camelCaseName = Helpers.CamelCase(propertyName);
                typeTail = propertyTypeName.Contains("?") ? "" : "?";
                assignmentString = $"{accessedWith}.{propertyName} = {(isWrappedSealedType ? "mauiValue" : $"({propertyCastTypeName}){camelCaseName}")}";
                assignmentDefString = $"mauiObject.{propertyName} = {(isWrappedSealedType ? $"MauiWrapper.Value<{propertyCastTypeName}>(def.GetValue())" : "def.GetValue()")}";
                assignmentDataTemplateString = $"mauiObject.{propertyName} = new Microsoft.Maui.Controls.DataTemplate(loadTemplate)";
                bindablePropertyName = $"{type.ToDisplayString()}.{propertyName}Property";
                mauiValueString = !isWrappedSealedType ? "" : @$"
            var mauiValue = MauiWrapper.Value<{propertyCastTypeName}>({camelCaseName});";
            }

            public PropertyInfo(IPropertySymbol propertySymbol, string fullName)
            {
                this.propertySymbol = propertySymbol;

                CheckIfIsWrappedSealedType(propertySymbol.Type, out var isWrappedSealedType, out var isArrayOfWrappedSealedType, out var isObjectType);

                var propertyType = ((IPropertySymbol)propertySymbol).Type.ToDisplayString();
                propertyName = propertySymbol.Name;
                accessedWith = "mauiObject";
                propertyTypeName = propertySymbol.Type.ToDisplayString();
                propertyCastTypeName = isWrappedSealedType ? "object" : propertySymbol.Type.ToDisplayString();
                camelCaseName = Helpers.CamelCase(fullName.Split(new[] { '.' }).Last());
                typeTail = "?";
                bindablePropertyName = $"{fullName}Property";
                assignmentString = $"mauiObject.SetValue({bindablePropertyName}, {(isWrappedSealedType ? "mauiValue" : $"({propertyCastTypeName}){camelCaseName}")})";
                assignmentDefString = $"mauiObject.SetValue({bindablePropertyName}, {(isWrappedSealedType ? $"MauiWrapper.Value<{propertyCastTypeName}>(def.GetValue())" : "def.GetValue()")})";
                assignmentDataTemplateString = $"mauiObject.SetValue({bindablePropertyName}, new Microsoft.Maui.Controls.DataTemplate(loadTemplate))";
                mauiValueString = !isWrappedSealedType ? "" : @$"
            var mauiValue = MauiWrapper.Value<{propertyCastTypeName}>({camelCaseName});";
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

        void GenerateExtensionMethod(IPropertySymbol propertySymbol, string fullName)
        {
            var info = new PropertyInfo(propertySymbol, fullName);
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



        void GenerateExtensionMethod_OnlyValue(PropertyInfo info)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName}{info.typeTail} {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);{info.mauiValueString}
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
            System.Func<BindableDef<{info.propertyTypeName}>, BindableDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);{info.mauiValueString}         
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
            System.Func<BindableDef<{info.propertyTypeName}>, BindableDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
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
            System.Func<ValueDef<{info.propertyTypeName}>, ValueDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);{info.mauiValueString}
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
            System.Func<ValueDef<{info.propertyTypeName}>, ValueDef<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
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
        public static T {info.propertyName}<T>(this T obj, System.Func<object> loadTemplate) where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
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
            var eventHandlerType = ((INamedTypeSymbol)eventHandler.Type);
            var methodArgTypeName = eventHandlerType.DelegateInvokeMethod.Parameters.Last().ToDisplayString();

            var existInBases = false;
            Helpers.LoopDownToObject(extensionType.BaseType, type =>
            {
                existInBases = (type
                    .GetMembers()
                    .FirstOrDefault(e =>
                        e.Kind == SymbolKind.Event &&
                        e.DeclaredAccessibility == Accessibility.Public &&
                        e.Name.Equals(eventSymbol.Name)) != null);

                return existInBases;
            });

            if (!existInBases && !notGenerateList.Contains(eventSymbol.Name))
            {
                GenerateEventMethodHandler(eventSymbol, eventHandlerType);
                GenerateEventMethodNoArgs(eventSymbol);
            }
        }

        void GenerateEventMethodHandler(IEventSymbol eventSymbol, INamedTypeSymbol namedType)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T obj, {namedType.ToDisplayString()} handler)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
            mauiObject.{eventSymbol.Name} += handler;
            return obj;
        }}
        ");
        }

        void GenerateEventMethodNoArgs(IEventSymbol eventSymbol)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T obj, OnEventAction<T> action)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
            mauiObject.{eventSymbol.Name} += (o, arg) => action(obj);
            return obj;
        }}
        ");
        }

        // ----- list -----

        void GenerateExtensionMethod_List(PropertyInfo info, string typeName)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName} {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
            foreach (var item in {info.camelCaseName})
            {{
                var mauiItem = MauiWrapper.Value<{typeName}>(item);
                {info.accessedWith}.{info.propertyName}.Add(mauiItem);
            }}
            return obj;
        }}

        public static T {info.propertyName}<T>(this T obj,
            params {typeName}[] {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
            foreach (var item in {info.camelCaseName})
            {{
                var mauiItem = MauiWrapper.Value<{typeName}>(item);
                {info.accessedWith}.{info.propertyName}.Add(mauiItem);
            }}
            return obj;
        }}

        public static T {info.propertyName}<T>(this T obj,
            System.Func<Def<{info.propertyTypeName}>, Def<{info.propertyTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
            var def = definition(new Def<{info.propertyTypeName}>());
            if (def.ValueIsSet())
            {{
                var items = def.GetValue();
                foreach (var item in items) 
                {{
                    var mauiItem = MauiWrapper.Value<{typeName}>(item);
                    {info.accessedWith}.{info.propertyName}.Add(mauiItem);
                }}
            }}
            return obj;
        }}
        ");
        }

        #endregion
    }
}