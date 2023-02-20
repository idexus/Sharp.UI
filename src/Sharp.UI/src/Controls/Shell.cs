namespace Sharp.UI
{
    [SharpObject]
    public partial class Shell : Microsoft.Maui.Controls.Shell { }

    [SharpObject]
    public partial class TabBar : Microsoft.Maui.Controls.TabBar { }

    [SharpObject]
    public partial class FlyoutItem : Microsoft.Maui.Controls.FlyoutItem
    {
        public FlyoutItem(FlyoutDisplayOptions displayOptions)
        {
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
