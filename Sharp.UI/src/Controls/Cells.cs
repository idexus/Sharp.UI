namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.TextCell))] 
    public partial class TextCell
    {
        public TextCell(string text) : this()
        {
            this.Text = text;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.ImageCell))] 
    public partial class ImageCell { }

    [SharpObject(typeof(Microsoft.Maui.Controls.SwitchCell))] 
    public partial class SwitchCell { }

    [SharpObject(typeof(Microsoft.Maui.Controls.EntryCell))] 
    public partial class EntryCell
    {
        public EntryCell(string placeholder) : this()
        {
            this.Placeholder = placeholder;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.ViewCell))] 
    public partial class ViewCell { }
}
