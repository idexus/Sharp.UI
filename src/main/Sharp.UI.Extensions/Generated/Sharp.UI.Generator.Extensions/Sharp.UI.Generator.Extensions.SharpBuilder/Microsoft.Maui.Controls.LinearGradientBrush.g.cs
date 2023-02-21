﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class LinearGradientBrushExtension
    {
        public static T StartPoint<T>(this T obj,
            Microsoft.Maui.Graphics.Point startPoint)
            where T : Microsoft.Maui.Controls.LinearGradientBrush
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.LinearGradientBrush.StartPointProperty, startPoint);
            return obj;
        }
        
        public static T StartPoint<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Point>, ValueBuilder<Microsoft.Maui.Graphics.Point>> buidValue)
            where T : Microsoft.Maui.Controls.LinearGradientBrush
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Point>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.LinearGradientBrush.StartPointProperty, builder.GetValue());
            return obj;
        }
        
        public static T StartPoint<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Point>, BindingBuilder<Microsoft.Maui.Graphics.Point>> buidBinding)
            where T : Microsoft.Maui.Controls.LinearGradientBrush
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Graphics.Point>(obj, Microsoft.Maui.Controls.LinearGradientBrush.StartPointProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T EndPoint<T>(this T obj,
            Microsoft.Maui.Graphics.Point endPoint)
            where T : Microsoft.Maui.Controls.LinearGradientBrush
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.LinearGradientBrush.EndPointProperty, endPoint);
            return obj;
        }
        
        public static T EndPoint<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Point>, ValueBuilder<Microsoft.Maui.Graphics.Point>> buidValue)
            where T : Microsoft.Maui.Controls.LinearGradientBrush
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Point>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.LinearGradientBrush.EndPointProperty, builder.GetValue());
            return obj;
        }
        
        public static T EndPoint<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Point>, BindingBuilder<Microsoft.Maui.Graphics.Point>> buidBinding)
            where T : Microsoft.Maui.Controls.LinearGradientBrush
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Graphics.Point>(obj, Microsoft.Maui.Controls.LinearGradientBrush.EndPointProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
