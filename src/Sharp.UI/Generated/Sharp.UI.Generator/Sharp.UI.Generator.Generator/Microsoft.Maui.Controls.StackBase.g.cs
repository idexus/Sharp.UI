﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class StackBaseGeneratedExtension
    {
        public static T Spacing<T>(this T obj,
            double spacing)
            where T : Sharp.UI.IStackBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.StackBase>(obj);
            mauiObject.Spacing = (double)spacing;
            return obj;
        }
        
        public static T Spacing<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStackBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.StackBase>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Spacing = builder.GetValue();
            return obj;
        }
        
        public static T Spacing<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStackBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.StackBase>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Spacing = builder.GetValue();
            return obj;
        }
        
        public static T Spacing<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IStackBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.StackBase>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, Microsoft.Maui.Controls.StackBase.SpacingProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669