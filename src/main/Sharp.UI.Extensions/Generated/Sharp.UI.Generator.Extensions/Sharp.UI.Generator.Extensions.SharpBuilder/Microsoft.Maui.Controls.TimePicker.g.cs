﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class TimePickerExtension
    {
        public static T Format<T>(this T self,
            string format)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.TimePicker.FormatProperty, format);
            return self;
        }
        
        public static T Format<T>(this T self, Func<PropertyContext<string>, IPropertyBuilder<string>> configure)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            var context = new PropertyContext<string>(self, Microsoft.Maui.Controls.TimePicker.FormatProperty);
            configure(context).Build();
            return self;
        }
        
        public static T TextColor<T>(this T self,
            Microsoft.Maui.Graphics.Color textColor)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.TimePicker.TextColorProperty, textColor);
            return self;
        }
        
        public static T TextColor<T>(this T self, Func<PropertyContext<Microsoft.Maui.Graphics.Color>, IPropertyBuilder<Microsoft.Maui.Graphics.Color>> configure)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            var context = new PropertyContext<Microsoft.Maui.Graphics.Color>(self, Microsoft.Maui.Controls.TimePicker.TextColorProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateTextColorTo<T>(this T self, Microsoft.Maui.Graphics.Color value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            Microsoft.Maui.Graphics.Color fromValue = self.TextColor;
            var transform = (double t) => Transformations.ColorTransform(fromValue, value, t);
            var callback = (Microsoft.Maui.Graphics.Color actValue) => { self.TextColor = actValue; };
            return Transformations.AnimateAsync<Microsoft.Maui.Graphics.Color>(self, "AnimateTextColorTo", transform, callback, length, easing);
        }
        
        public static T CharacterSpacing<T>(this T self,
            double characterSpacing)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.TimePicker.CharacterSpacingProperty, characterSpacing);
            return self;
        }
        
        public static T CharacterSpacing<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.TimePicker.CharacterSpacingProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateCharacterSpacingTo<T>(this T self, double value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            double fromValue = self.CharacterSpacing;
            var transform = (double t) => Transformations.DoubleTransform(fromValue, value, t);
            var callback = (double actValue) => { self.CharacterSpacing = actValue; };
            return Transformations.AnimateAsync<double>(self, "AnimateCharacterSpacingTo", transform, callback, length, easing);
        }
        
        public static T Time<T>(this T self,
            System.TimeSpan time)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.TimePicker.TimeProperty, time);
            return self;
        }
        
        public static T Time<T>(this T self, Func<PropertyContext<System.TimeSpan>, IPropertyBuilder<System.TimeSpan>> configure)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            var context = new PropertyContext<System.TimeSpan>(self, Microsoft.Maui.Controls.TimePicker.TimeProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontAttributes<T>(this T self,
            Microsoft.Maui.Controls.FontAttributes fontAttributes)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.TimePicker.FontAttributesProperty, fontAttributes);
            return self;
        }
        
        public static T FontAttributes<T>(this T self, Func<PropertyContext<Microsoft.Maui.Controls.FontAttributes>, IPropertyBuilder<Microsoft.Maui.Controls.FontAttributes>> configure)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            var context = new PropertyContext<Microsoft.Maui.Controls.FontAttributes>(self, Microsoft.Maui.Controls.TimePicker.FontAttributesProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontFamily<T>(this T self,
            string fontFamily)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.TimePicker.FontFamilyProperty, fontFamily);
            return self;
        }
        
        public static T FontFamily<T>(this T self, Func<PropertyContext<string>, IPropertyBuilder<string>> configure)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            var context = new PropertyContext<string>(self, Microsoft.Maui.Controls.TimePicker.FontFamilyProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontSize<T>(this T self,
            double fontSize)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.TimePicker.FontSizeProperty, fontSize);
            return self;
        }
        
        public static T FontSize<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.TimePicker.FontSizeProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateFontSizeTo<T>(this T self, double value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            double fromValue = self.FontSize;
            var transform = (double t) => Transformations.DoubleTransform(fromValue, value, t);
            var callback = (double actValue) => { self.FontSize = actValue; };
            return Transformations.AnimateAsync<double>(self, "AnimateFontSizeTo", transform, callback, length, easing);
        }
        
        public static T FontAutoScalingEnabled<T>(this T self,
            bool fontAutoScalingEnabled)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.TimePicker.FontAutoScalingEnabledProperty, fontAutoScalingEnabled);
            return self;
        }
        
        public static T FontAutoScalingEnabled<T>(this T self, Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure)
            where T : Microsoft.Maui.Controls.TimePicker
        {
            var context = new PropertyContext<bool>(self, Microsoft.Maui.Controls.TimePicker.FontAutoScalingEnabledProperty);
            configure(context).Build();
            return self;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
