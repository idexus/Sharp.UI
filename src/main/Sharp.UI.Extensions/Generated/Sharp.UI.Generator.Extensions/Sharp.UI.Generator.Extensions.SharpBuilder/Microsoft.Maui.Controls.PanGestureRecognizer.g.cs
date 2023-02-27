﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class PanGestureRecognizerExtension
    {
        public static T TouchPoints<T>(this T self,
            int touchPoints)
            where T : Microsoft.Maui.Controls.PanGestureRecognizer
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.PanGestureRecognizer.TouchPointsProperty, touchPoints);
            return self;
        }
        
        public static T TouchPoints<T>(this T self, Func<PropertyContext<int>, IPropertyBuilder<int>> configure)
            where T : Microsoft.Maui.Controls.PanGestureRecognizer
        {
            var context = new PropertyContext<int>(self, Microsoft.Maui.Controls.PanGestureRecognizer.TouchPointsProperty);
            configure(context).Build();
            return self;
        }
        
        public static T OnPanUpdated<T>(this T self, System.EventHandler<Microsoft.Maui.Controls.PanUpdatedEventArgs> handler)
            where T : Microsoft.Maui.Controls.PanGestureRecognizer
        {
            self.PanUpdated += handler;
            return self;
        }
        
        public static T OnPanUpdated<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.PanGestureRecognizer
        {
            self.PanUpdated += (o, arg) => action(self);
            return self;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
