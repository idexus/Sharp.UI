namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.BaseShellItem),
        attachedProperties: new[] { "Shell.ItemTemplate" },
        attachedPropertiesTypes: new[] { typeof(DataTemplate) })]
    public static class IBaseShellItemExtension
    {

    }
}

