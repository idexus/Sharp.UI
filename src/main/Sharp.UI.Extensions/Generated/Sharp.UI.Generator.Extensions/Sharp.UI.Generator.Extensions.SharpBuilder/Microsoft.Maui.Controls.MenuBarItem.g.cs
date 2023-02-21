﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class MenuBarItemExtension
    {
        public static T Priority<T>(this T obj,
            int priority)
            where T : Microsoft.Maui.Controls.MenuBarItem
        {
            obj.Priority = priority;
            return obj;
        }
        
        public static T Priority<T>(this T obj,
            System.Func<ValueBuilder<int>, ValueBuilder<int>> buidValue)
            where T : Microsoft.Maui.Controls.MenuBarItem
        {
            var builder = buidValue(new ValueBuilder<int>());
            if (builder.ValueIsSet()) obj.Priority = builder.GetValue();
            return obj;
        }
        
        public static T IsEnabled<T>(this T obj,
            bool isEnabled)
            where T : Microsoft.Maui.Controls.MenuBarItem
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.MenuBarItem.IsEnabledProperty, isEnabled);
            return obj;
        }
        
        public static T IsEnabled<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buidValue)
            where T : Microsoft.Maui.Controls.MenuBarItem
        {
            var builder = buidValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.MenuBarItem.IsEnabledProperty, builder.GetValue());
            return obj;
        }
        
        public static T IsEnabled<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buidBinding)
            where T : Microsoft.Maui.Controls.MenuBarItem
        {
            var builder = buidBinding(new BindingBuilder<bool>(obj, Microsoft.Maui.Controls.MenuBarItem.IsEnabledProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Text<T>(this T obj,
            string text)
            where T : Microsoft.Maui.Controls.MenuBarItem
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.MenuBarItem.TextProperty, text);
            return obj;
        }
        
        public static T Text<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buidValue)
            where T : Microsoft.Maui.Controls.MenuBarItem
        {
            var builder = buidValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.MenuBarItem.TextProperty, builder.GetValue());
            return obj;
        }
        
        public static T Text<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buidBinding)
            where T : Microsoft.Maui.Controls.MenuBarItem
        {
            var builder = buidBinding(new BindingBuilder<string>(obj, Microsoft.Maui.Controls.MenuBarItem.TextProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
