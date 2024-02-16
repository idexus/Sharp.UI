//
// MIT License
// Copyright Pawel Krzywdzinski
//

namespace Sharp.UI.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        // ----- list fluent methods -----    
        void GenerateExtensionMethod_List(PropertyInfo info, string elementTypeName)
        {
            if (mainSymbol.IsSealed)
                GenerateExtensionMethod_List_Sealed(info, elementTypeName);
            else
                GenerateExtensionMethod_List_Normal(info, elementTypeName);
        }

        void GenerateExtensionMethod_List_Sealed(PropertyInfo info, string elementTypeName)
        {
            isExtensionMethodsGenerated = true;
            var tail = info.propertyTypeName.EndsWith("?") ? "?" : "";
            builder.Append($@"
        public static {info.symbolTypeName} {info.propertyName}(this {info.symbolTypeName} self,
            IList<{elementTypeName}> {info.camelCaseName})
        {{
            foreach (var item in {info.camelCaseName})
                {info.accessedWith}.{info.propertyName}{tail}.Add(item);
            return self;
        }}

        public static {info.symbolTypeName} {info.propertyName}(this {info.symbolTypeName} self,
            params {elementTypeName}[] {info.camelCaseName})
        {{
            foreach (var item in {info.camelCaseName})
                {info.accessedWith}.{info.propertyName}{tail}.Add(item);
            return self;
        }}
        ");
        }

        void GenerateExtensionMethod_List_Normal(PropertyInfo info, string elementTypeName)
        {
            isExtensionMethodsGenerated = true;
            var tail = info.propertyTypeName.EndsWith("?") ? "?" : "";
            builder.Append($@"
        public static T {info.propertyName}<T>(this T self,
            IList<{elementTypeName}> {info.camelCaseName})
            where T : {info.symbolTypeName}
        {{
            foreach (var item in {info.camelCaseName})
                {info.accessedWith}.{info.propertyName}{tail}.Add(item);
            return self;
        }}

        public static T {info.propertyName}<T>(this T self,
            params {elementTypeName}[] {info.camelCaseName})
            where T : {info.symbolTypeName}
        {{
            foreach (var item in {info.camelCaseName})
                {info.accessedWith}.{info.propertyName}{tail}.Add(item);
            return self;
        }}
        ");
        }

    }
}