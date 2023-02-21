﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class ActivityIndicatorExtension
    {
        public static T Color<T>(this T obj,
            Microsoft.Maui.Graphics.Color color)
            where T : Microsoft.Maui.Controls.ActivityIndicator
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.ActivityIndicator.ColorProperty, color);
            return obj;
        }
        
        public static T Color<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Microsoft.Maui.Controls.ActivityIndicator
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.ActivityIndicator.ColorProperty, builder.GetValue());
            return obj;
        }
        
        public static T Color<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buidBinding)
            where T : Microsoft.Maui.Controls.ActivityIndicator
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(obj, Microsoft.Maui.Controls.ActivityIndicator.ColorProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T IsRunning<T>(this T obj,
            bool isRunning)
            where T : Microsoft.Maui.Controls.ActivityIndicator
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.ActivityIndicator.IsRunningProperty, isRunning);
            return obj;
        }
        
        public static T IsRunning<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buidValue)
            where T : Microsoft.Maui.Controls.ActivityIndicator
        {
            var builder = buidValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.ActivityIndicator.IsRunningProperty, builder.GetValue());
            return obj;
        }
        
        public static T IsRunning<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buidBinding)
            where T : Microsoft.Maui.Controls.ActivityIndicator
        {
            var builder = buidBinding(new BindingBuilder<bool>(obj, Microsoft.Maui.Controls.ActivityIndicator.IsRunningProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore