namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.MenuFlyout))]
    public partial class MenuFlyout { }

    [SharpObject(typeof(Microsoft.Maui.Controls.MenuFlyoutItem),
        constructorWithProperties: new[] {"Text"})]
    public partial class MenuFlyoutItem { }

    [SharpObject(typeof(Microsoft.Maui.Controls.MenuFlyoutSubItem),
        constructorWithProperties: new[] { "Text" })]
    public partial class MenuFlyoutSubItem { }

    [SharpObject(typeof(Microsoft.Maui.Controls.FontImageSource),
        constructorWithProperties: new[] { "Glyph", "FontFamily" })]
    public partial class FontImageSource { }

    [SharpObject(typeof(Microsoft.Maui.Controls.MenuBarItem),
        constructorWithProperties: new[] { "Text" })]
    public partial class MenuBarItem { }
}

