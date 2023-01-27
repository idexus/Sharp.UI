namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.Shell))]
    public partial class Shell { }

    [SharpObject(typeof(Microsoft.Maui.Controls.TabBar))]
    public partial class TabBar { }

    [SharpObject(typeof(Microsoft.Maui.Controls.FlyoutItem))]
    public partial class FlyoutItem
    {
        public FlyoutItem(FlyoutDisplayOptions displayOptions)
        {
            this.FlyoutDisplayOptions = displayOptions;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Tab))]
    public partial class Tab
    {
        public Tab(string title) : this()
        {
            this.Title = title;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.ShellContent))]
    public partial class ShellContent
    {
        public ShellContent(string title, object content) : this()
        {
            this.Title = title; this.Content = content;
        }

        protected ShellContent(Type page) : this()
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
