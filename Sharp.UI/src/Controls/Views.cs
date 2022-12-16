namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.ActivityIndicator))] 
    public partial class ActivityIndicator { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Border))] 
    public partial class Border { }

    [SharpObject(typeof(Microsoft.Maui.Controls.BoxView))] 
    public partial class BoxView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Button),
        constructorWithProperties: new[] { "Text" })]
    public partial class Button { }

    [SharpObject(typeof(Microsoft.Maui.Controls.CarouselView))]
    public partial class CarouselView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.CheckBox))] 
    public partial class CheckBox { }

    [SharpObject(typeof(Microsoft.Maui.Controls.CollectionView))] 
    public partial class CollectionView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.ContentView))] 
    public partial class ContentView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.DatePicker))] 
    public partial class DatePicker { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Editor), 
        constructorWithProperties: new[] { "Placeholder" })]
    public partial class Editor { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Entry), 
        constructorWithProperties: new[] { "Placeholder" })]
    public partial class Entry { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Frame))] 
    public partial class Frame { }

    [SharpObject(typeof(Microsoft.Maui.Controls.GraphicsView), 
        constructorWithProperties: new[] { "Drawable" })]
    public partial class GraphicsView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Image), 
        constructorWithProperties: new[] { "Source" })]
    public partial class Image { }

    [SharpObject(typeof(Microsoft.Maui.Controls.ImageButton), 
        constructorWithProperties: new[] { "Source" })]
    public partial class ImageButton { }

    [SharpObject(typeof(Microsoft.Maui.Controls.IndicatorView))] 
    public partial class IndicatorView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Label), 
        constructorWithProperties: new[] { "Text" })]
    public partial class Label { }

    [SharpObject(typeof(Microsoft.Maui.Controls.ListView), 
        constructorWithProperties: new[] { "ItemsSource" })] 
    public partial class ListView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Picker), 
        constructorWithProperties: new[] { "Title" })] 
    public partial class Picker { }

    [SharpObject(typeof(Microsoft.Maui.Controls.ProgressBar), 
        constructorWithProperties: new[] { "Progress" })]
    public partial class ProgressBar { }

    [SharpObject(typeof(Microsoft.Maui.Controls.RadioButton), 
        constructorWithProperties: new[] { "Content" },
        containerPopertyName: "Content")]
    public partial class RadioButton { }

    [SharpObject(typeof(Microsoft.Maui.Controls.RefreshView))] 
    public partial class RefreshView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.ScrollView))] 
    public partial class ScrollView { }

    [SharpObject(typeof(Microsoft.Maui.Controls.SearchBar), 
        constructorWithProperties: new[] { "Placeholder" })]
    public partial class SearchBar { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Slider), 
        constructorWithProperties: new[] { "Minimum", "Maximum" })] 
    public partial class Slider { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Stepper), 
        constructorWithProperties: new[] { "Minimum", "Maximum", "Increment" })]
    public partial class Stepper { }

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

    [SharpObject(typeof(Microsoft.Maui.Controls.WebView), 
        constructorWithProperties: new[] {"Source"})]
    public partial class WebView { }

    //------ swipe items ------

    [SharpObject(typeof(Microsoft.Maui.Controls.SwipeItem), 
        constructorWithProperties: new[] { "Text" })]
    public partial class SwipeItem { }

    [SharpObject(typeof(Microsoft.Maui.Controls.SwipeItemView))] 
    public partial class SwipeItemView { }

    //------ table view (sealed) ------

    [SharpObject(typeof(Microsoft.Maui.Controls.TableSection), 
        constructorWithProperties: new[] { "Title" })]
    public partial class TableSection { }

}