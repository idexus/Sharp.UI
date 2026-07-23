using System.Collections;

namespace Sharp.UI
{
    [SharpObject] 
    public partial class ContentPage : Microsoft.Maui.Controls.ContentPage, IHotReloadable
    {
        protected virtual void Build() { return; }

        void IHotReloadable.Reload()
        {
            this.Build();
        }

        protected void InitializeSharpUI()
        {
            (this as IHotReloadable).InitializeSharpUI();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (this is IEnumerable enumerable)
            Unfocus(enumerable);
        }

        private static void Unfocus(IEnumerable element)
        {
            foreach (var child in element)
            {
                if (child is Entry)
                {
                    (child as Entry).Unfocus();
                }
                else if (child is Editor)
                {
                    (child as Editor).Unfocus();
                }
                else if (child is IEnumerable)
                {
                    Unfocus(child as IEnumerable);
                }
            }
        }
    }

    [SharpObject] 
    public partial class FlyoutPage : Microsoft.Maui.Controls.FlyoutPage
    {
    }

    [SharpObject] 
    public partial class NavigationPage : Microsoft.Maui.Controls.NavigationPage, IEnumerable
    {
        public IEnumerator GetEnumerator() { yield return this.CurrentPage; }
        public void Add(Microsoft.Maui.Controls.Page page) => this.PushAsync(page);
    }

    [SharpObject]
    public partial class TabbedPage : Microsoft.Maui.Controls.TabbedPage { }
}
