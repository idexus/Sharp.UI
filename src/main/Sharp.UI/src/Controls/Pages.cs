using System.Collections;
using System.Diagnostics;

namespace Sharp.UI
{
    [SharpObject] 
    public partial class ContentPage : Microsoft.Maui.Controls.ContentPage
    {
        public ContentPage()
        {
            if (Application.HotReloadIsEnabled)
            {
                if (HotReload.BindingContext != null) BindingContext = HotReload.BindingContext;
            }
        }

        public ContentPage(string title) : this()
        {
            this.Title = title;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Application.HotReloadIsEnabled)
            {
                HotReload.RegisterActive(this);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (Application.HotReloadIsEnabled)
            {
                if (Navigation.NavigationStack.Count > 1) 
                {
                    HotReload.UnregisterActive(this);
                }
            }
        }
    }

    [SharpObject] 
    public partial class FlyoutPage : Microsoft.Maui.Controls.FlyoutPage { }

    [SharpObject] 
    public partial class NavigationPage : Microsoft.Maui.Controls.NavigationPage, IEnumerable
    {
        public IEnumerator GetEnumerator() => throw new NotImplementedException();
        public void Add(Microsoft.Maui.Controls.Page page) => this.PushAsync(page);
    }

    [SharpObject]
    public partial class TabbedPage : Microsoft.Maui.Controls.TabbedPage { }
}
