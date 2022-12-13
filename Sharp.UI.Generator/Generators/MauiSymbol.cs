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
        public const string AttachedInterfacesAttributeString = "AttachedInterfaces";

        class MauiWrapperParams
        {
            public const int WrappedType = 0;
            public const int ConstructorWithProperties = 1;
            public const int ContainerPopertyName = 2;
        }

        private StringBuilder builder;

        INamedTypeSymbol mainSymbol;

        // attributes
        AttributeData mauiWrapperAttribute;
        AttributeData attachedInterfacesAttribute;

        // [MauiWrapper] parameters
        INamedTypeSymbol wrappedType = null;
        List<string> constructorWithProperties = null;
        string containerPropertyName = null;

        bool isWrappedType => wrappedType != null;

        // additional generation data
        bool generateAdditionalConstructors = false;
        bool generateNoParamConstructor = false;
        bool singleItemContainer = false;
        string containerOfTypeName = null;

        List<string> notGenerateList = null;
        string nameSpaceName;

        public MauiSymbol(INamedTypeSymbol symbol)
		{
            mainSymbol = symbol;

            // get attributes
            mauiWrapperAttribute = GetMauiWrapperAttributeData();
            attachedInterfacesAttribute = GetAttachedInterfacesAttributeData();

            wrappedType = mauiWrapperAttribute.ConstructorArguments[MauiWrapperParams.WrappedType].Value as INamedTypeSymbol;

            nameSpaceName = isWrappedType ? "Sharp.UI" : mainSymbol.ContainingNamespace.ToDisplayString();

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
            if (isWrappedType)
            {
                this.containerPropertyName = (string)(mauiWrapperAttribute.ConstructorArguments[MauiWrapperParams.ContainerPopertyName].Value);

                var isContainerThis = WrapBuilder.IsGenericIList(wrappedType, out var containerType);
                if (isContainerThis && wrappedType.IsSealed)
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

                        if (propertySymbol == null) throw new Exception($"No content property for: {wrappedType.Name}");

                        var mauiContainerType = (INamedTypeSymbol)((propertySymbol).Type);
                        if (WrapBuilder.IsGenericIList(mauiContainerType, out var ofTypeName))
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
            // [1] constructorWithProperties
            var constructorWithPropertiesValues = mauiWrapperAttribute.ConstructorArguments[MauiWrapperParams.ConstructorWithProperties].Values;
            if (!constructorWithPropertiesValues.IsDefaultOrEmpty)
                this.constructorWithProperties = constructorWithPropertiesValues.Select(e => (string)e.Value).ToList();
            else
                this.constructorWithProperties = new List<string>();

            this.generateNoParamConstructor = true;
            if (mainSymbol.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0 && !e.IsImplicitlyDeclared) != null)
                this.generateNoParamConstructor = false;

            if (isWrappedType)
            {
                if (wrappedType.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0) == null)
                    this.generateNoParamConstructor = false;
            }

            this.generateAdditionalConstructors =
                    mainSymbol.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0 && !e.IsImplicitlyDeclared) != null ||
                    this.generateNoParamConstructor;
        }

        // ------ helpers ------

        AttributeData GetMauiWrapperAttributeData()
        {
            var attributes = mainSymbol.GetAttributes();
            return attributes.FirstOrDefault(e => e.AttributeClass.Name.Contains(MauiWrapperAttributeString));
        }

        AttributeData GetAttachedInterfacesAttributeData()
        {
            var attributes = mainSymbol.GetAttributes();
            return attributes.FirstOrDefault(e => e.AttributeClass.Name.Contains("AttachedInterfaces"));
        }

        string FindContentPropertyName()
        {
            AttributeData attributeData = null;
            Helpers.LoopDownToObject(this.wrappedType, type =>
            {
                attributeData = type.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains("ContentProperty"));
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
            Helpers.LoopDownToObject(this.wrappedType, type =>
            {
                propertySymbol = (IPropertySymbol)(type.GetMembers(propertyName).FirstOrDefault());
                return propertySymbol != null;
            });
            return propertySymbol;
        }
    }
}