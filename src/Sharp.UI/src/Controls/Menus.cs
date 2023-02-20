namespace Sharp.UI
{
    [SharpObject]
    public partial class MenuFlyout : Microsoft.Maui.Controls.MenuFlyout { }

    [SharpObject]
    public partial class MenuFlyoutItem : Microsoft.Maui.Controls.MenuFlyoutItem
    {
        public MenuFlyoutItem(string text)
        {
            this.Text = text;
        }
    }

    [SharpObject]
    public partial class MenuFlyoutSubItem : Microsoft.Maui.Controls.MenuFlyoutSubItem
    {
        public MenuFlyoutSubItem(string text)
        {
            this.Text = text;
        }
    }

    [SharpObject]
    public partial class FontImageSource : Microsoft.Maui.Controls.FontImageSource
    {
        public FontImageSource(string glyph, string fontFamily)
        {
            this.Glyph = glyph; this.FontFamily = fontFamily;
        }
    }

    [SharpObject]
    public partial class MenuBarItem : Microsoft.Maui.Controls.MenuBarItem
    {
        public MenuBarItem(string text)
        {
            this.Text = text;
        }
    }
}