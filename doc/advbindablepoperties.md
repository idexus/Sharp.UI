# Advanced scenarios


For properties, you can use the following additional attributes

- `[PropertyCallbacksAttribute(propertyChanged,validateValue,coerceValue,defaultValueCreator)]` to define callback names
- `[DefaultValue(value)]` to define default value

### Interface declaration

```cs
[BindableProperties]
public interface IAngleViewModelProperties
{
    [PropertyCallbacks(propertyChanged: "OnAngleChanged")]
    public double RawAngle { get; set; }

    [PropertyCallbacks(coerceValue: "CoerceAngle")]
    public double Angle { get; set; }

    [DefaultValue(360.0)]
    public double MaximumAngle { get; set; }
}
```



### Class declaration

```cs
[SharpObject]
public partial class AngleViewModel : BindableObject, IAngleViewModelProperties
{
    static void OnAngleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        AngleViewModel viewModel = bindable as AngleViewModel;
        viewModel.Angle = (double)newValue;
    }

    static object CoerceAngle(BindableObject bindable, object value)
    {
        AngleViewModel viewModel = bindable as AngleViewModel;
        double input = (double)value;

        if (input > viewModel.MaximumAngle)
            input = viewModel.MaximumAngle;

        return input;
    }
}
```

### Usage

```cs
public class AngleViewModelPage : ContentPage
{
    AngleViewModel viewModel = new AngleViewModel();

    public AngleViewModelPage()
    {
        this.BindingContext = viewModel;
        this.Content = new VStack
        {
            new Slider(0, 500)
                .Value(e => e.Path("RawAngle")),

            new Label()
                .Text(e => e.Path("RawAngle").StringFormat("Raw angle {0}"))
                .FontSize(30),

            new Label()
                .Text(e => e.Path("Angle").StringFormat("Angle {0}"))
                .FontSize(30)

        }
        .VerticalOptions(LayoutOptions.Center);
    }
}
```