namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.FlyoutBase))]
    public interface IElementFlyoutBaseAttachedProperties
    {
        MenuFlyout ContextFlyout { get; set; }
    }

    [AttachedInterfaces(typeof(Microsoft.Maui.Controls.Element), new[] { typeof(IElementFlyoutBaseAttachedProperties) })]
    public static partial class ElementExtension
    {

    }
}