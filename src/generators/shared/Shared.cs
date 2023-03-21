using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CodeMarkup.Maui.Generator
{
	public class Shared
	{
        public static string[] NotGenerateList = { "this[]", "Handler", "LogicalChildren" };

        public const string ContentPropertyAttributeString = "ContentPropertyAttribute";
        public const string BindablePropertiesAttributeString = "BindablePropertiesAttribute";
        public const string CodeMarkupAttributeString = "CodeMarkupAttribute";
        public const string AttachedPropertiesAttributeString = "AttachedPropertiesAttribute";
        public const string AttachedInterfacesAttributeString = "AttachedInterfacesAttribute";
        public const string AttachedNameAttributeString = "AttachedNameAttribute";

        public static AttributeData GetAttachedInterfacesAttributeData(INamedTypeSymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            return attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.AttachedInterfacesAttributeString));
        }

        public static string GetAttachedPropertyName(IPropertySymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.AttachedNameAttributeString));
            if (attributeData != null) return (string)attributeData.ConstructorArguments[0].Value;
            return $"{symbol.Name}Property";
        }
    }
}

