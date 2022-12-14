//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class ElementGeneratedSharpObjectExtension
    {
        public static T ContextFlyout<T>(this T obj,
            Sharp.UI.MenuFlyout contextFlyout)
            where T : Sharp.UI.IElement
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Element>(obj);
            mauiObject.SetValue(Microsoft.Maui.Controls.FlyoutBase.ContextFlyoutProperty, (Sharp.UI.MenuFlyout)contextFlyout);
            return obj;
        }
        
        public static T ContextFlyout<T>(this T obj,
            System.Func<ValueBuilder<Sharp.UI.MenuFlyout>, ValueBuilder<Sharp.UI.MenuFlyout>> buildValue)
            where T : Sharp.UI.IElement
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Element>(obj);
            var builder = buildValue(new ValueBuilder<Sharp.UI.MenuFlyout>());
            if (builder.ValueIsSet()) mauiObject.SetValue(Microsoft.Maui.Controls.FlyoutBase.ContextFlyoutProperty, builder.GetValue());
            return obj;
        }
        
        public static T ContextFlyout<T>(this T obj,
            System.Func<LazyValueBuilder<Sharp.UI.MenuFlyout>, LazyValueBuilder<Sharp.UI.MenuFlyout>> buildValue)
            where T : Sharp.UI.IElement
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Element>(obj);
            var builder = buildValue(new LazyValueBuilder<Sharp.UI.MenuFlyout>());
            if (builder.ValueIsSet()) mauiObject.SetValue(Microsoft.Maui.Controls.FlyoutBase.ContextFlyoutProperty, builder.GetValue());
            return obj;
        }
        
        public static T ContextFlyout<T>(this T obj,
            System.Func<BindingBuilder<Sharp.UI.MenuFlyout>, BindingBuilder<Sharp.UI.MenuFlyout>> buildBinding)
            where T : Sharp.UI.IElement
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Element>(obj);
            var builder = buildBinding(new BindingBuilder<Sharp.UI.MenuFlyout>(mauiObject, Microsoft.Maui.Controls.FlyoutBase.ContextFlyoutProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
