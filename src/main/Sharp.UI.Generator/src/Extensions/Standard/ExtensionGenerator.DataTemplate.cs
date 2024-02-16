//
// MIT License
// Copyright Pawel Krzywdzinski
//


namespace Sharp.UI.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        void GenerateExtensionMethod_DataTemplate(PropertyInfo info)
        {
            if (mainSymbol.IsSealed)
                GenerateExtensionMethod_DataTemplate_Sealed(info);
            else
                GenerateExtensionMethod_DataTemplate_Normal(info);
        }

        void GenerateExtensionMethod_DataTemplate_Sealed(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static {info.symbolTypeName} {info.propertyName}<T>(this {info.symbolTypeName} self, System.Func<object> loadTemplate)
        {{
            {info.dataTemplateAssignmentString}
            return self;
        }}
        ");
        }

        void GenerateExtensionMethod_DataTemplate_Normal(PropertyInfo info)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T {info.propertyName}<T>(this T self, System.Func<object> loadTemplate)
            where T : {info.symbolTypeName}
        {{
            {info.dataTemplateAssignmentString}
            return self;
        }}
        ");
        }
    }
}