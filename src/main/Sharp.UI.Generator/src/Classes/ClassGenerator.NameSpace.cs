//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using Microsoft.CodeAnalysis;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Sharp.UI.Generator.Classes
{
    public partial class ClassGenerator
    {
        public string GetUsingString()
        {
            if (mainSymbol.ContainingNamespace.ToDisplayString().Equals("Sharp.UI"))
                return $@"using Sharp.UI;

    ";
            return "";
        }

        string BaseString()
        {
            if (containerOfTypeName != null)
            {
                if (isSingleItemContainer)
                    return $" : IEnumerable";
                else
                    return $" : IList<{containerOfTypeName}>";
            }
            return "";
        }

        void GenerateClassNamespace()
        {
            this.GenerateContainerUsingsIfNeeded();
            builder.AppendLine($@"
namespace {mainSymbol.ContainingNamespace.ToDisplayString()}
{{
	{GetUsingString()}public partial class {fullSymbolName}{BaseString()}
	{{");
            GenerateClassBody();
            builder.AppendLine($@"
    }}
}}");
        }

        // ------- container usings -------

        void GenerateContainerUsingsIfNeeded()
        {
            if (containerOfTypeName != null)
                builder.AppendLine($@"
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
");
        }

        // ------- base string -------


        void GenerateClassBody()
        {
            GenerateConstructors();
            GenerateSingleItemContainer();
            GenerateCollectionContainer();
            GenerateBindableProperties();
        }
    }
}