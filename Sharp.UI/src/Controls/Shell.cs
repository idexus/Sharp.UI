namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.Shell))]
    public partial class Shell { }

    [SharpObject(typeof(Microsoft.Maui.Controls.TabBar))]
    public partial class TabBar { }

    [SharpObject(typeof(Microsoft.Maui.Controls.FlyoutItem),
        constructorWithProperties: new[] { "FlyoutDisplayOptions" })]
    public partial class FlyoutItem { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Tab),
        constructorWithProperties: new[] { "Title" })]
    public partial class Tab { }

    [SharpObject(typeof(Microsoft.Maui.Controls.ShellContent),
        constructorWithProperties: new[] { "Title", "Content" })]
    public partial class ShellContent
    {
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
