﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class WebViewExtension
    {
        public static T Cookies<T>(this T obj,
            System.Net.CookieContainer cookies)
            where T : Microsoft.Maui.Controls.WebView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.WebView.CookiesProperty, cookies);
            return obj;
        }
        
        public static T Cookies<T>(this T obj,
            System.Func<ValueBuilder<System.Net.CookieContainer>, ValueBuilder<System.Net.CookieContainer>> buidValue)
            where T : Microsoft.Maui.Controls.WebView
        {
            var builder = buidValue(new ValueBuilder<System.Net.CookieContainer>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.WebView.CookiesProperty, builder.GetValue());
            return obj;
        }
        
        public static T Cookies<T>(this T obj,
            System.Func<BindingBuilder<System.Net.CookieContainer>, BindingBuilder<System.Net.CookieContainer>> buidBinding)
            where T : Microsoft.Maui.Controls.WebView
        {
            var builder = buidBinding(new BindingBuilder<System.Net.CookieContainer>(obj, Microsoft.Maui.Controls.WebView.CookiesProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Source<T>(this T obj,
            Microsoft.Maui.Controls.WebViewSource source)
            where T : Microsoft.Maui.Controls.WebView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.WebView.SourceProperty, source);
            return obj;
        }
        
        public static T Source<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.WebViewSource>, ValueBuilder<Microsoft.Maui.Controls.WebViewSource>> buidValue)
            where T : Microsoft.Maui.Controls.WebView
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.WebViewSource>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.WebView.SourceProperty, builder.GetValue());
            return obj;
        }
        
        public static T Source<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.WebViewSource>, BindingBuilder<Microsoft.Maui.Controls.WebViewSource>> buidBinding)
            where T : Microsoft.Maui.Controls.WebView
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.WebViewSource>(obj, Microsoft.Maui.Controls.WebView.SourceProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T OnNavigated<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.WebNavigatedEventArgs> handler)
            where T : Microsoft.Maui.Controls.WebView
        {
            obj.Navigated += handler;
            return obj;
        }
        
        public static T OnNavigated<T>(this T obj, System.Action<T> action)
            where T : Microsoft.Maui.Controls.WebView
        {
            obj.Navigated += (o, arg) => action(obj);
            return obj;
        }
        
        public static T OnNavigating<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.WebNavigatingEventArgs> handler)
            where T : Microsoft.Maui.Controls.WebView
        {
            obj.Navigating += handler;
            return obj;
        }
        
        public static T OnNavigating<T>(this T obj, System.Action<T> action)
            where T : Microsoft.Maui.Controls.WebView
        {
            obj.Navigating += (o, arg) => action(obj);
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
