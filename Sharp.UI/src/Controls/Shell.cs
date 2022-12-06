namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shell))]
    public partial class Shell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.FlyoutItem),
        attachedProperties: new[] { "Shell.ItemTemplate" })]
    public partial class FlyoutItem
    {
        public FlyoutItem(FlyoutDisplayOptions displayOptions)
        {
            this.FlyoutDisplayOptions = displayOptions;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Tab),
        attachedProperties: new[] { "Shell.ItemTemplate" })]
    public partial class Tab
    {
        public Tab(string title, ImageSource icon = null)
        {
            this.Title = title;
            this.Icon = icon;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ShellContent),
        attachedProperties: new[] { "Shell.ItemTemplate" })]
    public partial class ShellContent
    {
        public ShellContent(Type page)
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

