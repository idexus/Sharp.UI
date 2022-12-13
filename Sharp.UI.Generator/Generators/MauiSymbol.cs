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
        public const string MauiWrapperAttributeString = "MauiWrapper";
        public const string BindableAttributeString = "Bindable";
        public const string AttachedPropertiesAttributeString = "AttachedProperties";
        public const string AttachedInterfacesAttributeString = "AttachedInterfaces";
        public const string ContentPropertyAttributeString = "ContentProperty";

        public const string CompatibilityString = "Compatibility";

        class MauiWrapperParams
        {
            public const int WrappedType = 0;
            public const int ConstructorWithProperties = 1;
            public const int ContainerPopertyName = 2;
        }

        private StringBuilder builder;

        INamedTypeSymbol mainSymbol { get; set; }

        // attributes
        AttributeData mauiWrapperAttribute;
        AttributeData attachedInterfacesAttribute;

        // [MauiWrapper] parameters
        public INamedTypeSymbol WrappedType { get; private set; }
        List<string> constructorWithProperties = null;
        string containerPropertyName = null;

        // helpers
        public bool IsWrappedType => WrappedType != null;
        public bool IsUserDefiniedType => mauiWrapperAttribute != null && !IsWrappedType;

        // not generate list
        List<string> notGenerateList = null;

        // class generation
        bool generateAdditionalConstructors = false;
        bool generateNoParamConstructor = false;
        bool singleItemContainer = false;
        string containerOfTypeName = null;
        string nameSpaceString;

        // extensions
        private string typeConformanceName;
        private INamedTypeSymbol extensionType => IsWrappedType ? WrappedType : mainSymbol;

        public MauiSymbol(INamedTypeSymbol symbol)
		{
            mainSymbol = symbol;

            // get attributes
            mauiWrapperAttribute = GetMauiWrapperAttributeData(mainSymbol);
            attachedInterfacesAttribute = GetAttachedInterfacesAttributeData();

            WrappedType = GetWrappedType(mauiWrapperAttribute);

            nameSpaceString = IsUserDefiniedType ? mainSymbol.ContainingNamespace.ToDisplayString() : "Sharp.UI";
            typeConformanceName = IsUserDefiniedType ? symbol.ToDisplayString() : $"Sharp.UI.I{GetNormalizedName()}";

            SetupContainerIfNeeded();
            SetupConstructorsGeneration();
          
            this.notGenerateList = new List<string>();
            notGenerateList.Add("this[]");
            notGenerateList.Add("Handler");
            notGenerateList.Add("LogicalChildren");
            notGenerateList.Add("BindingContext");
        }

        void SetupContainerIfNeeded()
        {
            if (IsWrappedType)
            {
                this.containerPropertyName = (string)(mauiWrapperAttribute.ConstructorArguments[MauiWrapperParams.ContainerPopertyName].Value);

                var isContainerThis = Helpers.IsGenericIList(WrappedType, out var containerType);
                if (isContainerThis && WrappedType.IsSealed)
                {
                    this.containerOfTypeName = containerType;
                    this.containerPropertyName = "this";
                    this.singleItemContainer = false;
                }
                else if (!isContainerThis)
                {
                    // if is null try to find
                    if (string.IsNullOrEmpty(this.containerPropertyName))
                    {
                        var propertyName = FindContentPropertyName();
                        if (propertyName != null && string.IsNullOrEmpty(this.containerPropertyName))
                            this.containerPropertyName = propertyName;
                    }

                    if (!string.IsNullOrEmpty(this.containerPropertyName))
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
        }

        void SetupConstructorsGeneration()
        {
            if (mauiWrapperAttribute != null)
            {
                var constructorWithPropertiesValues = mauiWrapperAttribute.ConstructorArguments[MauiWrapperParams.ConstructorWithProperties].Values;
                if (!constructorWithPropertiesValues.IsDefaultOrEmpty)
                    this.constructorWithProperties = constructorWithPropertiesValues.Select(e => (string)e.Value).ToList();
                else
                    this.constructorWithProperties = new List<string>();
            }

            this.generateNoParamConstructor = true;
            if (mainSymbol.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0 && !e.IsImplicitlyDeclared) != null)
                this.generateNoParamConstructor = false;

            if (IsWrappedType)
            {
                if (WrappedType.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0) == null)
                    this.generateNoParamConstructor = false;
            }

            this.generateAdditionalConstructors =
                    mainSymbol.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0 && !e.IsImplicitlyDeclared) != null ||
                    this.generateNoParamConstructor;
        }

        // ------ normalized name ------

        public static string GetNormalizedName(INamedTypeSymbol type)
        {
            var tail = type.IsGenericType ? $"{type.TypeArguments.FirstOrDefault().Name}" : "";
            var prefix = type.ContainingNamespace.ToDisplayString().Contains(CompatibilityString) ? CompatibilityString : "";
            return $"{prefix}{type.Name}{tail}";
        }

        public string GetNormalizedName()
        {
            var type = IsWrappedType ? WrappedType : mainSymbol;
            return GetNormalizedName(type);
        }

        // ------ helpers ------

        public static AttributeData GetMauiWrapperAttributeData(INamedTypeSymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            return attributes.FirstOrDefault(e => e.AttributeClass.Name.Contains(MauiWrapperAttributeString));
        }

        public static INamedTypeSymbol GetWrappedType(AttributeData attributeData)
        {
            if (attributeData == null) return null;
            return attributeData.ConstructorArguments[MauiWrapperParams.WrappedType].Value as INamedTypeSymbol;
        }

        AttributeData GetAttachedInterfacesAttributeData()
        {
            var attributes = mainSymbol.GetAttributes();
            return attributes.FirstOrDefault(e => e.AttributeClass.Name.Contains(AttachedInterfacesAttributeString));
        }

        string FindContentPropertyName()
        {
            AttributeData attributeData = null;
            Helpers.LoopDownToObject(this.WrappedType, type =>
            {
                attributeData = type.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains(ContentPropertyAttributeString));
                return attributeData != null;
            });
            if (attributeData != null)
            {
                return (string)attributeData.ConstructorArguments[0].Value;
            }
            return null;
        }

        IPropertySymbol FindPropertySymbolWithName(string propertyName)
        {
            IPropertySymbol propertySymbol = null;
            Helpers.LoopDownToObject(this.WrappedType, type =>
            {
                propertySymbol = (IPropertySymbol)(type.GetMembers(propertyName).FirstOrDefault());
                return propertySymbol != null;
            });
            return propertySymbol;
        }
    }
}