//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class ShellSectionGeneratedExtension
    {
        public static T CurrentItem<T>(this T obj,
            Microsoft.Maui.Controls.ShellContent currentItem)
            where T : Sharp.UI.IShellSection
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.ShellSection>(obj);
            mauiObject.CurrentItem = (Microsoft.Maui.Controls.ShellContent)currentItem;
            return obj;
        }
        
        public static T CurrentItem<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.ShellContent>, ValueBuilder<Microsoft.Maui.Controls.ShellContent>> buildValue)
            where T : Sharp.UI.IShellSection
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.ShellSection>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.ShellContent>());
            if (builder.ValueIsSet()) mauiObject.CurrentItem = builder.GetValue();
            return obj;
        }
        
        public static T CurrentItem<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Controls.ShellContent>, LazyValueBuilder<Microsoft.Maui.Controls.ShellContent>> buildValue)
            where T : Sharp.UI.IShellSection
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.ShellSection>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.ShellContent>());
            if (builder.ValueIsSet()) mauiObject.CurrentItem = builder.GetValue();
            return obj;
        }
        
        public static T CurrentItem<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.ShellContent>, BindingBuilder<Microsoft.Maui.Controls.ShellContent>> buildBinding)
            where T : Sharp.UI.IShellSection
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.ShellSection>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Controls.ShellContent>(mauiObject, Microsoft.Maui.Controls.ShellSection.CurrentItemProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Items<T>(this T obj,
            System.Collections.Generic.IList<Microsoft.Maui.Controls.ShellContent> items)
            where T : Sharp.UI.IShellSection
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.ShellSection>(obj);
            foreach (var item in items)
            {
                var mauiItem = MauiWrapper.Value<Microsoft.Maui.Controls.ShellContent>(item);
                mauiObject.Items.Add(mauiItem);
            }
            return obj;
        }

        public static T Items<T>(this T obj,
            params Microsoft.Maui.Controls.ShellContent[] items)
            where T : Sharp.UI.IShellSection
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.ShellSection>(obj);
            foreach (var item in items)
            {
                var mauiItem = MauiWrapper.Value<Microsoft.Maui.Controls.ShellContent>(item);
                mauiObject.Items.Add(mauiItem);
            }
            return obj;
        }

        public static T Items<T>(this T obj,
            System.Func<LazyValueBuilder<System.Collections.Generic.IList<Microsoft.Maui.Controls.ShellContent>>, LazyValueBuilder<System.Collections.Generic.IList<Microsoft.Maui.Controls.ShellContent>>> buildValue)
            where T : Sharp.UI.IShellSection
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.ShellSection>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Collections.Generic.IList<Microsoft.Maui.Controls.ShellContent>>());
            if (builder.ValueIsSet())
            {
                var items = builder.GetValue();
                foreach (var item in items) 
                {
                    var mauiItem = MauiWrapper.Value<Microsoft.Maui.Controls.ShellContent>(item);
                    mauiObject.Items.Add(mauiItem);
                }
            }
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
