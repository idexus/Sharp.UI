//
// MIT License
// Copyright Pawel Krzywdzinski
//

namespace Sharp.UI.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        void GenerateExtensionMethod_AnimateTo(PropertyInfo info, string transformationName)
        {
            isExtensionMethodsGenerated = true;

            if (mainSymbol.IsSealed)
                builder.Append($@"
        public static Task<bool> Animate{info.propertyName}To(this {info.symbolTypeName} self, {info.propertyTypeName} value, uint length = 250, Easing? easing = null)");
            else
                builder.Append($@"
        public static Task<bool> Animate{info.propertyName}To<T>(this T self, {info.propertyTypeName} value, uint length = 250, Easing? easing = null)
            where T : {info.symbolTypeName}");


            builder.Append($@"
        {{
            {info.propertyTypeName} fromValue = self.{info.propertyName};
            var transform = (double t) => Transformations.{transformationName}(fromValue, value, t);
            var callback = ({info.propertyTypeName} actValue) => {{ self.{info.propertyName} = actValue; }};
            return Transformations.AnimateAsync<{info.propertyTypeName}>(self, ""Animate{info.propertyName}To"", transform, callback, length, easing);
        }}
        ");
        }
    }
}