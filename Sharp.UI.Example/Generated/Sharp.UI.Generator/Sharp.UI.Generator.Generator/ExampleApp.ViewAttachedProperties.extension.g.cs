//
// <auto-generated>
//

#pragma warning disable CS8669


namespace ExampleApp
{
    using Sharp.UI;

    public static class ViewAttachedPropertiesGeneratedSharpObjectExtension
    {
        public static T HasCustomShadow<T>(this T obj,
            bool hasShadow)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(ExampleApp.CustomShadow.HasShadowProperty, (bool)hasShadow);
            return obj;
        }
        
        public static T HasCustomShadow<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.CustomShadow.HasShadowProperty, builder.GetValue());
            return obj;
        }
        
        public static T HasCustomShadow<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.CustomShadow.HasShadowProperty, builder.GetValue());
            return obj;
        }
        
        public static T HasCustomShadow<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buildBinding)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var builder = buildBinding(new BindingBuilder<bool>(mauiObject, ExampleApp.CustomShadow.HasShadowProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T ShadowSize<T>(this T obj,
            double shadowSize)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(ExampleApp.CustomShadow.ShadowSizeProperty, (double)shadowSize);
            return obj;
        }
        
        public static T ShadowSize<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.CustomShadow.ShadowSizeProperty, builder.GetValue());
            return obj;
        }
        
        public static T ShadowSize<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.CustomShadow.ShadowSizeProperty, builder.GetValue());
            return obj;
        }
        
        public static T ShadowSize<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, ExampleApp.CustomShadow.ShadowSizeProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T ShadowColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color shadowColor)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(ExampleApp.CustomShadow.ShadowColorProperty, (Microsoft.Maui.Graphics.Color)shadowColor);
            return obj;
        }
        
        public static T ShadowColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.CustomShadow.ShadowColorProperty, builder.GetValue());
            return obj;
        }
        
        public static T ShadowColor<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Graphics.Color>, LazyValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.CustomShadow.ShadowColorProperty, builder.GetValue());
            return obj;
        }
        
        public static T ShadowColor<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buildBinding)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(mauiObject, ExampleApp.CustomShadow.ShadowColorProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
