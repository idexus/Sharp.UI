//
// MIT License
// Copyright Pawel Krzywdzinski
//
namespace Sharp.UI.Generator.Extensions
{
    internal partial class ExtensionGenerator
    {
        void GenerateExtensionMethods_ITextAlignment()
        {
            var type = model.SymbolTypeName;

            builder.Append($@"
        public static T TextCenterHorizontal<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.HorizontalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }}

        public static T TextCenterVertical<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }}

        public static T TextCenter<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.HorizontalTextAlignmentProperty, TextAlignment.Center);
            self.SetValue({type}.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }}

        public static T TextTop<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.VerticalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }}

        public static T TextBottom<T>(this T self)
            where T : {type}, Microsoft.Maui.ITextAlignment
        {{
            self.SetValue({type}.VerticalTextAlignmentProperty, TextAlignment.End);
            return self;
        }}

        public static T TextTopStart<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValue({type}.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }}

        public static T TextBottomStart<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValue({type}.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }}

        public static T TextTopEnd<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValue({type}.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }}

        public static T TextBottomEnd<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValue({type}.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }}

        public static T TextStart<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }}

        public static T TextEnd<T>(this T self)
            where T : {type}
        {{
            self.SetValue({type}.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }}
");
        }
    }
}
