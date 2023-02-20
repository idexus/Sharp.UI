using System;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator
{
	public class Shared
	{
        public static string[] NotGenerateList = { "this[]", "Handler", "LogicalChildren" };

        public const string ContentPropertyAttributeString = "ContentPropertyAttribute";
        public const string BindablePropertiesAttributeString = "BindablePropertiesAttribute";
        public const string SharpObjectAttributeString = "SharpObjectAttribute";

        public static string GetUsingString(ISymbol symbol)
        {
            if (!symbol.ContainingNamespace.ToDisplayString().Equals("Sharp.UI"))
                return $@"using Sharp.UI;

    ";
            return "";
        }
    }
}

