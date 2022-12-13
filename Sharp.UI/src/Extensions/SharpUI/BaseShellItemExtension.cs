namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.Shell))]
    public interface IBaseShellItemShellAttachedProperties
    {
        DataTemplate ShellItemTemplate { get; set; }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.BaseShellItem))]
    [AttachedInterfaces(new[] {typeof(IBaseShellItemShellAttachedProperties) })]
    public static class BaseShellItemExtension
    {

    }
}