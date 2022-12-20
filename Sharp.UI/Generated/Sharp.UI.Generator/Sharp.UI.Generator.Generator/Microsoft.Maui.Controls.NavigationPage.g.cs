﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class NavigationPageGeneratedExtension
    {
        public static T BarBackgroundColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color barBackgroundColor)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            mauiObject.BarBackgroundColor = (Microsoft.Maui.Graphics.Color)barBackgroundColor;
            return obj;
        }
        
        public static T BarBackgroundColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color barBackgroundColor,
            System.Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);         
            mauiObject.BarBackgroundColor = (Microsoft.Maui.Graphics.Color)barBackgroundColor;
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.NavigationPage.BarBackgroundColorProperty));
            if (def.ValueIsSet()) mauiObject.BarBackgroundColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T BarBackgroundColor<T>(this T obj,
            System.Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.NavigationPage.BarBackgroundColorProperty));
            if (def.ValueIsSet()) mauiObject.BarBackgroundColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T BarBackground<T>(this T obj,
            Microsoft.Maui.Controls.Brush barBackground)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            mauiObject.BarBackground = (Microsoft.Maui.Controls.Brush)barBackground;
            return obj;
        }
        
        public static T BarBackground<T>(this T obj,
            Microsoft.Maui.Controls.Brush barBackground,
            System.Func<BindableDef<Microsoft.Maui.Controls.Brush>, BindableDef<Microsoft.Maui.Controls.Brush>> definition)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);         
            mauiObject.BarBackground = (Microsoft.Maui.Controls.Brush)barBackground;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Brush>(mauiObject, Microsoft.Maui.Controls.NavigationPage.BarBackgroundProperty));
            if (def.ValueIsSet()) mauiObject.BarBackground = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T BarBackground<T>(this T obj,
            System.Func<BindableDef<Microsoft.Maui.Controls.Brush>, BindableDef<Microsoft.Maui.Controls.Brush>> definition)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Brush>(mauiObject, Microsoft.Maui.Controls.NavigationPage.BarBackgroundProperty));
            if (def.ValueIsSet()) mauiObject.BarBackground = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T BarTextColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color barTextColor)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            mauiObject.BarTextColor = (Microsoft.Maui.Graphics.Color)barTextColor;
            return obj;
        }
        
        public static T BarTextColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color barTextColor,
            System.Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);         
            mauiObject.BarTextColor = (Microsoft.Maui.Graphics.Color)barTextColor;
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.NavigationPage.BarTextColorProperty));
            if (def.ValueIsSet()) mauiObject.BarTextColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T BarTextColor<T>(this T obj,
            System.Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.NavigationPage.BarTextColorProperty));
            if (def.ValueIsSet()) mauiObject.BarTextColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T OnPopped<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.NavigationEventArgs> handler)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            mauiObject.Popped += handler;
            return obj;
        }
        
        public static T OnPopped<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            mauiObject.Popped += (o, arg) => action(obj);
            return obj;
        }
        
        public static T OnPoppedToRoot<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.NavigationEventArgs> handler)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            mauiObject.PoppedToRoot += handler;
            return obj;
        }
        
        public static T OnPoppedToRoot<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            mauiObject.PoppedToRoot += (o, arg) => action(obj);
            return obj;
        }
        
        public static T OnPushed<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.NavigationEventArgs> handler)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            mauiObject.Pushed += handler;
            return obj;
        }
        
        public static T OnPushed<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.INavigationPage
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.NavigationPage>(obj);
            mauiObject.Pushed += (o, arg) => action(obj);
            return obj;
        }
        
    }
}


#pragma warning restore CS8669