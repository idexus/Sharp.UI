//
// MIT License
// Copyright Pawel Krzywdzinski
//

namespace Sharp.UI.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        void GenerateExtensionMethod_Setters(PropertyInfo info)
        {
            if (mainSymbol.IsSealed)
                GenerateExtensionMethod_Setters_Sealed(info);
            else
                GenerateExtensionMethod_Setters_Normal(info);
        }

        void GenerateExtensionMethod_Setters_Sealed(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static SettersContext<{info.symbolTypeName}> {info.propertyName}(this SettersContext<{info.symbolTypeName}> self,
            {info.propertyTypeName} {info.camelCaseName})
        {{
            self.XamlSetters.Add(new Setter {{ Property = {info.BindablePropertyName}, Value = {info.camelCaseName} }});
            return self;
        }}
        ");
        }

        void GenerateExtensionMethod_Setters_Normal(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static SettersContext<T> {info.propertyName}<T>(this SettersContext<T> self,
            {info.propertyTypeName} {info.camelCaseName})
            where T : {info.symbolTypeName}
        {{
            self.XamlSetters.Add(new Setter {{ Property = {info.BindablePropertyName}, Value = {info.camelCaseName} }});
            return self;
        }}
        ");
        }
    }
}