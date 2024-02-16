//
// MIT License
// Copyright Pawel Krzywdzinski
//

namespace Sharp.UI.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        void GenerateExtensionMethod_GetValue(PropertyInfo info)
        {
            if (mainSymbol.IsSealed)
                GenerateExtensionMethod_GetValue_Sealed(info);
            else
                GenerateExtensionMethod_GetValue_Normal(info);
        }

        void GenerateExtensionMethod_GetValue_Sealed(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static {info.propertyTypeName} Get{info.propertyName}Value<T>(this {info.symbolTypeName} self)
        {{
            return ({info.propertyTypeName})self.GetValue({info.BindablePropertyName});
        }}
        ");
        }

        void GenerateExtensionMethod_GetValue_Normal(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static {info.propertyTypeName} Get{info.propertyName}Value<T>(this T self)
            where T : {info.symbolTypeName}
        {{
            return ({info.propertyTypeName})self.GetValue({info.BindablePropertyName});
        }}
        ");
        }
    }
}