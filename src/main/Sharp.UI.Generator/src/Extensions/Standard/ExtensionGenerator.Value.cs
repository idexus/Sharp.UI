//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        // value

        void GenerateExtensionMethod_Value(PropertyInfo info)
        {
            if (mainSymbol.IsSealed)
                GenerateExtensionMethod_Value_Sealed(info);
            else
                GenerateExtensionMethod_Value_Normal(info);
        }

        void GenerateExtensionMethod_Value_Sealed(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static {info.symbolTypeName} {info.propertyName}(this {info.symbolTypeName} self,
            {info.propertyTypeName} {info.camelCaseName})
        {{
            {info.valueAssignmentString}
            return self;
        }}
        ");
        }

        void GenerateExtensionMethod_Value_Normal(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T self,
            {info.propertyTypeName} {info.camelCaseName})
            where T : {info.symbolTypeName}
        {{
            {info.valueAssignmentString}
            return self;
        }}
        ");
        }
    }
}