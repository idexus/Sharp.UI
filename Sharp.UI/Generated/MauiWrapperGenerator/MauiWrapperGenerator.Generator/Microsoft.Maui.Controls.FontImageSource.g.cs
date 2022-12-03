﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class IFontImageSourceGeneratedExtension
    {
        public static T Color<T>(this T obj,
            Microsoft.Maui.Graphics.Color? color)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (color != null) mauiObject.Color = (Microsoft.Maui.Graphics.Color)color;
            return obj;
        }
        
        public static T Color<T>(this T obj,
            Microsoft.Maui.Graphics.Color? color,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (color != null) mauiObject.Color = (Microsoft.Maui.Graphics.Color)color;
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.FontImageSource.ColorProperty));
            if (def.ValueIsSet()) mauiObject.Color = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Color<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.FontImageSource.ColorProperty));
            if (def.ValueIsSet()) mauiObject.Color = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            string? fontFamily)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (fontFamily != null) mauiObject.FontFamily = (string)fontFamily;
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            string? fontFamily,
            Func<BindableDef<string>, BindableDef<string>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (fontFamily != null) mauiObject.FontFamily = (string)fontFamily;
            var def = definition(new BindableDef<string>(mauiObject, Microsoft.Maui.Controls.FontImageSource.FontFamilyProperty));
            if (def.ValueIsSet()) mauiObject.FontFamily = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            Func<BindableDef<string>, BindableDef<string>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            var def = definition(new BindableDef<string>(mauiObject, Microsoft.Maui.Controls.FontImageSource.FontFamilyProperty));
            if (def.ValueIsSet()) mauiObject.FontFamily = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Glyph<T>(this T obj,
            string? glyph)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (glyph != null) mauiObject.Glyph = (string)glyph;
            return obj;
        }
        
        public static T Glyph<T>(this T obj,
            string? glyph,
            Func<BindableDef<string>, BindableDef<string>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (glyph != null) mauiObject.Glyph = (string)glyph;
            var def = definition(new BindableDef<string>(mauiObject, Microsoft.Maui.Controls.FontImageSource.GlyphProperty));
            if (def.ValueIsSet()) mauiObject.Glyph = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Glyph<T>(this T obj,
            Func<BindableDef<string>, BindableDef<string>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            var def = definition(new BindableDef<string>(mauiObject, Microsoft.Maui.Controls.FontImageSource.GlyphProperty));
            if (def.ValueIsSet()) mauiObject.Glyph = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Size<T>(this T obj,
            double? size)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (size != null) mauiObject.Size = (double)size;
            return obj;
        }
        
        public static T Size<T>(this T obj,
            double? size,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (size != null) mauiObject.Size = (double)size;
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.FontImageSource.SizeProperty));
            if (def.ValueIsSet()) mauiObject.Size = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Size<T>(this T obj,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.FontImageSource.SizeProperty));
            if (def.ValueIsSet()) mauiObject.Size = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            bool? fontAutoScalingEnabled)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (fontAutoScalingEnabled != null) mauiObject.FontAutoScalingEnabled = (bool)fontAutoScalingEnabled;
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            bool? fontAutoScalingEnabled,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            if (fontAutoScalingEnabled != null) mauiObject.FontAutoScalingEnabled = (bool)fontAutoScalingEnabled;
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.FontImageSource.FontAutoScalingEnabledProperty));
            if (def.ValueIsSet()) mauiObject.FontAutoScalingEnabled = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.FontImageSource>(obj);
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.FontImageSource.FontAutoScalingEnabledProperty));
            if (def.ValueIsSet()) mauiObject.FontAutoScalingEnabled = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
