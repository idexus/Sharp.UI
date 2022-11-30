using System.Collections;

namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.ContentPage),
        constructorWithProperties: new[] { "Title" })] //OK
    public partial class ContentPage { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.FlyoutPage))] //OK
    public partial class FlyoutPage { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.NavigationPage))] //OK
    public partial class NavigationPage : IEnumerable
    {
        public IEnumerator GetEnumerator() => throw new NotImplementedException();
        public void Add(Microsoft.Maui.Controls.Page page) => this.PushAsync(page);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.TabbedPage),
        containerOfType: typeof(Microsoft.Maui.Controls.Page))]
    public partial class TabbedPage { }
}
