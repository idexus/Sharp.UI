using System;
namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.TextCell), //OK
        constructorWithProperties: new[] { "Text" })] 
    public partial class TextCell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ImageCell))] //OK
    public partial class ImageCell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SwitchCell))] //OK
    public partial class SwitchCell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.EntryCell), //OK
        constructorWithProperties: new[] { "Placeholder" })] 
    public partial class EntryCell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ViewCell))] //OK
    public partial class ViewCell { }
}
