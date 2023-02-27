﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class FrameExtension
    {
        public static T HasShadow<T>(this T self,
            bool hasShadow)
            where T : Microsoft.Maui.Controls.Frame
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Frame.HasShadowProperty, hasShadow);
            return self;
        }
        
        public static T HasShadow<T>(this T self, Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure)
            where T : Microsoft.Maui.Controls.Frame
        {
            var context = new PropertyContext<bool>(self, Microsoft.Maui.Controls.Frame.HasShadowProperty);
            configure(context).Build();
            return self;
        }
        
        public static T BorderColor<T>(this T self,
            Microsoft.Maui.Graphics.Color borderColor)
            where T : Microsoft.Maui.Controls.Frame
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Frame.BorderColorProperty, borderColor);
            return self;
        }
        
        public static T BorderColor<T>(this T self, Func<PropertyContext<Microsoft.Maui.Graphics.Color>, IPropertyBuilder<Microsoft.Maui.Graphics.Color>> configure)
            where T : Microsoft.Maui.Controls.Frame
        {
            var context = new PropertyContext<Microsoft.Maui.Graphics.Color>(self, Microsoft.Maui.Controls.Frame.BorderColorProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateBorderColorTo<T>(this T self, Microsoft.Maui.Graphics.Color value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.Frame
        {
            Microsoft.Maui.Graphics.Color fromValue = self.BorderColor;
            var transform = (double t) => Transformations.ColorTransform(fromValue, value, t);
            var callback = (Microsoft.Maui.Graphics.Color actValue) => { self.BorderColor = actValue; };
            return Transformations.AnimateAsync<Microsoft.Maui.Graphics.Color>(self, "AnimateBorderColorTo", transform, callback, length, easing);
        }
        
        public static T CornerRadius<T>(this T self,
            float cornerRadius)
            where T : Microsoft.Maui.Controls.Frame
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Frame.CornerRadiusProperty, cornerRadius);
            return self;
        }
        
        public static T CornerRadius<T>(this T self, Func<PropertyContext<float>, IPropertyBuilder<float>> configure)
            where T : Microsoft.Maui.Controls.Frame
        {
            var context = new PropertyContext<float>(self, Microsoft.Maui.Controls.Frame.CornerRadiusProperty);
            configure(context).Build();
            return self;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
