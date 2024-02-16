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
        // binding builder (Setters)

        void GenerateExtensionMethod_SettersBuilder(PropertyInfo info)
        {
            if (mainSymbol.IsSealed)
                GenerateExtensionMethod_SettersBuilder_Sealed(info);
            else
                GenerateExtensionMethod_SettersBuilder_Normal(info);
        }

        void GenerateExtensionMethod_SettersBuilder_Sealed(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static SettersContext<{info.symbolTypeName}> {info.propertyName}(this SettersContext<{info.symbolTypeName}> self, Func<PropertySettersContext<{info.propertyTypeName}>, IPropertySettersBuilder<{info.propertyTypeName}>> configure)
        {{
            var context = new PropertySettersContext<{info.propertyTypeName}>(self.XamlSetters, {info.BindablePropertyName});
            configure(context).Build();
            return self;
        }}
        ");
        }

        void GenerateExtensionMethod_SettersBuilder_Normal(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static SettersContext<T> {info.propertyName}<T>(this SettersContext<T> self, Func<PropertySettersContext<{info.propertyTypeName}>, IPropertySettersBuilder<{info.propertyTypeName}>> configure)
            where T : {info.symbolTypeName}
        {{
            var context = new PropertySettersContext<{info.propertyTypeName}>(self.XamlSetters, {info.BindablePropertyName});
            configure(context).Build();
            return self;
        }}
        ");
        }
    }
}