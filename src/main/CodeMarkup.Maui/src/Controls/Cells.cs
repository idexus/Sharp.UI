namespace CodeMarkup.Maui
{
    [CodeMarkup]
    public partial class TextCell : Microsoft.Maui.Controls.TextCell
    {
        public TextCell(string text)
        {
            this.Text = text;
        }
    }

    [CodeMarkup] 
    public partial class ImageCell : Microsoft.Maui.Controls.ImageCell { }

    [CodeMarkup] 
    public partial class SwitchCell : Microsoft.Maui.Controls.SwitchCell { }

    [CodeMarkup] 
    public partial class EntryCell : Microsoft.Maui.Controls.EntryCell
    {
        public EntryCell(string placeholder)
        {
            this.Placeholder = placeholder;
        }
    }

    [CodeMarkup] 
    public partial class ViewCell : Microsoft.Maui.Controls.ViewCell { }
}
