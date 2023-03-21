using System;
using Microsoft.CodeAnalysis;

namespace CodeMarkup.Maui.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        void GenerateExtensionMethods_ITextAlignment(ISymbol symbol)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"

        public static T TextCenterHorizontal<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }}

        public static T TextCenterVertical<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }}

        public static T TextCenter<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, TextAlignment.Center);
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }}

        public static T TextTop<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }}

        public static T TextBottom<T>(this T self)
            where T : {symbol.ToDisplayString()}, Microsoft.Maui.ITextAlignment
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, TextAlignment.End);
            return self;
        }}

        public static T TextTopStart<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }}

        public static T TextBottomStart<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }}

        public static T TextTopEnd<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }}

        public static T TextBottomEnd<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }}

        public static T TextStart<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }}

        public static T TextEnd<T>(this T self)
            where T : {symbol.ToDisplayString()}
        {{
            self.SetValueOrAddSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }}

        ");
        }
    }
}

