//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.Old
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
            GenerateExtensionNameSpace();
        }

        // --------- extension namespace ---------

        void GenerateExtensionNameSpace()
        {
            builder.Append($@"
namespace {nameSpaceString}
{{
    {GetUsingString()}public static class {GetNormalizedExtensionName()}
    {{");         
            GenerateClassExtensionBody();
            builder.AppendLine($@"
    }}
}}");
        }

        string GetUsingString()
        {
            if (!nameSpaceString.Equals("Sharp.UI"))
                return $@"using Sharp.UI;

    ";
            return "";
        }

        #endregion

        // ------- extension builder file name -----

        public string ExtensionBuilderFileName()
        {
            var name = mainSymbol.IsStatic ? mainSymbol.Name.Replace("Extension", "") : mainSymbol.Name;
            var tail = extensionType.IsGenericType ? $".{extensionType.TypeArguments.FirstOrDefault().Name}" : "";
            var extension = IsSharpUIType ? ".extension" : "";
            return $"{mainSymbol.ContainingNamespace}.{name}{tail}{extension}.g.cs";
        }

        //----------------------------------------
        #region extension generator
        //----------------------------------------

        private readonly List<string> bindablePropertiesGeneratedFromInterface = new List<string>();
        private readonly List<string> bindablePropertiesToGenerate = new List<string>();

        void GenerateClassExtensionBody()
        {
            GenerateBindablePropertiesFromInterface();

            if (!mainSymbol.IsStatic)
            {
                var bindableProperties = extensionType
                    .GetMembers()
                    .Where(e => e.IsStatic && e.Name.EndsWith("Property") && e.DeclaredAccessibility == Accessibility.Public).ToList();

                bindablePropertiesToGenerate.Clear();
                foreach (var prop in bindableProperties)
                {
                    var name = prop.Name.Substring(0, prop.Name.Length - "Property".Length);
                    bindablePropertiesToGenerate.Add(name);
                }

                var properties = extensionType
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public);

                var events = extensionType
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Event && e.DeclaredAccessibility == Accessibility.Public);

                foreach (var prop in properties)
                {
                    if (!bindablePropertiesGeneratedFromInterface.Contains(prop.Name))
                        GenerateExtensionMethod(prop);
                }
                foreach (var @event in events) GenerateEventMethod(@event);
            }

            GenerateAttachedPropertiesExtension();
        }

        void GenerateBindablePropertiesFromInterface()
        {
            // generate using bindable interface
            var interfaces = extensionType
                .Interfaces
                .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(BindablePropertiesAttributeString)) != null);

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
                    bindablePropertiesGeneratedFromInterface.Add(prop.Name);
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
                    interfaces.AddRange(attachedInterfacesAttribute.ConstructorArguments[0].Values
                        .Select(e => (INamedTypeSymbol)e.Value)
                        .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedPropertiesAttributeString)) != null)
                        .ToList());
                }

                interfaces.AddRange(
                    mainSymbol
                        .Interfaces
                        .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedPropertiesAttributeString)) != null));

                foreach (var inter in interfaces)
                {
                    var attribute = inter.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedPropertiesAttributeString));
                    if (attribute != null)
                    {
                        var attachedType = attribute.ConstructorArguments[0].Value as INamedTypeSymbol;

                        if (!attachedType.ToDisplayString().Equals(mainSymbol.ToDisplayString()))
                        {
                            var properties = inter
                                .GetMembers()
                                .Where(e => e.Kind == SymbolKind.Property);

                            foreach (var prop in properties)
                            {
                                var propertySymbol = (IPropertySymbol)prop;
                                var attachedName = GetAttachedName(propertySymbol);
                                var fullPropertyName = $"{attachedType.ToDisplayString()}.{attachedName}";
                                GenerateExtensionMethod(propertySymbol, fullPropertyName);
                            }
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
            public readonly string assignmentString;
            public readonly string assignmentBuilderString;
            public readonly string assignmentDataTemplateString;
            public readonly string mauiValueString;

            public PropertyInfo(INamedTypeSymbol type, IPropertySymbol propertySymbol)
            {
                this.propertySymbol = propertySymbol;

                CheckIfIsWrappedSealedType(propertySymbol.Type, out var isWrappedSealedType, out var isArrayOfWrappedSealedType, out var isObjectType, out var symbolNamespace);

                propertyName = propertySymbol.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
                propertyName = propertyName.Equals("class") ? "@class" : propertyName;
                accessedWith = propertySymbol.IsStatic ? $"{type.ToDisplayString()}" : "mauiObject";
                propertyTypeName = isWrappedSealedType ? $"{symbolNamespace}.{propertySymbol.Type.Name}" : propertySymbol.Type.ToDisplayString();
                propertyCastTypeName = propertySymbol.Type.ToDisplayString();
                camelCaseName = Helpers.CamelCase(propertyName);
                assignmentString = $"{accessedWith}.{propertyName} = {(isWrappedSealedType ? "mauiValue" : $"({propertyCastTypeName}){camelCaseName}")}";
                assignmentBuilderString = $"{accessedWith}.{propertyName} = {(isWrappedSealedType ? $"MauiWrapper.Value<{propertyCastTypeName}>(builder.GetValue())" : "builder.GetValue()")}";
                assignmentDataTemplateString = $"{accessedWith}.{propertyName} = new DataTemplate(loadTemplate)";
                bindablePropertyName = $"{type.ToDisplayString()}.{propertyName}Property";
                mauiValueString = !isWrappedSealedType ? "" : @$"
            var mauiValue = MauiWrapper.Value<{propertyCastTypeName}>({camelCaseName});";
            }

            public PropertyInfo(IPropertySymbol propertySymbol, string fullName)
            {
                this.propertySymbol = propertySymbol;

                CheckIfIsWrappedSealedType(propertySymbol.Type, out var isWrappedSealedType, out var isArrayOfWrappedSealedType, out var isObjectType, out var symbolNamespace);

                var propertyType = ((IPropertySymbol)propertySymbol).Type.ToDisplayString();
                propertyName = propertySymbol.Name;
                accessedWith = "mauiObject";
                propertyTypeName = propertySymbol.Type.ToDisplayString();
                propertyCastTypeName = isWrappedSealedType ? "object" : propertySymbol.Type.ToDisplayString();
                camelCaseName = Helpers.CamelCase(fullName.Split(new[] { '.' }).Last());
                bindablePropertyName = $"{fullName}Property";
                assignmentString = $"mauiObject.SetValue({bindablePropertyName}, {(isWrappedSealedType ? "mauiValue" : $"({propertyCastTypeName}){camelCaseName}")})";
                assignmentBuilderString = $"mauiObject.SetValue({bindablePropertyName}, {(isWrappedSealedType ? $"MauiWrapper.Value<{propertyCastTypeName}>(builder.GetValue())" : "builder.GetValue()")})";
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
                GenerateExtensionMethod_Value(info);
                GenerateExtensionMethod_ValueBuilder(info);
                GenerateExtensionMethod_BindingBuilder(info);

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
                    GenerateExtensionMethod_Value(info);
                    GenerateExtensionMethod_ValueBuilder(info);
                    if (bindablePropertiesToGenerate.Contains(info.propertyName))
                        GenerateExtensionMethod_BindingBuilder(info);

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
                            GenerateExtensionMethod_List(info, typeName.Name);
                        }
                    }
                }
            }
        }

        void GenerateExtensionMethod_Value(PropertyInfo info)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            {info.propertyTypeName} {info.camelCaseName})
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);{info.mauiValueString}
            {info.assignmentString};
            return obj;
        }}
        ");
        }

        void GenerateExtensionMethod_ValueBuilder(PropertyInfo info)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            System.Func<ValueBuilder<{info.propertyTypeName}>, ValueBuilder<{info.propertyTypeName}>> buildValue)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
            var builder = buildValue(new ValueBuilder<{info.propertyTypeName}>());
            if (builder.ValueIsSet()) {info.assignmentBuilderString};
            return obj;
        }}
        ");
        }

        void GenerateExtensionMethod_BindingBuilder(PropertyInfo info)
        {
            IsExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T obj,
            System.Func<BindingBuilder<{info.propertyTypeName}>, BindingBuilder<{info.propertyTypeName}>> buildBinding)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.Value<{extensionType.ToDisplayString()}>(obj);
            var builder = buildBinding(new BindingBuilder<{info.propertyTypeName}>(mauiObject, {info.bindablePropertyName}));
            builder.BindProperty();
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
        ");
        }

        #endregion
    }
}