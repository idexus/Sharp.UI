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
}

