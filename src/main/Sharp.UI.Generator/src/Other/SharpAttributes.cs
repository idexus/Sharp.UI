using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator
{
	public static class SharpAttributes
	{
        public const string ContentPropertyAttributeString = "ContentPropertyAttribute";
        public const string BindablePropertiesAttributeString = "BindablePropertiesAttribute";
        public const string SharpObjectAttributeString = "SharpObjectAttribute";
        public const string AttachedPropertiesAttributeString = "AttachedPropertiesAttribute";
        public const string AttachedInterfacesAttributeString = "AttachedInterfacesAttribute";
        public const string AttachedNameAttributeString = "AttachedNameAttribute";
        public const string DefaultValueAttributeString = "DefaultValueAttribute";
        public const string PropertyCallbackAttributeString = "PropertyCallbacksAttribute";

        public static IPropertySymbol GetPropertyFromInterface(INamedTypeSymbol symbol, string name)
        {
            if (Helpers.IsBindableObject(symbol))
            {
                var bindableInterfaces = symbol
                    .Interfaces
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(BindablePropertiesAttributeString, StringComparison.Ordinal)) != null);

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

        public static IPropertySymbol FindPropertySymbolWithName(INamedTypeSymbol symbol, string propertyName)
        {
            IPropertySymbol propertySymbol = GetPropertyFromInterface(symbol, propertyName);
            if (propertySymbol == null)
            {
                Helpers.LoopDownToObject(symbol, type =>
                {
                    propertySymbol = (IPropertySymbol)(type.GetMembers(propertyName).FirstOrDefault());
                    return propertySymbol != null;
                });
            }
            return propertySymbol;
        }
        
        public static AttributeData GetAttachedInterfacesAttributeData(INamedTypeSymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            return attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedInterfacesAttributeString));
        }

        public static string GetAttachedPropertyName(IPropertySymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedNameAttributeString));
            if (attributeData != null) return (string)attributeData.ConstructorArguments[0].Value;
            return $"{symbol.Name}Property";
        }

        public static Dictionary<string, string> GetPropertyCallbacks(ISymbol symbol)
        {
            var data = new Dictionary<string, string>();
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(PropertyCallbackAttributeString, StringComparison.Ordinal));
            if (attributeData != null)
            {
                var arguments = attributeData.ConstructorArguments;
                if (arguments[0].Value != null)
                    data["propertyChanged"] = (string)arguments[0].Value;
                if (arguments[1].Value != null)
                    data["propertyChanging"] = (string)arguments[1].Value;
                if (arguments[2].Value != null)
                    data["validateValue"] = (string)arguments[2].Value;
                if (arguments[3].Value != null)
                    data["coerceValue"] = (string)arguments[3].Value;
                if (arguments[4].Value != null)
                    data["defaultValueCreator"] = (string)arguments[4].Value;
                if (data.Count() == 0)
                    throw new ArgumentException($"PropertyCallback attribute must have minmium one attribute defined, symbol: {symbol.ToDisplayString()}");
            }
            return data;
        }

        public static string GetDefaultValueString(ISymbol symbol, string typeName)
        {
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(DefaultValueAttributeString, StringComparison.Ordinal));
            if (attributeData != null)
            {

                var value = attributeData.ConstructorArguments[0].Value.ToString();
                if (typeName.Equals("string", StringComparison.Ordinal))
                    value = $"\"{value}\"";
                if (typeName.Equals("double", StringComparison.Ordinal) || typeName.Equals("float", StringComparison.Ordinal))
                    value = value.Replace(",", ".");
                return value;
            }
            return null;
        }

        public static bool IsNewPropertyContainer(INamedTypeSymbol symbol)
        {
            if (symbol.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(ContentPropertyAttributeString)) == null)
                return false;

            bool isNewContainer = false;
            Helpers.LoopDownToObject(symbol.BaseType, type =>
            {
                isNewContainer = type.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(ContentPropertyAttributeString)) != null;
                return isNewContainer;
            });
            return isNewContainer;
        }

        public static string GetContentPropertyNameFor(INamedTypeSymbol symbol)
        {
            var attributeData = symbol.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(ContentPropertyAttributeString));
            return attributeData != null ? (string)attributeData.ConstructorArguments[0].Value : null;
        }

        public static string FindContentPropertyName(INamedTypeSymbol symbol)
        {
            string name = null;
            Helpers.LoopDownToObject(symbol, type =>
            {
                name = GetContentPropertyNameFor(type);
                return name != null;
            });
            return name;
        }
    }
}

