using System;
namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shell))]
    public partial class Shell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.FlyoutItem),
        containerOfType:typeof(Microsoft.Maui.Controls.ShellSection),
        containerPopertyName:"Items")]
    public partial class FlyoutItem
    {
        public FlyoutItem(FlyoutDisplayOptions displayOptions)
        {
            this.FlyoutDisplayOptions = displayOptions;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Tab),
        containerOfType:typeof(Microsoft.Maui.Controls.ShellContent),
        containerPopertyName:"Items")]
    public partial class Tab
    {
        public Tab(string title, ImageSource icon = null)
        {
            this.Title = title;
            this.Icon = icon;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ShellContent))]
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
    }
}

