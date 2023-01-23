using System.Collections;

namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.ActivityIndicator))] 
    public partial class ActivityIndicator { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Border))] 
    public partial class Border { }

    [SharpObject(typeof(Microsoft.Maui.Controls.BoxView))] 
    public partial class BoxView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Button))]
    public partial class Button
    {
        public Button(string text) : this()
        {
            this.Text = text;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.CarouselView))]
    public partial class CarouselView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.CheckBox))] 
    public partial class CheckBox { }

    [SharpObject(typeof(Microsoft.Maui.Controls.CollectionView))]
    public partial class CollectionView : IEnumerable
    {
        public IEnumerator GetEnumerator() { yield return this.ItemTemplate; }
        public void Add(DataTemplate dataTemplate) => this.ItemTemplate = dataTemplate;
        public void Add(System.Func<object> loadTemplate) => this.ItemTemplate = new DataTemplate(loadTemplate);
    }    

    [SharpObject(typeof(Microsoft.Maui.Controls.ContentView))] 
    public partial class ContentView
    {
        public ContentView()
        {
            var attribute = this.GetType().CustomAttributes.FirstOrDefault(e => e.AttributeType.Name.Equals("ViewModelAttribute"));

#if DEBUG
            HotReload.RegisterActive(this);
            if (attribute == null && HotReload.BindingContext != null) BindingContext = HotReload.BindingContext;
#endif

            if (attribute != null && BindingContext == null)
            {
                var type = attribute.ConstructorArguments.FirstOrDefault().Value as Type;
                if (BindingContext == null && Application.ServiceProvider != null)
                {
                    BindingContext = ActivatorUtilities.GetServiceOrCreateInstance(Application.ServiceProvider, type);
                }
            }
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.DatePicker))] 
    public partial class DatePicker { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Editor))]
    public partial class Editor
    {
        public Editor(string placeholder) : this()
        {
            this.Placeholder = placeholder;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Entry))]
    public partial class Entry
    {
        public Entry(string placeholder) : this()
        {
            this.Placeholder = placeholder;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Frame))] 
    public partial class Frame { }

    [SharpObject(typeof(Microsoft.Maui.Controls.GraphicsView))]
    public partial class GraphicsView
    {
        public GraphicsView(Microsoft.Maui.Graphics.IDrawable Drawable) : this()
        {
            this.Drawable = Drawable;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Image))]
    public partial class Image
    {
        public Image(Microsoft.Maui.Controls.ImageSource Source) : this()
        {
            this.Source = Source;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.ImageButton))]
    public partial class ImageButton
    {
        public ImageButton(Microsoft.Maui.Controls.ImageSource Source) : this()
        {
            this.Source = Source;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.IndicatorView))] 
    public partial class IndicatorView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Label))]
    public partial class Label
    {
        public Label(string text) : this()
        {
            this.Text = text;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.ListView))]
    public partial class ListView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Picker))] 
    public partial class Picker
    {
        public Picker(string title) : this()
        {
            this.Title = title;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.ProgressBar))]
    public partial class ProgressBar
    {
        public ProgressBar(double progress) : this()
        {
            this.Progress = progress;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.RadioButton))]
    [ContentProperty("Content")]
    public partial class RadioButton { }

    [SharpObject(typeof(Microsoft.Maui.Controls.RefreshView))] 
    public partial class RefreshView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.ScrollView))] 
    public partial class ScrollView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.SearchBar))]
    public partial class SearchBar
    {
        public SearchBar(string placeholder) : this()
        {
            this.Placeholder = placeholder;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Slider))] 
    public partial class Slider
    {
        public Slider(double minimum, double maximum, double value) : this()
        {
            this.Minimum = minimum; this.Maximum = maximum; this.Value = value;
        }

        public Slider(double minimum, double maximum) : this()
        {
            this.Minimum = minimum; this.Maximum = maximum;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Stepper))]
    public partial class Stepper
    {
        public Stepper(double minimum, double maximum, double increment) : this()
        {
            this.Minimum = minimum; this.Maximum = maximum; this.Increment = increment;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.SwipeView))] 
    public partial class SwipeView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Switch))] 
    public partial class Switch { }

    [SharpObject(typeof(Microsoft.Maui.Controls.TableView))] 
    public partial class TableView
    {
        public TableView()
        {
            this.Root = new Microsoft.Maui.Controls.TableRoot();
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.TimePicker))] 
    public partial class TimePicker { }

    [SharpObject(typeof(Microsoft.Maui.Controls.WebView))]
    public partial class WebView
    {
        public WebView(WebViewSource source) : this()
        {
            this.Source = source;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.SwipeItem))]
    public partial class SwipeItem
    {
        public SwipeItem(string text) : this()
        {
            this.Text = text;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.SwipeItemView))] 
    public partial class SwipeItemView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.TableSection))]
    public partial class TableSection
    {
        public TableSection(string title) : this()
        {
            this.Title = title;
        }
    }

}