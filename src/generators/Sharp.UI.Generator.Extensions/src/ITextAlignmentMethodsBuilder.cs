using System;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        void GenerateExtensionMethods_ITextAlignment(ISymbol symbol)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"

        public static T CenterTextHorizontally<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, HorizontalAlignment.Center);
            return obj;
        }}

        public static T CenterTextVertically<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, VerticalAlignment.Center);
            return obj;
        }}

        public static T CenterText<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, HorizontalAlignment.Center);
            obj.SetValueOrSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, VerticalAlignment.Center);
            return obj;
        }}

        public static T AlignTextTop<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, VerticalAlignment.Top);
            return obj;
        }}

        public static T AlignTextBottom<T>(this T obj)
            where T : {symbol.ToDisplayString()}, Microsoft.Maui.ITextAlignment
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, VerticalAlignment.Bottom);
            return obj;
        }}

        public static T AlignTextTopLeft<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, VerticalAlignment.Top);
            obj.SetValueOrSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, HorizontalAlignment.Left);
            return obj;
        }}

        public static T AlignTextBottomLeft<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, VerticalAlignment.Bottom);
            obj.SetValueOrSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, HorizontalAlignment.Left);
            return obj;
        }}

        public static T AlignTextTopRight<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, VerticalAlignment.Top);
            obj.SetValueOrSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, HorizontalAlignment.Right);
            return obj;
        }}

        public static T AlignTextBottomRight<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.VerticalTextAlignmentProperty, VerticalAlignment.Bottom);
            obj.SetValueOrSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, HorizontalAlignment.Right);
            return obj;
        }}

        public static T AlignTextLeft<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, HorizontalAlignment.Left);
            return obj;
        }}

        public static T AlignTextRight<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, HorizontalAlignment.Right);
            return obj;
        }}

        public static T AlignTextJustified<T>(this T obj)
            where T : {symbol.ToDisplayString()}
        {{
            obj.SetValueOrSetter({symbol.ToDisplayString()}.HorizontalTextAlignmentProperty, HorizontalAlignment.Justified);
            return obj;
        }}

        ");
        }
    }
}

