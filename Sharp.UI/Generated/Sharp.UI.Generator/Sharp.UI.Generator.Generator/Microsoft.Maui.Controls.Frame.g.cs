﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class FrameGeneratedExtension
    {
        public static T HasShadow<T>(this T obj,
            bool? hasShadow)
            where T : Sharp.UI.IFrame
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Frame>(obj);
            if (hasShadow != null) mauiObject.HasShadow = (bool)hasShadow;
            return obj;
        }
        
        public static T HasShadow<T>(this T obj,
            bool? hasShadow,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.IFrame
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Frame>(obj);
            if (hasShadow != null) mauiObject.HasShadow = (bool)hasShadow;
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.Frame.HasShadowProperty));
            if (def.ValueIsSet()) mauiObject.HasShadow = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T HasShadow<T>(this T obj,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.IFrame
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Frame>(obj);
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.Frame.HasShadowProperty));
            if (def.ValueIsSet()) mauiObject.HasShadow = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T BorderColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? borderColor)
            where T : Sharp.UI.IFrame
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Frame>(obj);
            if (borderColor != null) mauiObject.BorderColor = (Microsoft.Maui.Graphics.Color)borderColor;
            return obj;
        }
        
        public static T BorderColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? borderColor,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.IFrame
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Frame>(obj);
            if (borderColor != null) mauiObject.BorderColor = (Microsoft.Maui.Graphics.Color)borderColor;
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.Frame.BorderColorProperty));
            if (def.ValueIsSet()) mauiObject.BorderColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T BorderColor<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.IFrame
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Frame>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.Frame.BorderColorProperty));
            if (def.ValueIsSet()) mauiObject.BorderColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T CornerRadius<T>(this T obj,
            float? cornerRadius)
            where T : Sharp.UI.IFrame
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Frame>(obj);
            if (cornerRadius != null) mauiObject.CornerRadius = (float)cornerRadius;
            return obj;
        }
        
        public static T CornerRadius<T>(this T obj,
            float? cornerRadius,
            Func<BindableDef<float>, BindableDef<float>> definition)
            where T : Sharp.UI.IFrame
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Frame>(obj);
            if (cornerRadius != null) mauiObject.CornerRadius = (float)cornerRadius;
            var def = definition(new BindableDef<float>(mauiObject, Microsoft.Maui.Controls.Frame.CornerRadiusProperty));
            if (def.ValueIsSet()) mauiObject.CornerRadius = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T CornerRadius<T>(this T obj,
            Func<BindableDef<float>, BindableDef<float>> definition)
            where T : Sharp.UI.IFrame
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Frame>(obj);
            var def = definition(new BindableDef<float>(mauiObject, Microsoft.Maui.Controls.Frame.CornerRadiusProperty));
            if (def.ValueIsSet()) mauiObject.CornerRadius = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669