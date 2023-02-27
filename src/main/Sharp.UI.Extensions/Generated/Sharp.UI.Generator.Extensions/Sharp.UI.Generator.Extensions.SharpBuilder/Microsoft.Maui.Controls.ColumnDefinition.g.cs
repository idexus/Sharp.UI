﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class ColumnDefinitionExtension
    {
        public static Microsoft.Maui.Controls.ColumnDefinition Width(this Microsoft.Maui.Controls.ColumnDefinition self,
            Microsoft.Maui.GridLength width)
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ColumnDefinition.WidthProperty, width);
            return self;
        }
        
        public static Microsoft.Maui.Controls.ColumnDefinition Width(this Microsoft.Maui.Controls.ColumnDefinition self, Func<PropertyContext<Microsoft.Maui.GridLength>, IPropertyBuilder<Microsoft.Maui.GridLength>> configure)
        {
            var context = new PropertyContext<Microsoft.Maui.GridLength>(self, Microsoft.Maui.Controls.ColumnDefinition.WidthProperty);
            configure(context).Build();
            return self;
        }
        
        public static Microsoft.Maui.Controls.ColumnDefinition OnSizeChanged(this Microsoft.Maui.Controls.ColumnDefinition self, System.EventHandler handler)
        {
            self.SizeChanged += handler;
            return self;
        }
        
        public static Microsoft.Maui.Controls.ColumnDefinition OnSizeChanged(this Microsoft.Maui.Controls.ColumnDefinition self, System.Action<Microsoft.Maui.Controls.ColumnDefinition> action)
        {
            self.SizeChanged += (o, arg) => action(self);
            return self;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
