using System.Collections;

namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.Shell))]
    public interface IContentPageShellAttachedProperties
    {
        PresentationMode ShellPresentationMode { get; set; }
        Color ShellBackgroundColor { get; set; }
        Color ShellForegroundColor { get; set; }
        Color ShellTitleColor { get; set; }
        Color ShellDisabledColor { get; set; }
        Color ShellUnselectedColor { get; set; }
        bool ShellNavBarHasShadow { get; set; }
        bool ShellNavBarIsVisible { get; set; }
        Microsoft.Maui.Controls.View ShellTitleView { get; set; }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ContentPage),
        constructorWithProperties: new[] { "Title" })] 
    public partial class ContentPage : IContentPageShellAttachedProperties { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.FlyoutPage))] 
    public partial class FlyoutPage { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.NavigationPage))] 
    public partial class NavigationPage : IEnumerable
    {
        public IEnumerator GetEnumerator() => throw new NotImplementedException();
        public void Add(Microsoft.Maui.Controls.Page page) => this.PushAsync(page);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.TabbedPage))]
    public partial class TabbedPage { }
}
