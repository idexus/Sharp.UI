using System;
namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.TextCell), 
        constructorWithProperties: new[] { "Text" })] 
    public partial class TextCell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ImageCell))] 
    public partial class ImageCell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SwitchCell))] 
    public partial class SwitchCell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.EntryCell), 
        constructorWithProperties: new[] { "Placeholder" })] 
    public partial class EntryCell { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ViewCell))] 
    public partial class ViewCell { }
}
