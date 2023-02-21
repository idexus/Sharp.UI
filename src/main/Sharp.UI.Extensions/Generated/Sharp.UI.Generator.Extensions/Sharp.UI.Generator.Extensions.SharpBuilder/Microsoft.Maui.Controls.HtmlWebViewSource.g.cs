﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class HtmlWebViewSourceExtension
    {
        public static T BaseUrl<T>(this T obj,
            string baseUrl)
            where T : Microsoft.Maui.Controls.HtmlWebViewSource
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.HtmlWebViewSource.BaseUrlProperty, baseUrl);
            return obj;
        }
        
        public static T BaseUrl<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buidValue)
            where T : Microsoft.Maui.Controls.HtmlWebViewSource
        {
            var builder = buidValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.HtmlWebViewSource.BaseUrlProperty, builder.GetValue());
            return obj;
        }
        
        public static T BaseUrl<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buidBinding)
            where T : Microsoft.Maui.Controls.HtmlWebViewSource
        {
            var builder = buidBinding(new BindingBuilder<string>(obj, Microsoft.Maui.Controls.HtmlWebViewSource.BaseUrlProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Html<T>(this T obj,
            string html)
            where T : Microsoft.Maui.Controls.HtmlWebViewSource
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.HtmlWebViewSource.HtmlProperty, html);
            return obj;
        }
        
        public static T Html<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buidValue)
            where T : Microsoft.Maui.Controls.HtmlWebViewSource
        {
            var builder = buidValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.HtmlWebViewSource.HtmlProperty, builder.GetValue());
            return obj;
        }
        
        public static T Html<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buidBinding)
            where T : Microsoft.Maui.Controls.HtmlWebViewSource
        {
            var builder = buidBinding(new BindingBuilder<string>(obj, Microsoft.Maui.Controls.HtmlWebViewSource.HtmlProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
