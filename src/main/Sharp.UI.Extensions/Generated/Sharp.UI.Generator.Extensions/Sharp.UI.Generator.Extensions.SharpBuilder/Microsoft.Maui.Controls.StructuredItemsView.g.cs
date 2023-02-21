﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class StructuredItemsViewExtension
    {
        public static T Header<T>(this T obj,
            object header)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.HeaderProperty, header);
            return obj;
        }
        
        public static T Header<T>(this T obj,
            System.Func<ValueBuilder<object>, ValueBuilder<object>> buidValue)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidValue(new ValueBuilder<object>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.HeaderProperty, builder.GetValue());
            return obj;
        }
        
        public static T Header<T>(this T obj,
            System.Func<BindingBuilder<object>, BindingBuilder<object>> buidBinding)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidBinding(new BindingBuilder<object>(obj, Microsoft.Maui.Controls.StructuredItemsView.HeaderProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T HeaderTemplate<T>(this T obj,
            Microsoft.Maui.Controls.DataTemplate headerTemplate)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.HeaderTemplateProperty, headerTemplate);
            return obj;
        }
        
        public static T HeaderTemplate<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.DataTemplate>, ValueBuilder<Microsoft.Maui.Controls.DataTemplate>> buidValue)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.DataTemplate>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.HeaderTemplateProperty, builder.GetValue());
            return obj;
        }
        
        public static T HeaderTemplate<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.DataTemplate>, BindingBuilder<Microsoft.Maui.Controls.DataTemplate>> buidBinding)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.DataTemplate>(obj, Microsoft.Maui.Controls.StructuredItemsView.HeaderTemplateProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T HeaderTemplate<T>(this T obj, System.Func<object> loadTemplate)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            obj.HeaderTemplate = new DataTemplate(loadTemplate);
            return obj;
        }
        
        public static T Footer<T>(this T obj,
            object footer)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.FooterProperty, footer);
            return obj;
        }
        
        public static T Footer<T>(this T obj,
            System.Func<ValueBuilder<object>, ValueBuilder<object>> buidValue)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidValue(new ValueBuilder<object>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.FooterProperty, builder.GetValue());
            return obj;
        }
        
        public static T Footer<T>(this T obj,
            System.Func<BindingBuilder<object>, BindingBuilder<object>> buidBinding)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidBinding(new BindingBuilder<object>(obj, Microsoft.Maui.Controls.StructuredItemsView.FooterProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T FooterTemplate<T>(this T obj,
            Microsoft.Maui.Controls.DataTemplate footerTemplate)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.FooterTemplateProperty, footerTemplate);
            return obj;
        }
        
        public static T FooterTemplate<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.DataTemplate>, ValueBuilder<Microsoft.Maui.Controls.DataTemplate>> buidValue)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.DataTemplate>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.FooterTemplateProperty, builder.GetValue());
            return obj;
        }
        
        public static T FooterTemplate<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.DataTemplate>, BindingBuilder<Microsoft.Maui.Controls.DataTemplate>> buidBinding)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.DataTemplate>(obj, Microsoft.Maui.Controls.StructuredItemsView.FooterTemplateProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T FooterTemplate<T>(this T obj, System.Func<object> loadTemplate)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            obj.FooterTemplate = new DataTemplate(loadTemplate);
            return obj;
        }
        
        public static T ItemsLayout<T>(this T obj,
            Microsoft.Maui.Controls.IItemsLayout itemsLayout)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.ItemsLayoutProperty, itemsLayout);
            return obj;
        }
        
        public static T ItemsLayout<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.IItemsLayout>, ValueBuilder<Microsoft.Maui.Controls.IItemsLayout>> buidValue)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.IItemsLayout>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.ItemsLayoutProperty, builder.GetValue());
            return obj;
        }
        
        public static T ItemsLayout<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.IItemsLayout>, BindingBuilder<Microsoft.Maui.Controls.IItemsLayout>> buidBinding)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.IItemsLayout>(obj, Microsoft.Maui.Controls.StructuredItemsView.ItemsLayoutProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T ItemSizingStrategy<T>(this T obj,
            Microsoft.Maui.Controls.ItemSizingStrategy itemSizingStrategy)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.ItemSizingStrategyProperty, itemSizingStrategy);
            return obj;
        }
        
        public static T ItemSizingStrategy<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.ItemSizingStrategy>, ValueBuilder<Microsoft.Maui.Controls.ItemSizingStrategy>> buidValue)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.ItemSizingStrategy>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.StructuredItemsView.ItemSizingStrategyProperty, builder.GetValue());
            return obj;
        }
        
        public static T ItemSizingStrategy<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.ItemSizingStrategy>, BindingBuilder<Microsoft.Maui.Controls.ItemSizingStrategy>> buidBinding)
            where T : Microsoft.Maui.Controls.StructuredItemsView
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.ItemSizingStrategy>(obj, Microsoft.Maui.Controls.StructuredItemsView.ItemSizingStrategyProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore