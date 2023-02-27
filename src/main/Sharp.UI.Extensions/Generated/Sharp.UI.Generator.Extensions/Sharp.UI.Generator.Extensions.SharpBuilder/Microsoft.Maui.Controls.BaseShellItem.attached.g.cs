﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class BaseShellItemExtension
    {
        public static T ShellItemTemplate<T>(this T self,
            Microsoft.Maui.Controls.DataTemplate shellItemTemplate)
            where T : Microsoft.Maui.Controls.BaseShellItem
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Shell.ItemTemplateProperty, shellItemTemplate);
            return self;
        }
        
        public static T ShellItemTemplate<T>(this T self, Func<PropertyContext<Microsoft.Maui.Controls.DataTemplate>, IPropertyBuilder<Microsoft.Maui.Controls.DataTemplate>> configure)
            where T : Microsoft.Maui.Controls.BaseShellItem
        {
            var context = new PropertyContext<Microsoft.Maui.Controls.DataTemplate>(self, Microsoft.Maui.Controls.Shell.ItemTemplateProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ShellItemTemplate<T>(this T self, System.Func<object> loadTemplate)
            where T : Microsoft.Maui.Controls.BaseShellItem
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Shell.ItemTemplateProperty, new DataTemplate(loadTemplate));
            return self;
        }
        
        public static Microsoft.Maui.Controls.DataTemplate GetShellItemTemplateValue<T>(this T self)
            where T : Microsoft.Maui.Controls.BaseShellItem
        {
            return (Microsoft.Maui.Controls.DataTemplate)self.GetValue(Microsoft.Maui.Controls.Shell.ItemTemplateProperty);
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
