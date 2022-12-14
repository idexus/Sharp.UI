//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class MenuBarItemGeneratedExtension
    {
        public static T Priority<T>(this T obj,
            int priority)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            mauiObject.Priority = (int)priority;
            return obj;
        }
        
        public static T Priority<T>(this T obj,
            System.Func<ValueBuilder<int>, ValueBuilder<int>> buildValue)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            var builder = buildValue(new ValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.Priority = builder.GetValue();
            return obj;
        }
        
        public static T Priority<T>(this T obj,
            System.Func<LazyValueBuilder<int>, LazyValueBuilder<int>> buildValue)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            var builder = buildValue(new LazyValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.Priority = builder.GetValue();
            return obj;
        }
        
        public static T IsEnabled<T>(this T obj,
            bool isEnabled)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            mauiObject.IsEnabled = (bool)isEnabled;
            return obj;
        }
        
        public static T IsEnabled<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.IsEnabled = builder.GetValue();
            return obj;
        }
        
        public static T IsEnabled<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.IsEnabled = builder.GetValue();
            return obj;
        }
        
        public static T IsEnabled<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buildBinding)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            var builder = buildBinding(new BindingBuilder<bool>(mauiObject, Microsoft.Maui.Controls.MenuBarItem.IsEnabledProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Text<T>(this T obj,
            string text)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            mauiObject.Text = (string)text;
            return obj;
        }
        
        public static T Text<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buildValue)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            var builder = buildValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.Text = builder.GetValue();
            return obj;
        }
        
        public static T Text<T>(this T obj,
            System.Func<LazyValueBuilder<string>, LazyValueBuilder<string>> buildValue)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            var builder = buildValue(new LazyValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.Text = builder.GetValue();
            return obj;
        }
        
        public static T Text<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buildBinding)
            where T : Sharp.UI.IMenuBarItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.MenuBarItem>(obj);
            var builder = buildBinding(new BindingBuilder<string>(mauiObject, Microsoft.Maui.Controls.MenuBarItem.TextProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
