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
        public const string SharpObjectAttributeString = "SharpObjectAttribute";
        public const string BindablePropertiesAttributeString = "BindablePropertiesAttribute";
        public const string AttachedPropertiesAttributeString = "AttachedPropertiesAttribute";
        public const string AttachedInterfacesAttributeString = "AttachedInterfacesAttribute";
        public const string ContentPropertyAttributeString = "ContentPropertyAttribute";
        public const string AttachedNameAttributeString = "AttachedNameAttribute";
        public const string PropertyCallbackAttributeString = "PropertyCallbacksAttribute";
        public const string DefaultValueAttributeString = "DefaultValueAttribute";

        public const string CompatibilityString = "Compatibility";

        class SharpObjectAttribParams
        {
            public const int WrappedType = 0;
        }

        private StringBuilder builder;

        INamedTypeSymbol mainSymbol { get; set; }

        // attributes
        AttributeData sharpAttribute;
        AttributeData attachedInterfacesAttribute;

        // [SharpObject] parameters
        public INamedTypeSymbol WrappedType { get; private set; }
        string containerPropertyName = null;

        // helpers
        public bool IsSharpUIType => sharpAttribute != null;
        public bool IsWrappedType => WrappedType != null;
        public bool IsWrappedSealedType => WrappedType != null && WrappedType.IsSealed;

        // not generate list
        List<string> notGenerateList = null;

        // class generation
        bool generateAdditionalConstructors = false;
        bool generateNoParamConstructor = false;
        bool singleItemContainer = false;
        string containerOfTypeName = null;
        string nameSpaceString;
        bool isNewContainer = false;
        bool isAlreadyContainerOfThis = false;

        // extensions
        private string typeConformanceName;
        private INamedTypeSymbol extensionType => mainSymbol.IsStatic && IsWrappedType ? WrappedType : mainSymbol;

        public SharpSymbol(INamedTypeSymbol symbol, INamedTypeSymbol sharpSymbol = null)
		{
            mainSymbol = symbol;

            // get attributes
            sharpAttribute = GetSharpAttributeData(mainSymbol);
            attachedInterfacesAttribute = GetAttachedInterfacesAttributeData();

            WrappedType = GetWrappedType(sharpAttribute);

            nameSpaceString = sharpSymbol != null ? sharpSymbol.ContainingNamespace.ToDisplayString() : mainSymbol.ContainingNamespace.ToDisplayString();
            typeConformanceName = IsWrappedType && WrappedType.ContainingNamespace.ToDisplayString().StartsWith("Microsoft.Maui") ?
                ($"Sharp.UI.I{GetNormalizedName()}") :
                (IsWrappedType || sharpSymbol != null ? $"{nameSpaceString}.I{GetNormalizedName()}" : mainSymbol.ToDisplayString());

            if (IsSharpUIType)
            {
                SetupContainerIfNeeded();
                SetupConstructorsGeneration();
            }

            this.notGenerateList = new List<string>();
            notGenerateList.Add("this[]");
            notGenerateList.Add("Handler");
            notGenerateList.Add("LogicalChildren");
        }

        void SetupContainerIfNeeded()
        {
            this.containerPropertyName = GetContentPropertyName(mainSymbol);

            this.isAlreadyContainerOfThis = Helpers.IsGenericIList(IsWrappedType ? WrappedType : mainSymbol, out var containerType);

            if (containerPropertyName != null && isAlreadyContainerOfThis) throw new ArgumentException($"Type {mainSymbol.ToDisplayString()} defines IList interface, you can not use ContentProperty attribute");

            if (isAlreadyContainerOfThis && (!IsWrappedType || WrappedType.IsSealed))
            {
                this.containerOfTypeName = containerType;
                this.containerPropertyName = "this";
                this.singleItemContainer = false;
            }
            else if (!isAlreadyContainerOfThis)
            {
                // if is null try to find
                if (IsWrappedType)
                {
                    if (string.IsNullOrEmpty(this.containerPropertyName))
                    {
                        var propertyName = FindContentPropertyName();
                        if (propertyName != null && string.IsNullOrEmpty(this.containerPropertyName))
                            this.containerPropertyName = propertyName;
                    }
                }
                else
                {
                    isNewContainer = containerPropertyName != null && IsNewPropertyContainer(mainSymbol);
                }

                if (!string.IsNullOrEmpty(this.containerPropertyName) && string.IsNullOrEmpty(containerOfTypeName))
                {
                    IPropertySymbol propertySymbol = FindPropertySymbolWithName(this.containerPropertyName);

                    if (propertySymbol == null) throw new Exception($"No content property for: {WrappedType.Name}");

                    var mauiContainerType = (INamedTypeSymbol)((propertySymbol).Type);
                    if (Helpers.IsGenericIList(mauiContainerType, out var ofTypeName))
                    {
                        this.containerOfTypeName = ofTypeName;
                        this.singleItemContainer = false;
                    }
                    else
                    {
                        this.containerOfTypeName = mauiContainerType.ToDisplayString();
                        this.singleItemContainer = true;
                    }
                }
            }
        }

        void SetupConstructorsGeneration()
        {
            this.generateNoParamConstructor = true;
            if (mainSymbol.Constructors.Any(e => e.Parameters.Count() == 0 && !e.IsImplicitlyDeclared))
                this.generateNoParamConstructor = false;

            if (IsWrappedType)
            {
                if (WrappedType.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0) == null)
                    this.generateNoParamConstructor = false;
            }
            else
            {
                if (mainSymbol.Constructors.Any(e => e.Parameters.Count() > 0))
                    this.generateNoParamConstructor = false;
            }

            this.generateAdditionalConstructors =
                    mainSymbol.Constructors.FirstOrDefault(e => !e.IsImplicitlyDeclared) != null ||
                    this.generateNoParamConstructor;
        }

        // ------ normalized name ------

        public static string GetNormalizedName(INamedTypeSymbol type)
        {
            var prefix = type.ContainingNamespace.ToDisplayString().Contains(CompatibilityString) ? CompatibilityString : "";
            var name = type.IsStatic ? type.Name.Replace("Extension", "") : type.Name;
            var tail = type.IsGenericType ? $"{type.TypeArguments.FirstOrDefault().Name}" : "";
            return $"{prefix}{name}{tail}";
        }

        public string GetNormalizedName()
        {
            var type = IsWrappedType ? WrappedType : mainSymbol;
            return GetNormalizedName(type);
        }

        public string GetNormalizedExtensionName()
        {
            var tail = IsSharpUIType ? "SharpObject" : "";
            return $"{GetNormalizedName(mainSymbol)}Generated{tail}Extension";
        }

        // ------ helpers ------

        static bool IsISealedMauiWrapper(INamedTypeSymbol symbol)
        {
            return symbol.AllInterfaces.FirstOrDefault(e => e.Name.Equals("ISealedMauiWrapper")) != null;
        }

        static bool IsIMauiWrapper(INamedTypeSymbol symbol)
        {
            return symbol.AllInterfaces.FirstOrDefault(e => e.Name.Equals("IMauiWrapper")) != null;
        }

        static bool IsNewPropertyContainer(INamedTypeSymbol symbol)
        {
            bool isNewContainer = false;
            bool isIMauiWrapper = IsIMauiWrapper(symbol);
            if (isIMauiWrapper)
            {
                Helpers.LoopDownToObject(symbol.BaseType, type =>
                {
                    isNewContainer = type.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(ContentPropertyAttributeString, StringComparison.Ordinal)) != null;
                    return isNewContainer;
                });
            }
            return isNewContainer;
        }

        public static AttributeData GetSharpAttributeData(INamedTypeSymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            return attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(SharpObjectAttributeString));
        }

        public static INamedTypeSymbol GetWrappedType(AttributeData attributeData)
        {
            if (attributeData == null) return null;
            return attributeData.ConstructorArguments[SharpObjectAttribParams.WrappedType].Value as INamedTypeSymbol;
        }

        AttributeData GetAttachedInterfacesAttributeData()
        {
            var attributes = mainSymbol.GetAttributes();
            return attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedInterfacesAttributeString));
        }

        string GetAttachedName(ISymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedNameAttributeString));
            if (attributeData != null) return (string)attributeData.ConstructorArguments[0].Value;
            return symbol.Name;
        }

        Dictionary<string, string> GetPropertyCallbacks(ISymbol symbol)
        {
            var data = new Dictionary<string, string>();
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(PropertyCallbackAttributeString));
            if (attributeData != null)
            {
                var arguments = attributeData.ConstructorArguments;
                if (arguments[0].Value != null) data["propertyChanged"] = (string)arguments[0].Value;
                if (arguments[1].Value != null) data["propertyChanging"] = (string)arguments[1].Value;
                if (arguments[2].Value != null) data["validateValue"] = (string)arguments[2].Value;
                if (arguments[3].Value != null) data["coerceValue"] = (string)arguments[3].Value;
                if (arguments[4].Value != null) data["defaultValueCreator"] = (string)arguments[4].Value;
                if (data.Count() == 0) throw new ArgumentException($"PropertyCallback attribute must have minmium one attribute defined, symbol: {symbol.ToDisplayString()}");
            }
            return data;
        }

        string GetDefaultValueString(ISymbol symbol, string typeName)
        {
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(DefaultValueAttributeString));
            if (attributeData != null)
            {
                
                var value =  attributeData.ConstructorArguments[0].Value.ToString();
                if (typeName.Equals("string")) value = $"\"{value}\"";
                if (typeName.Equals("double") || typeName.Equals("float")) value = value.Replace(",", ".");
                return value;
            }
            return null;
        }

        string GetContentPropertyName(INamedTypeSymbol symbol)
        {
            var attributeData = symbol.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(ContentPropertyAttributeString));
            return attributeData != null ? (string)attributeData.ConstructorArguments[0].Value : null;
        }

        string FindContentPropertyName()
        {
            string name = null;
            Helpers.LoopDownToObject(this.WrappedType, type =>
            {
                name = GetContentPropertyName(type);
                return name != null;
            });
            return name;
        }

        IPropertySymbol GetPropertyFromInterface(string name)
        {
            if (IsBindable())
            {
                var bindableInterfaces = mainSymbol
                    .AllInterfaces
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(BindablePropertiesAttributeString)) != null);

                if (bindableInterfaces.Count() > 0)

                    foreach (var inter in bindableInterfaces)
                    {
                        var properties = inter
                            .GetMembers()
                            .Where(e => e.Kind == SymbolKind.Property);

                        foreach (var prop in properties)
                            if (prop.Name.Equals(name, StringComparison.Ordinal))
                                return (IPropertySymbol)prop;
                    }
            }
            return null;
        }

        IPropertySymbol FindPropertySymbolWithName(string propertyName)
        {
            IPropertySymbol propertySymbol = GetPropertyFromInterface(propertyName);
            if (propertySymbol == null)
            {
                Helpers.LoopDownToObject(IsWrappedType ? WrappedType : mainSymbol, type =>
                {
                    propertySymbol = (IPropertySymbol)(type.GetMembers(propertyName).FirstOrDefault());
                    return propertySymbol != null;
                });
            }
            return propertySymbol;
        }
    }
}