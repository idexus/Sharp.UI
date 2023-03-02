using System;

namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.Shell))]
    public interface IPageShellAttachedProperties
    {
        [AttachedName("PresentationModeProperty")]
        PresentationMode ShellPresentationMode { get; set; }

        [AttachedName("BackgroundColorProperty")]
        Color ShellBackgroundColor { get; set; }

        [AttachedName("ForegroundColorProperty")]
        Color ShellForegroundColor { get; set; }

        [AttachedName("TitleColorProperty")]
        Color ShellTitleColor { get; set; }

        [AttachedName("DisabledColorProperty")]
        Color ShellDisabledColor { get; set; }

        [AttachedName("UnselectedColorProperty")]
        Color ShellUnselectedColor { get; set; }

        [AttachedName("NavBarHasShadowProperty")]
        bool ShellNavBarHasShadow { get; set; }

        [AttachedName("NavBarIsVisibleProperty")]
        bool ShellNavBarIsVisible { get; set; }

        [AttachedName("TabBarBackgroundColorProperty")]
        Color ShellTabBarBackgroundColor { get; set; }

        [AttachedName("TabBarForegroundColorProperty")]
        Color ShellTabBarForegroundColor { get; set; }

        [AttachedName("TabBarTitleColorProperty")]
        Color ShellTabBarTitleColor { get; set; }

        [AttachedName("TabBarDisabledColorProperty")]
        Color ShellTabBarDisabledColor { get; set; }

        [AttachedName("TabBarUnselectedColorProperty")]
        Color ShellTabBarUnselectedColor { get; set; }
    }

    [AttachedInterfaces(typeof(Microsoft.Maui.Controls.Page), new[] { typeof(IPageShellAttachedProperties) })]
    public static partial class PageExtension
    {

    }
}