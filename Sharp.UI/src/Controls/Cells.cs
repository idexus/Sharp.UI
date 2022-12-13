namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.TextCell), 
        constructorWithProperties: new[] { "Text" })] 
    public partial class TextCell { }

    [SharpObject(typeof(Microsoft.Maui.Controls.ImageCell))] 
    public partial class ImageCell { }

    [SharpObject(typeof(Microsoft.Maui.Controls.SwitchCell))] 
    public partial class SwitchCell { }

    [SharpObject(typeof(Microsoft.Maui.Controls.EntryCell), 
        constructorWithProperties: new[] { "Placeholder" })] 
    public partial class EntryCell { }

    [SharpObject(typeof(Microsoft.Maui.Controls.ViewCell))] 
    public partial class ViewCell { }
}
