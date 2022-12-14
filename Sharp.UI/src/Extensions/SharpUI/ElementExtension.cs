namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.FlyoutBase))]
    public interface IElementFlyoutBaseAttachedProperties
    {
        MenuFlyout ContextFlyout { get; set; }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Element))]
    [AttachedInterfaces(new[] { typeof(IElementFlyoutBaseAttachedProperties) })]
    public static class ElementExtension
    {

    }
}

