using System.Collections;

namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.ActivityIndicator))] 
    public partial class ActivityIndicator { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Border))] 
    public partial class Border { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.BoxView))] 
    public partial class BoxView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Button), 
        constructorWithProperties: new[] { "Text" })] 
    public partial class Button { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.CarouselView))]
    public partial class CarouselView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.CheckBox))] 
    public partial class CheckBox { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.CollectionView))] 
    public partial class CollectionView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ContentView))] 
    public partial class ContentView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DatePicker))] 
    public partial class DatePicker { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Editor), 
        constructorWithProperties: new[] { "Placeholder" })]
    public partial class Editor { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Entry), 
        constructorWithProperties: new[] { "Placeholder" })]
    public partial class Entry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Frame))] 
    public partial class Frame { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.GraphicsView), 
        constructorWithProperties: new[] { "Drawable" })]
    public partial class GraphicsView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Image), 
        constructorWithProperties: new[] { "Source" })]
    public partial class Image { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ImageButton), 
        constructorWithProperties: new[] { "Source" })]
    public partial class ImageButton { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.IndicatorView))] 
    public partial class IndicatorView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Label), 
        constructorWithProperties: new[] { "Text" })]
    public partial class Label { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ListView), 
        constructorWithProperties: new[] { "ItemsSource" })] 
    public partial class ListView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Picker), 
        constructorWithProperties: new[] { "Title" })] 
    public partial class Picker { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ProgressBar), 
        constructorWithProperties: new[] { "Progress" })]
    public partial class ProgressBar { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.RadioButton), 
        constructorWithProperties: new[] { "Content" },
        containerPopertyName: "Content")]
    public partial class RadioButton { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.RefreshView))] 
    public partial class RefreshView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ScrollView))] 
    public partial class ScrollView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SearchBar), 
        constructorWithProperties: new[] { "Placeholder" })]
    public partial class SearchBar { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Slider), 
        constructorWithProperties: new[] { "Minimum", "Maximum" })] 
    public partial class Slider { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Stepper), 
        constructorWithProperties: new[] { "Minimum", "Maximum", "Increment" })]
    public partial class Stepper { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SwipeView))] 
    public partial class SwipeView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Switch))] 
    public partial class Switch { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.TableView), 
        generateNoParamConstructor: false)]
    public partial class TableView
    {
        public TableView()
        {
            this.Root = new Microsoft.Maui.Controls.TableRoot();
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.TimePicker))] 
    public partial class TimePicker { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.WebView), 
        constructorWithProperties: new[] {"Source"})]
    public partial class WebView { }

    //------ swipe items ------

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SwipeItem), 
        constructorWithProperties: new[] { "Text" })]
    public partial class SwipeItem { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SwipeItemView))] 
    public partial class SwipeItemView { }

    //------ table view (sealed) ------

    [MauiWrapper(typeof(Microsoft.Maui.Controls.TableSection), 
        constructorWithProperties: new[] { "Title" })]
    public partial class TableSection { }

}