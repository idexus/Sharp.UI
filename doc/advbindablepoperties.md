# Advanced scenarios

Sharp.UI provides two attributes, `PropertyCallbacks` and `DefaultValue`, to allow developers to customize properties and their behavior.

### PropertyCallbacks Attribute

The `PropertyCallbacks` attribute allows you to specify four different callbacks for a property: `propertyChanged`, `validateValue`, `coerceValue`, and `defaultValueCreator`.

- `propertyChanged` callback is invoked when the value of the property changes.
- `validateValue` callback is used to validate the value of the property before it is set.
- `coerceValue` callback is used to adjust the value of the property, for example, to ensure that it falls within a certain range.
- `defaultValueCreator` callback is used to create the default value for the property.

### DefaultValue Attribute

The `DefaultValue` attribute allows you to specify the default value for a property. This attribute provides a convenient way to set a default value for a property without having to create a `defaultValueCreator` callback.

### Example



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

Class declaration

```cs
[SharpObject]
public partial class AngleViewModel : BindableObject, IAngleViewModelProperties
{
    static void OnAngleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var viewModel = bindable as AngleViewModel;
        viewModel.Angle = (double)newValue;
    }

    static object CoerceAngle(BindableObject bindable, object value)
    {
        var viewModel = bindable as AngleViewModel;
        double input = (double)value;

        if (input > viewModel.MaximumAngle)
            input = viewModel.MaximumAngle;

        return input;
    }
}
```

Usage

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
                .Rotation(e => e.Path("Angle"))
                .FontSize(30)

        }
        .VerticalOptions(LayoutOptions.Center);
    }
}
```
