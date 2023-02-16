namespace ExampleApp;

using Sharp.UI;

[BindableProperties]
public interface IAngleViewModelProperties
{
    [PropertyCallbacks(propertyChanged: "OnAngleChanged")]
    public double RawAngle { get; set; }

    [PropertyCallbacks(coerceValue: "CoerceAngle")]
    public double Angle { get; set; }

    [DefaultValue(360)]
    public double MaximumAngle { get; set; }
}


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

public class AngleViewModelPage : ContentPage
{
    AngleViewModel viewModel = new AngleViewModel();

    public AngleViewModelPage()
    {
        this.BindingContext = viewModel;
        this.Content = new VStack(e => e.VerticalOptions(LayoutOptions.Center))
        {
            new Slider(0, 500)
                .Value(e => e.Path("RawAngle")),

            new Label()
                .Text(e => e.Path("RawAngle").StringFormat("Raw angle {0:F1}"))
                .FontSize(30),

            new Label()
                .Text(e => e.Path("Angle").StringFormat("Angle {0:F1}"))
                .Rotation(e => e.Path("Angle"))
                .FontSize(30)
        };
    }
}
