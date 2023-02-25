using System;
namespace Sharp.UI
{
    public static partial class PageExtension
    {
        public static T ShellPresentationMode<T>(this T obj, PresentationMode presentationMode) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.PresentationModeProperty, presentationMode);
            return obj;
        }

        public static T ShellBackgroundColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.BackgroundColorProperty, color);
            return obj;
        }

        public static T ShellBackgroundColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.BackgroundColorProperty, builder.GetValue());
            return obj;
        }

        public static T ShellForegroundColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.ForegroundColorProperty, color);
            return obj;
        }

        public static T ShellForegroundColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.ForegroundColorProperty, builder.GetValue());
            return obj;
        }

        public static T ShellTitleColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TitleColorProperty, color);
            return obj;
        }

        public static T ShellTitleColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TitleColorProperty, builder.GetValue());
            return obj;
        }

        public static T ShellDisabledColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.DisabledColorProperty, color);
            return obj;
        }

        public static T ShellDisabledColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.DisabledColorProperty, builder.GetValue());
            return obj;
        }

        public static T ShellUnselectedColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.UnselectedColorProperty, color);
            return obj;
        }

        public static T ShellUnselectedColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.UnselectedColorProperty, builder.GetValue());
            return obj;
        }

        public static T ShellNavBarHasShadow<T>(this T obj, bool hasShadow) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.NavBarHasShadowProperty, hasShadow);
            return obj;
        }

        public static T ShellNavBarIsVisible<T>(this T obj, bool isVisible) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.NavBarIsVisibleProperty, isVisible);
            return obj;
        }

        public static T ShellTitleView<T>(this T obj, View view) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TitleViewProperty, view);
            return obj;
        }

        // tabbar

        public static T ShellTabBarBackgroundColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarBackgroundColorProperty, color);
            return obj;
        }

        public static T ShellTabBarBackgroundColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarBackgroundColorProperty, builder.GetValue());
            return obj;
        }

        public static T ShellTabBarForegroundColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarForegroundColorProperty, color);
            return obj;
        }

        public static T ShellTabBarForegroundColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarForegroundColorProperty, builder.GetValue());
            return obj;
        }

        public static T ShellTabBarTitleColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarTitleColorProperty, color);
            return obj;
        }

        public static T ShellTabBarTitleColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarTitleColorProperty, builder.GetValue());
            return obj;
        }

        public static T ShellTabBarDisabledColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarDisabledColorProperty, color);
            return obj;
        }

        public static T ShellTabBarDisabledColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarDisabledColorProperty, builder.GetValue());
            return obj;
        }

        public static T ShellTabBarUnselectedColor<T>(this T obj, Color color) where T : Page
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarUnselectedColorProperty, color);
            return obj;
        }

        public static T ShellTabBarUnselectedColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Page
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shell.TabBarUnselectedColorProperty, builder.GetValue());
            return obj;
        }
    }
}

