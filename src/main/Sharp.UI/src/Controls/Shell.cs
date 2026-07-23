using System.Collections;

namespace Sharp.UI
{
    [SharpObject]
    public partial class Shell : Microsoft.Maui.Controls.Shell, IHotReloadable
    {
        protected virtual void Build() { return; }

        void IHotReloadable.Reload()
        {
            this.Items.Clear();
            this.Build();
        }

        protected void InitializeSharpUI()
        {
            (this as IHotReloadable).InitializeSharpUI();
        }
    }

    [SharpObject]
    public partial class TabBar : Microsoft.Maui.Controls.TabBar { }

    [SharpObject]
    public partial class FlyoutItem : Microsoft.Maui.Controls.FlyoutItem
    {
        public FlyoutItem(FlyoutDisplayOptions displayOptions)
        {
            this.FlyoutDisplayOptions = displayOptions;
        }

        public FlyoutItem(string title)
        {
            this.Title = title;
        }

        public FlyoutItem(string title, FlyoutDisplayOptions displayOptions)
        {
            this.Title = title;
            this.FlyoutDisplayOptions = displayOptions;
        }
    }

    [SharpObject]
    public partial class Tab : Microsoft.Maui.Controls.Tab
    {
        public Tab(string title) 
        {
            this.Title = title;
        }
    }

    [SharpObject]
    public partial class ShellContent : Microsoft.Maui.Controls.ShellContent
    {
        public ShellContent(string title, object content) 
        {
            this.Title = title; this.Content = content;
        }

        protected ShellContent(Type page) 
        {
            this.ContentTemplate = new DataTemplate(page);
        }
    }

    public class ShellContent<T> : ShellContent
        where T : Page
    {
        public ShellContent() : base(typeof(T)) { }
        public ShellContent(string title) : base(typeof(T))
        {
            this.Title = title;
        }
    }
}
