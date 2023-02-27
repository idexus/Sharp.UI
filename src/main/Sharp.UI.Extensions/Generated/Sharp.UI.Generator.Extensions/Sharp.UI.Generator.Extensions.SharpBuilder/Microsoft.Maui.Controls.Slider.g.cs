﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class SliderExtension
    {
        public static T MinimumTrackColor<T>(this T self,
            Microsoft.Maui.Graphics.Color minimumTrackColor)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Slider.MinimumTrackColorProperty, minimumTrackColor);
            return self;
        }
        
        public static T MinimumTrackColor<T>(this T self, Func<PropertyContext<Microsoft.Maui.Graphics.Color>, IPropertyBuilder<Microsoft.Maui.Graphics.Color>> configure)
            where T : Microsoft.Maui.Controls.Slider
        {
            var context = new PropertyContext<Microsoft.Maui.Graphics.Color>(self, Microsoft.Maui.Controls.Slider.MinimumTrackColorProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateMinimumTrackColorTo<T>(this T self, Microsoft.Maui.Graphics.Color value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.Slider
        {
            Microsoft.Maui.Graphics.Color fromValue = self.MinimumTrackColor;
            var transform = (double t) => Transformations.ColorTransform(fromValue, value, t);
            var callback = (Microsoft.Maui.Graphics.Color actValue) => { self.MinimumTrackColor = actValue; };
            return Transformations.AnimateAsync<Microsoft.Maui.Graphics.Color>(self, "AnimateMinimumTrackColorTo", transform, callback, length, easing);
        }
        
        public static T MaximumTrackColor<T>(this T self,
            Microsoft.Maui.Graphics.Color maximumTrackColor)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Slider.MaximumTrackColorProperty, maximumTrackColor);
            return self;
        }
        
        public static T MaximumTrackColor<T>(this T self, Func<PropertyContext<Microsoft.Maui.Graphics.Color>, IPropertyBuilder<Microsoft.Maui.Graphics.Color>> configure)
            where T : Microsoft.Maui.Controls.Slider
        {
            var context = new PropertyContext<Microsoft.Maui.Graphics.Color>(self, Microsoft.Maui.Controls.Slider.MaximumTrackColorProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateMaximumTrackColorTo<T>(this T self, Microsoft.Maui.Graphics.Color value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.Slider
        {
            Microsoft.Maui.Graphics.Color fromValue = self.MaximumTrackColor;
            var transform = (double t) => Transformations.ColorTransform(fromValue, value, t);
            var callback = (Microsoft.Maui.Graphics.Color actValue) => { self.MaximumTrackColor = actValue; };
            return Transformations.AnimateAsync<Microsoft.Maui.Graphics.Color>(self, "AnimateMaximumTrackColorTo", transform, callback, length, easing);
        }
        
        public static T ThumbColor<T>(this T self,
            Microsoft.Maui.Graphics.Color thumbColor)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Slider.ThumbColorProperty, thumbColor);
            return self;
        }
        
        public static T ThumbColor<T>(this T self, Func<PropertyContext<Microsoft.Maui.Graphics.Color>, IPropertyBuilder<Microsoft.Maui.Graphics.Color>> configure)
            where T : Microsoft.Maui.Controls.Slider
        {
            var context = new PropertyContext<Microsoft.Maui.Graphics.Color>(self, Microsoft.Maui.Controls.Slider.ThumbColorProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateThumbColorTo<T>(this T self, Microsoft.Maui.Graphics.Color value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.Slider
        {
            Microsoft.Maui.Graphics.Color fromValue = self.ThumbColor;
            var transform = (double t) => Transformations.ColorTransform(fromValue, value, t);
            var callback = (Microsoft.Maui.Graphics.Color actValue) => { self.ThumbColor = actValue; };
            return Transformations.AnimateAsync<Microsoft.Maui.Graphics.Color>(self, "AnimateThumbColorTo", transform, callback, length, easing);
        }
        
        public static T ThumbImageSource<T>(this T self,
            Microsoft.Maui.Controls.ImageSource thumbImageSource)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Slider.ThumbImageSourceProperty, thumbImageSource);
            return self;
        }
        
        public static T ThumbImageSource<T>(this T self, Func<PropertyContext<Microsoft.Maui.Controls.ImageSource>, IPropertyBuilder<Microsoft.Maui.Controls.ImageSource>> configure)
            where T : Microsoft.Maui.Controls.Slider
        {
            var context = new PropertyContext<Microsoft.Maui.Controls.ImageSource>(self, Microsoft.Maui.Controls.Slider.ThumbImageSourceProperty);
            configure(context).Build();
            return self;
        }
        
        public static T DragStartedCommand<T>(this T self,
            System.Windows.Input.ICommand dragStartedCommand)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Slider.DragStartedCommandProperty, dragStartedCommand);
            return self;
        }
        
        public static T DragStartedCommand<T>(this T self, Func<PropertyContext<System.Windows.Input.ICommand>, IPropertyBuilder<System.Windows.Input.ICommand>> configure)
            where T : Microsoft.Maui.Controls.Slider
        {
            var context = new PropertyContext<System.Windows.Input.ICommand>(self, Microsoft.Maui.Controls.Slider.DragStartedCommandProperty);
            configure(context).Build();
            return self;
        }
        
        public static T DragCompletedCommand<T>(this T self,
            System.Windows.Input.ICommand dragCompletedCommand)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Slider.DragCompletedCommandProperty, dragCompletedCommand);
            return self;
        }
        
        public static T DragCompletedCommand<T>(this T self, Func<PropertyContext<System.Windows.Input.ICommand>, IPropertyBuilder<System.Windows.Input.ICommand>> configure)
            where T : Microsoft.Maui.Controls.Slider
        {
            var context = new PropertyContext<System.Windows.Input.ICommand>(self, Microsoft.Maui.Controls.Slider.DragCompletedCommandProperty);
            configure(context).Build();
            return self;
        }
        
        public static T Maximum<T>(this T self,
            double maximum)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Slider.MaximumProperty, maximum);
            return self;
        }
        
        public static T Maximum<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
            where T : Microsoft.Maui.Controls.Slider
        {
            var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.Slider.MaximumProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateMaximumTo<T>(this T self, double value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.Slider
        {
            double fromValue = self.Maximum;
            var transform = (double t) => Transformations.DoubleTransform(fromValue, value, t);
            var callback = (double actValue) => { self.Maximum = actValue; };
            return Transformations.AnimateAsync<double>(self, "AnimateMaximumTo", transform, callback, length, easing);
        }
        
        public static T Minimum<T>(this T self,
            double minimum)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Slider.MinimumProperty, minimum);
            return self;
        }
        
        public static T Minimum<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
            where T : Microsoft.Maui.Controls.Slider
        {
            var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.Slider.MinimumProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateMinimumTo<T>(this T self, double value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.Slider
        {
            double fromValue = self.Minimum;
            var transform = (double t) => Transformations.DoubleTransform(fromValue, value, t);
            var callback = (double actValue) => { self.Minimum = actValue; };
            return Transformations.AnimateAsync<double>(self, "AnimateMinimumTo", transform, callback, length, easing);
        }
        
        public static T Value<T>(this T self,
            double value)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Slider.ValueProperty, value);
            return self;
        }
        
        public static T Value<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
            where T : Microsoft.Maui.Controls.Slider
        {
            var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.Slider.ValueProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateValueTo<T>(this T self, double value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.Slider
        {
            double fromValue = self.Value;
            var transform = (double t) => Transformations.DoubleTransform(fromValue, value, t);
            var callback = (double actValue) => { self.Value = actValue; };
            return Transformations.AnimateAsync<double>(self, "AnimateValueTo", transform, callback, length, easing);
        }
        
        public static T OnValueChanged<T>(this T self, System.EventHandler<Microsoft.Maui.Controls.ValueChangedEventArgs> handler)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.ValueChanged += handler;
            return self;
        }
        
        public static T OnValueChanged<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.ValueChanged += (o, arg) => action(self);
            return self;
        }
        
        public static T OnDragStarted<T>(this T self, System.EventHandler handler)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.DragStarted += handler;
            return self;
        }
        
        public static T OnDragStarted<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.DragStarted += (o, arg) => action(self);
            return self;
        }
        
        public static T OnDragCompleted<T>(this T self, System.EventHandler handler)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.DragCompleted += handler;
            return self;
        }
        
        public static T OnDragCompleted<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.Slider
        {
            self.DragCompleted += (o, arg) => action(self);
            return self;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
