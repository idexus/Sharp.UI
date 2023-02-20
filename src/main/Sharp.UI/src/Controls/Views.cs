using System.Collections;

namespace Sharp.UI
{
    [SharpObject] 
    public partial class ActivityIndicator : Microsoft.Maui.Controls.ActivityIndicator { }

    [SharpObject] 
    public partial class Border : Microsoft.Maui.Controls.Border { }

    [SharpObject] 
    public partial class BoxView : Microsoft.Maui.Controls.BoxView { }

    [SharpObject]
    public partial class Button : Microsoft.Maui.Controls.Button
    {
        public Button(string text) 
        {
            this.Text = text;
        }
    }

    [SharpObject]
    public partial class CarouselView : Microsoft.Maui.Controls.CarouselView { }

    [SharpObject] 
    public partial class CheckBox : Microsoft.Maui.Controls.CheckBox { }

    [SharpObject]
    [ContentProperty(nameof(ItemTemplate))]
    public partial class CollectionView : Microsoft.Maui.Controls.CollectionView
    {
        public void Add(System.Func<object> loadTemplate) => this.ItemTemplate = new DataTemplate(loadTemplate);
    }

    [SharpObject]
    public partial class ContentView : Microsoft.Maui.Controls.ContentView { }

    [SharpObject] 
    public partial class DatePicker : Microsoft.Maui.Controls.DatePicker { }

    [SharpObject]
    public partial class Editor : Microsoft.Maui.Controls.Editor
    {
        public Editor(string placeholder) 
        {
            this.Placeholder = placeholder;
        }
    }

    [SharpObject]
    public partial class Entry : Microsoft.Maui.Controls.Entry
    {
        public Entry(string placeholder) 
        {
            this.Placeholder = placeholder;
        }
    }

    [SharpObject] 
    public partial class Frame : Microsoft.Maui.Controls.Frame { }

    [SharpObject]
    public partial class GraphicsView : Microsoft.Maui.Controls.GraphicsView
    {
        public GraphicsView(Microsoft.Maui.Graphics.IDrawable Drawable) 
        {
            this.Drawable = Drawable;
        }
    }

    [SharpObject]
    public partial class Image : Microsoft.Maui.Controls.Image
    {
        public Image(Microsoft.Maui.Controls.ImageSource Source) 
        {
            this.Source = Source;
        }
    }

    [SharpObject]
    public partial class ImageButton : Microsoft.Maui.Controls.ImageButton
    {
        public ImageButton(Microsoft.Maui.Controls.ImageSource Source) 
        {
            this.Source = Source;
        }
    }

    [SharpObject] 
    public partial class IndicatorView : Microsoft.Maui.Controls.IndicatorView { }

    [SharpObject]
    public partial class Label : Microsoft.Maui.Controls.Label
    {
        public Label(string text) 
        {
            this.Text = text;
        }
    }

    [SharpObject]
    [ContentProperty(nameof(ItemTemplate))]
    public partial class ListView : Microsoft.Maui.Controls.ListView
    {
        public void Add(Func<Cell> loadTemplate) => this.ItemTemplate = new DataTemplate(loadTemplate);
    }

    [SharpObject] 
    public partial class Picker : Microsoft.Maui.Controls.Picker
    {
        public Picker(string title) 
        {
            this.Title = title;
        }
    }

    [SharpObject]
    public partial class ProgressBar : Microsoft.Maui.Controls.ProgressBar
    {
        public ProgressBar(double progress) 
        {
            this.Progress = progress;
        }
    }

    [SharpObject]
    [ContentProperty(nameof(Content))]
    public partial class RadioButton : Microsoft.Maui.Controls.RadioButton { }

    [SharpObject] 
    public partial class RefreshView : Microsoft.Maui.Controls.RefreshView { }

    [SharpObject] 
    public partial class ScrollView : Microsoft.Maui.Controls.ScrollView { }

    [SharpObject]
    public partial class SearchBar : Microsoft.Maui.Controls.SearchBar
    {
        public SearchBar(string placeholder) 
        {
            this.Placeholder = placeholder;
        }
    }

    [SharpObject] 
    public partial class Slider : Microsoft.Maui.Controls.Slider
    {
        public Slider(double minimum, double maximum, double value) 
        {
            this.Minimum = minimum; this.Maximum = maximum; this.Value = value;
        }

        public Slider(double minimum, double maximum) 
        {
            this.Minimum = minimum; this.Maximum = maximum;
        }
    }

    [SharpObject]
    public partial class Stepper : Microsoft.Maui.Controls.Stepper
    {
        public Stepper(double minimum, double maximum, double increment) 
        {
            this.Minimum = minimum; this.Maximum = maximum; this.Increment = increment;
        }
    }

    [SharpObject] 
    public partial class SwipeView : Microsoft.Maui.Controls.SwipeView { }

    [SharpObject] 
    public partial class Switch : Microsoft.Maui.Controls.Switch { }

    [SharpObject] 
    public partial class TableView : Microsoft.Maui.Controls.TableView
    {
        public TableView()
        {
            this.Root = new Microsoft.Maui.Controls.TableRoot();
        }
    }

    [SharpObject] 
    public partial class TimePicker : Microsoft.Maui.Controls.TimePicker { }

    [SharpObject]
    public partial class WebView : Microsoft.Maui.Controls.WebView
    {
        public WebView(WebViewSource source) 
        {
            this.Source = source;
        }
    }

    [SharpObject]
    public partial class SwipeItem : Microsoft.Maui.Controls.SwipeItem
    {
        public SwipeItem(string text) 
        {
            this.Text = text;
        }
    }

    [SharpObject] 
    public partial class SwipeItemView : Microsoft.Maui.Controls.SwipeItemView { }
}