//
// MIT License
// Copyright Pawel Krzywdzinski
//

namespace Sharp.UI.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        // binding builder

        void GenerateExtensionMethod_BindablePropertyBuilder(PropertyInfo info)
        {
            if (mainSymbol.IsSealed)
                GenerateExtensionMethod_BindablePropertyBuilder_Sealed(info);
            else
                GenerateExtensionMethod_BindablePropertyBuilder_Normal(info);
        }

        void GenerateExtensionMethod_BindablePropertyBuilder_Sealed(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static {info.symbolTypeName} {info.propertyName}(this {info.symbolTypeName} self, Func<PropertyContext<{info.propertyTypeName}>, IPropertyBuilder<{info.propertyTypeName}>> configure)
        {{
            var context = new PropertyContext<{info.propertyTypeName}>(self, {info.BindablePropertyName});
            configure(context).Build();
            return self;
        }}
        ");
        }

        void GenerateExtensionMethod_BindablePropertyBuilder_Normal(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T self, Func<PropertyContext<{info.propertyTypeName}>, IPropertyBuilder<{info.propertyTypeName}>> configure)
            where T : {info.symbolTypeName}
        {{
            var context = new PropertyContext<{info.propertyTypeName}>(self, {info.BindablePropertyName});
            configure(context).Build();
            return self;
        }}
        ");
        }
    }
}