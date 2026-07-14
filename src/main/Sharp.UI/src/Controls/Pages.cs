using System.Collections;

namespace Sharp.UI
{
    [SharpObject] 
    public partial class ContentPage : Microsoft.Maui.Controls.ContentPage, ISharpUIContent
    {
        public void InitializeSharpUI()
        {
            this.Rebuild();
#if DEBUG
            HotReloader.Register(this);
#endif
        }

        protected virtual View Build() { return null; }

        internal void Rebuild() {
            var build = this.Build();
            if (build != null)
            this.Content = build;         
        }

        void ISharpUIContent.Rebuild()
        {
            Rebuild();
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
