﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class IMultiPagePageGeneratedExtension
    {
        public static T ItemsSource<T>(this T obj,
            System.Collections.IEnumerable? itemsSource)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            if (itemsSource != null) mauiObject.ItemsSource = (System.Collections.IEnumerable)itemsSource;
            return obj;
        }
        
        public static T ItemsSource<T>(this T obj,
            System.Collections.IEnumerable? itemsSource,
            Func<BindableDef<System.Collections.IEnumerable>, BindableDef<System.Collections.IEnumerable>> definition)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            if (itemsSource != null) mauiObject.ItemsSource = (System.Collections.IEnumerable)itemsSource;
            var def = definition(new BindableDef<System.Collections.IEnumerable>(mauiObject, Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>.ItemsSourceProperty));
            if (def.ValueIsSet()) mauiObject.ItemsSource = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T ItemsSource<T>(this T obj,
            Func<BindableDef<System.Collections.IEnumerable>, BindableDef<System.Collections.IEnumerable>> definition)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            var def = definition(new BindableDef<System.Collections.IEnumerable>(mauiObject, Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>.ItemsSourceProperty));
            if (def.ValueIsSet()) mauiObject.ItemsSource = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T ItemTemplate<T>(this T obj,
            Microsoft.Maui.Controls.DataTemplate? itemTemplate)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            if (itemTemplate != null) mauiObject.ItemTemplate = (Microsoft.Maui.Controls.DataTemplate)itemTemplate;
            return obj;
        }
        
        public static T ItemTemplate<T>(this T obj,
            Microsoft.Maui.Controls.DataTemplate? itemTemplate,
            Func<BindableDef<Microsoft.Maui.Controls.DataTemplate>, BindableDef<Microsoft.Maui.Controls.DataTemplate>> definition)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            if (itemTemplate != null) mauiObject.ItemTemplate = (Microsoft.Maui.Controls.DataTemplate)itemTemplate;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.DataTemplate>(mauiObject, Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>.ItemTemplateProperty));
            if (def.ValueIsSet()) mauiObject.ItemTemplate = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T ItemTemplate<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.DataTemplate>, BindableDef<Microsoft.Maui.Controls.DataTemplate>> definition)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.DataTemplate>(mauiObject, Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>.ItemTemplateProperty));
            if (def.ValueIsSet()) mauiObject.ItemTemplate = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T ItemTemplate<T>(this T obj, Func<object> loadTemplate) where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            mauiObject.ItemTemplate = new Microsoft.Maui.Controls.DataTemplate(loadTemplate);
            return obj;
        }
        
        public static T SelectedItem<T>(this T obj,
            object? selectedItem)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            if (selectedItem != null) mauiObject.SelectedItem = (object)selectedItem;
            return obj;
        }
        
        public static T SelectedItem<T>(this T obj,
            object? selectedItem,
            Func<BindableDef<object>, BindableDef<object>> definition)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            if (selectedItem != null) mauiObject.SelectedItem = (object)selectedItem;
            var def = definition(new BindableDef<object>(mauiObject, Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>.SelectedItemProperty));
            if (def.ValueIsSet()) mauiObject.SelectedItem = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T SelectedItem<T>(this T obj,
            Func<BindableDef<object>, BindableDef<object>> definition)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            var def = definition(new BindableDef<object>(mauiObject, Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>.SelectedItemProperty));
            if (def.ValueIsSet()) mauiObject.SelectedItem = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T CurrentPage<T>(this T obj,
            Microsoft.Maui.Controls.Page? currentPage)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            if (currentPage != null) mauiObject.CurrentPage = (Microsoft.Maui.Controls.Page)currentPage;
            return obj;
        }
        
        public static T CurrentPage<T>(this T obj,
            Microsoft.Maui.Controls.Page? currentPage,
            Func<ValueDef<Microsoft.Maui.Controls.Page>, ValueDef<Microsoft.Maui.Controls.Page>> definition)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            if (currentPage != null) mauiObject.CurrentPage = (Microsoft.Maui.Controls.Page)currentPage;
            var def = definition(new ValueDef<Microsoft.Maui.Controls.Page>());
            if (def.ValueIsSet()) mauiObject.CurrentPage = def.GetValue();
            return obj;
        }
        
        public static T CurrentPage<T>(this T obj,
            Func<ValueDef<Microsoft.Maui.Controls.Page>, ValueDef<Microsoft.Maui.Controls.Page>> definition)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            var def = definition(new ValueDef<Microsoft.Maui.Controls.Page>());
            if (def.ValueIsSet()) mauiObject.CurrentPage = def.GetValue();
            return obj;
        }
        
        public static T Children<T>(this T obj,
            System.Collections.Generic.IList<Microsoft.Maui.Controls.Page> children)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            foreach (var item in children) mauiObject.Children.Add(item);
            return obj;
        }

        public static T Children<T>(this T obj,
            params Microsoft.Maui.Controls.Page[] children)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            foreach (var item in children) mauiObject.Children.Add(item);
            return obj;
        }

        public static T Children<T>(this T obj,
            Func<Def<System.Collections.Generic.IList<Microsoft.Maui.Controls.Page>>, Def<System.Collections.Generic.IList<Microsoft.Maui.Controls.Page>>> definition)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            var def = definition(new Def<System.Collections.Generic.IList<Microsoft.Maui.Controls.Page>>());
            if (def.ValueIsSet())
            {
                var items = def.GetValue();
                foreach (var item in items) mauiObject.Children.Add(item);
            }
            return obj;
        }
        
        public static T OnCurrentPageChanged<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.IMultiPagePage
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            mauiObject.CurrentPageChanged += (o, arg) => action(obj);
            return obj;
        }
        
        public static T OnPagesChanged<T>(this T obj, OnEventAction<T, System.Collections.Specialized.NotifyCollectionChangedEventArgs> action)
            where T : Sharp.UI.IMultiPagePage
        {            
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.MultiPage<Microsoft.Maui.Controls.Page>>(obj);
            mauiObject.PagesChanged += (o, arg) => action(obj, arg);
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
