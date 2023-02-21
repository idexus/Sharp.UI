﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class GridItemsLayoutExtension
    {
        public static T Span<T>(this T obj,
            int span)
            where T : Microsoft.Maui.Controls.GridItemsLayout
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.GridItemsLayout.SpanProperty, span);
            return obj;
        }
        
        public static T Span<T>(this T obj,
            System.Func<ValueBuilder<int>, ValueBuilder<int>> buidValue)
            where T : Microsoft.Maui.Controls.GridItemsLayout
        {
            var builder = buidValue(new ValueBuilder<int>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.GridItemsLayout.SpanProperty, builder.GetValue());
            return obj;
        }
        
        public static T Span<T>(this T obj,
            System.Func<BindingBuilder<int>, BindingBuilder<int>> buidBinding)
            where T : Microsoft.Maui.Controls.GridItemsLayout
        {
            var builder = buidBinding(new BindingBuilder<int>(obj, Microsoft.Maui.Controls.GridItemsLayout.SpanProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T VerticalItemSpacing<T>(this T obj,
            double verticalItemSpacing)
            where T : Microsoft.Maui.Controls.GridItemsLayout
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.GridItemsLayout.VerticalItemSpacingProperty, verticalItemSpacing);
            return obj;
        }
        
        public static T VerticalItemSpacing<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buidValue)
            where T : Microsoft.Maui.Controls.GridItemsLayout
        {
            var builder = buidValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.GridItemsLayout.VerticalItemSpacingProperty, builder.GetValue());
            return obj;
        }
        
        public static T VerticalItemSpacing<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buidBinding)
            where T : Microsoft.Maui.Controls.GridItemsLayout
        {
            var builder = buidBinding(new BindingBuilder<double>(obj, Microsoft.Maui.Controls.GridItemsLayout.VerticalItemSpacingProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T HorizontalItemSpacing<T>(this T obj,
            double horizontalItemSpacing)
            where T : Microsoft.Maui.Controls.GridItemsLayout
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.GridItemsLayout.HorizontalItemSpacingProperty, horizontalItemSpacing);
            return obj;
        }
        
        public static T HorizontalItemSpacing<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buidValue)
            where T : Microsoft.Maui.Controls.GridItemsLayout
        {
            var builder = buidValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.GridItemsLayout.HorizontalItemSpacingProperty, builder.GetValue());
            return obj;
        }
        
        public static T HorizontalItemSpacing<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buidBinding)
            where T : Microsoft.Maui.Controls.GridItemsLayout
        {
            var builder = buidBinding(new BindingBuilder<double>(obj, Microsoft.Maui.Controls.GridItemsLayout.HorizontalItemSpacingProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore