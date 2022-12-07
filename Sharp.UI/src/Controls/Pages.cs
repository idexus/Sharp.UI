using System.Collections;

namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.ContentPage),
        constructorWithProperties: new[] { "Title" },
        attachedProperties: new[] { "Shell.PresentationMode" },
        attachedPropertiesTypes: new[] {typeof(PresentationMode) })] 
    public partial class ContentPage { }

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
