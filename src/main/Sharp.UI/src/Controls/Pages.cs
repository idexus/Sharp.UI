using System.Collections;
using System.Diagnostics;

namespace Sharp.UI
{
    [SharpObject] 
    public partial class ContentPage : Microsoft.Maui.Controls.ContentPage
    {
        //static int MainPageId = 0;
        //readonly int PageId = 0;

        public ContentPage()
        {
            //PageId = ++MainPageId;
            //Debug.WriteLine($"--- Created --- : {this.GetType()} : {PageId}");

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
            //Debug.WriteLine($"--- Appearing --- : {this.GetType()} : {PageId}");


            base.OnAppearing();
            if (Application.HotReloadIsEnabled)
            {
                HotReload.RegisterActive(this);
            }
        }

        protected override void OnDisappearing()
        {
            //Debug.WriteLine($"--- Disappearing --- : {this.GetType()} : {PageId}");

            base.OnDisappearing();
            if (Application.HotReloadIsEnabled)
            {
                if (Shell.Current.Navigation.NavigationStack.Count > 1) 
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
