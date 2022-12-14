//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class FontImageSourceGeneratedExtension
    {
        public static T Color<T>(this T obj,
            Microsoft.Maui.Graphics.Color color)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            mauiObject.Color = (Microsoft.Maui.Graphics.Color)color;
            return obj;
        }
        
        public static T Color<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.Color = builder.GetValue();
            return obj;
        }
        
        public static T Color<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Graphics.Color>, LazyValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.Color = builder.GetValue();
            return obj;
        }
        
        public static T Color<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buildBinding)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.FontImageSource.ColorProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            string fontFamily)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            mauiObject.FontFamily = (string)fontFamily;
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.FontFamily = builder.GetValue();
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            System.Func<LazyValueBuilder<string>, LazyValueBuilder<string>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new LazyValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.FontFamily = builder.GetValue();
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buildBinding)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildBinding(new BindingBuilder<string>(mauiObject, Microsoft.Maui.Controls.FontImageSource.FontFamilyProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Glyph<T>(this T obj,
            string glyph)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            mauiObject.Glyph = (string)glyph;
            return obj;
        }
        
        public static T Glyph<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.Glyph = builder.GetValue();
            return obj;
        }
        
        public static T Glyph<T>(this T obj,
            System.Func<LazyValueBuilder<string>, LazyValueBuilder<string>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new LazyValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.Glyph = builder.GetValue();
            return obj;
        }
        
        public static T Glyph<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buildBinding)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildBinding(new BindingBuilder<string>(mauiObject, Microsoft.Maui.Controls.FontImageSource.GlyphProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Size<T>(this T obj,
            double size)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            mauiObject.Size = (double)size;
            return obj;
        }
        
        public static T Size<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Size = builder.GetValue();
            return obj;
        }
        
        public static T Size<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Size = builder.GetValue();
            return obj;
        }
        
        public static T Size<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, Microsoft.Maui.Controls.FontImageSource.SizeProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            bool fontAutoScalingEnabled)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            mauiObject.FontAutoScalingEnabled = (bool)fontAutoScalingEnabled;
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.FontAutoScalingEnabled = builder.GetValue();
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.FontAutoScalingEnabled = builder.GetValue();
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buildBinding)
            where T : Sharp.UI.IFontImageSource
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.FontImageSource>(obj);
            var builder = buildBinding(new BindingBuilder<bool>(mauiObject, Microsoft.Maui.Controls.FontImageSource.FontAutoScalingEnabledProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
