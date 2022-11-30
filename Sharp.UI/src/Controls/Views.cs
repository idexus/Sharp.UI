using System.Collections;

namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.ActivityIndicator))] //OK
    public partial class ActivityIndicator { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Border))] //OK
    public partial class Border { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.BoxView))] //OK
    public partial class BoxView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Button), //OK
        constructorWithProperties: new[] { "Text" })] 
    public partial class Button { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.CarouselView))]
    public partial class CarouselView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.CheckBox))] //OK
    public partial class CheckBox { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.CollectionView))] //OK
    public partial class CollectionView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ContentView))] //OK
    public partial class ContentView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DatePicker))] //OK
    public partial class DatePicker { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Editor), //OK
        constructorWithProperties: new[] { "Placeholder" })]
    public partial class Editor { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Entry), //OK
        constructorWithProperties: new[] { "Placeholder" })]
    public partial class Entry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Frame))] //OK
    public partial class Frame { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.GraphicsView), //OK
        constructorWithProperties: new[] { "Drawable" })]
    public partial class GraphicsView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Image), //OK
        constructorWithProperties: new[] { "Source" })]
    public partial class Image { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ImageButton), //OK
        constructorWithProperties: new[] { "Source" })]
    public partial class ImageButton { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.IndicatorView))] //OK
    public partial class IndicatorView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Label), //OK
        constructorWithProperties: new[] { "Text" })]
    public partial class Label { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ListView), //OK
        constructorWithProperties: new[] { "ItemsSource" })] 
    public partial class ListView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Picker), //OK
        constructorWithProperties: new[] { "Title" })] 
    public partial class Picker { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ProgressBar), //OK
        constructorWithProperties: new[] { "Progress" })]
    public partial class ProgressBar { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.RadioButton), //OK
        constructorWithProperties: new[] { "Content" },
        containerOfType:typeof(object),
        containerPopertyName: "Content",
        singleItemContainer: true)]
    public partial class RadioButton { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.RefreshView))] //OK
    public partial class RefreshView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ScrollView))] //OK
    public partial class ScrollView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SearchBar), //OK
        constructorWithProperties: new[] { "Placeholder" })]
    public partial class SearchBar { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Slider), //OK
        constructorWithProperties: new[] { "Minimum", "Maximum" })] 
    public partial class Slider { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Stepper), //OK
        constructorWithProperties: new[] { "Minimum", "Maximum", "Increment" })]
    public partial class Stepper { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SwipeView))] //OK
    public partial class SwipeView { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Switch))] //OK
    public partial class Switch { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.TableView), //OK
        generateNoParamConstructor: false,
        containerOfType:typeof(Microsoft.Maui.Controls.TableSection),
        containerPopertyName:"Root",
        singleItemContainer:false)]
    public partial class TableView
    {
        public TableView()
        {
            this.Root = new Microsoft.Maui.Controls.TableRoot();
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.TimePicker))] //OK
    public partial class TimePicker { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.WebView), //OK
        constructorWithProperties: new[] {"Source"})]
    public partial class WebView { }

    //------ swipe items ------

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SwipeItem), //OK
        constructorWithProperties: new[] { "Text" })]
    public partial class SwipeItem { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SwipeItemView))] //OK
    public partial class SwipeItemView { }

    //------ table view (sealed) ------

    [MauiWrapper(typeof(Microsoft.Maui.Controls.TableSection), //OK
        constructorWithProperties: new[] { "Title" },
        containerOfType: typeof(Microsoft.Maui.Controls.Cell),
        containerPopertyName: "this",
        singleItemContainer: false)]
    public partial class TableSection
    {

    }



}