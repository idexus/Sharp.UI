using System.Collections;

namespace CodeMarkup.Maui
{
    [CodeMarkup] 
    public partial class ActivityIndicator : Microsoft.Maui.Controls.ActivityIndicator { }

    [CodeMarkup] 
    public partial class Border : Microsoft.Maui.Controls.Border { }

    [CodeMarkup] 
    public partial class BoxView : Microsoft.Maui.Controls.BoxView { }

    [CodeMarkup]
    public partial class Button : Microsoft.Maui.Controls.Button
    {
        public Button(string text) 
        {
            this.Text = text;
        }
    }

    [CodeMarkup]
    public partial class CarouselView : Microsoft.Maui.Controls.CarouselView { }

    [CodeMarkup] 
    public partial class CheckBox : Microsoft.Maui.Controls.CheckBox { }

    [CodeMarkup]
    public partial class CollectionView : Microsoft.Maui.Controls.CollectionView
    {
        public void Add(System.Func<object> loadTemplate) => this.ItemTemplate = new DataTemplate(loadTemplate);
    }

    [CodeMarkup]
    public partial class ContentView : Microsoft.Maui.Controls.ContentView { }

    [CodeMarkup] 
    public partial class DatePicker : Microsoft.Maui.Controls.DatePicker { }

    [CodeMarkup]
    public partial class Editor : Microsoft.Maui.Controls.Editor
    {
        public Editor(string placeholder) 
        {
            this.Placeholder = placeholder;
        }
    }

    [CodeMarkup]
    public partial class Entry : Microsoft.Maui.Controls.Entry
    {
        public Entry(string placeholder) 
        {
            this.Placeholder = placeholder;
        }
    }

    [CodeMarkup] 
    public partial class Frame : Microsoft.Maui.Controls.Frame { }

    [CodeMarkup]
    public partial class GraphicsView : Microsoft.Maui.Controls.GraphicsView
    {
        public GraphicsView(Microsoft.Maui.Graphics.IDrawable Drawable) 
        {
            this.Drawable = Drawable;
        }
    }

    [CodeMarkup]
    public partial class Image : Microsoft.Maui.Controls.Image
    {
        public Image(Microsoft.Maui.Controls.ImageSource Source) 
        {
            this.Source = Source;
        }
    }

    [CodeMarkup]
    public partial class ImageButton : Microsoft.Maui.Controls.ImageButton
    {
        public ImageButton(Microsoft.Maui.Controls.ImageSource Source) 
        {
            this.Source = Source;
        }
    }

    [CodeMarkup] 
    public partial class IndicatorView : Microsoft.Maui.Controls.IndicatorView { }

    [CodeMarkup]
    public partial class Label : Microsoft.Maui.Controls.Label
    {
        public Label(string text) 
        {
            this.Text = text;
        }
    }

    [CodeMarkup]
    public partial class ListView : Microsoft.Maui.Controls.ListView
    {
        public void Add(Func<Cell> loadTemplate) => this.ItemTemplate = new DataTemplate(loadTemplate);
    }

    [CodeMarkup] 
    public partial class Picker : Microsoft.Maui.Controls.Picker
    {
        public Picker(string title) 
        {
            this.Title = title;
        }
    }

    [CodeMarkup]
    public partial class ProgressBar : Microsoft.Maui.Controls.ProgressBar
    {
        public ProgressBar(double progress) 
        {
            this.Progress = progress;
        }
    }

    [CodeMarkup]
    [ContentProperty(nameof(Content))]
    public partial class RadioButton : Microsoft.Maui.Controls.RadioButton { }

    [CodeMarkup] 
    public partial class RefreshView : Microsoft.Maui.Controls.RefreshView { }

    [CodeMarkup] 
    public partial class ScrollView : Microsoft.Maui.Controls.ScrollView { }

    [CodeMarkup]
    public partial class SearchBar : Microsoft.Maui.Controls.SearchBar
    {
        public SearchBar(string placeholder) 
        {
            this.Placeholder = placeholder;
        }
    }

    [CodeMarkup] 
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

    [CodeMarkup]
    public partial class Stepper : Microsoft.Maui.Controls.Stepper
    {
        public Stepper(double minimum, double maximum, double increment) 
        {
            this.Minimum = minimum; this.Maximum = maximum; this.Increment = increment;
        }
    }

    [CodeMarkup] 
    public partial class SwipeView : Microsoft.Maui.Controls.SwipeView { }

    [CodeMarkup] 
    public partial class Switch : Microsoft.Maui.Controls.Switch { }

    [CodeMarkup] 
    public partial class TableView : Microsoft.Maui.Controls.TableView
    {
        public TableView()
        {
            this.Root = new Microsoft.Maui.Controls.TableRoot();
        }
    }

    [CodeMarkup] 
    public partial class TimePicker : Microsoft.Maui.Controls.TimePicker { }

    [CodeMarkup]
    public partial class WebView : Microsoft.Maui.Controls.WebView
    {
        public WebView(WebViewSource source) 
        {
            this.Source = source;
        }
    }

    [CodeMarkup]
    public partial class SwipeItem : Microsoft.Maui.Controls.SwipeItem
    {
        public SwipeItem(string text) 
        {
            this.Text = text;
        }
    }

    [CodeMarkup] 
    public partial class SwipeItemView : Microsoft.Maui.Controls.SwipeItemView { }
}