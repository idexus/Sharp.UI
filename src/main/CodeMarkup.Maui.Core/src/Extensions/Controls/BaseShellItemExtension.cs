namespace CodeMarkup.Maui
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.Shell))]
    public interface IBaseShellItemShellAttachedProperties
    {
        [AttachedName("ItemTemplateProperty")]
        DataTemplate ShellItemTemplate { get; set; }
    }

    [AttachedInterfaces(typeof(Microsoft.Maui.Controls.BaseShellItem), new[] { typeof(IBaseShellItemShellAttachedProperties) })]
    public static partial class BaseShellItemExtension
    {

    }
}