namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.MenuFlyout))]
    public partial class MenuFlyout { }

    [SharpObject(typeof(Microsoft.Maui.Controls.MenuFlyoutItem))]
    public partial class MenuFlyoutItem
    {
        public MenuFlyoutItem(string text) : this()
        {
            this.Text = text;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.MenuFlyoutSubItem))]
    public partial class MenuFlyoutSubItem
    {
        public MenuFlyoutSubItem(string text) : this()
        {
            this.Text = text;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.FontImageSource))]
    public partial class FontImageSource
    {
        public FontImageSource(string glyph, string fontFamily) : this()
        {
            this.Glyph = glyph; this.FontFamily = fontFamily;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.MenuBarItem))]
    public partial class MenuBarItem
    {
        public MenuBarItem(string text) : this()
        {
            this.Text = text;
        }
    }
}