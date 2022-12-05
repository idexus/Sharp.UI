namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.MenuFlyout))]
    public partial class MenuFlyout { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.MenuFlyoutItem),
        constructorWithProperties: new[] {"Text"})]
    public partial class MenuFlyoutItem { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.MenuFlyoutSubItem),
        constructorWithProperties: new[] { "Text" })]
    public partial class MenuFlyoutSubItem { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.FontImageSource),
        constructorWithProperties: new[] { "Glyph", "FontFamily" })]
    public partial class FontImageSource { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.MenuBarItem),
        constructorWithProperties: new[] { "Text" })]
    public partial class MenuBarItem { }
}

