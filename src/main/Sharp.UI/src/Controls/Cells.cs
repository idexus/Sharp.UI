namespace Sharp.UI
{
    [SharpObject]
    public partial class TextCell : Microsoft.Maui.Controls.TextCell
    {
        public TextCell(string text)
        {
            this.Text = text;
        }
    }

    [SharpObject] 
    public partial class ImageCell : Microsoft.Maui.Controls.ImageCell { }

    [SharpObject] 
    public partial class SwitchCell : Microsoft.Maui.Controls.SwitchCell { }

    [SharpObject] 
    public partial class EntryCell : Microsoft.Maui.Controls.EntryCell
    {
        public EntryCell(string placeholder)
        {
            this.Placeholder = placeholder;
        }
    }

    [SharpObject] 
    public partial class ViewCell : Microsoft.Maui.Controls.ViewCell { }
}
