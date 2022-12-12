namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.FlyoutBase))]
    public interface IElementFlyoutBaseAttachedProperties
    {
        Microsoft.Maui.Controls.MenuFlyout FlyoutBaseContextFlyout { get; set; }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Element))]
    [AttachedInterfaces(new[] { typeof(IElementFlyoutBaseAttachedProperties) })]
    public static class ElementExtension
    {

    }
}

