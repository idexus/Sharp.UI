
namespace ExampleApp;

using Microsoft.Maui.Controls.Shapes;
using Sharp.UI;

public sealed partial class MultiBindingPage : ContentPage
{
    string mySourceCode = """
new VStack
{
    new Slider(out var slider1)
        .Minimum(1).Maximum(30),

    new Slider(out var slider2)
        .Minimum(1).Maximum(30),

    new Slider(out var slider3)
        .Minimum(1).Maximum(30),

    new Slider(out var slider4)
        .Minimum(1).Maximum(30),

    new Label()
        .Text(e => e
            .Path(nameof(Slider.Value)).Source(slider1).Convert((double e) => (e > 10 ? true : false))
            .Path(nameof(Slider.Value)).Source(slider2)
            .Path(nameof(Slider.Value)).Source(slider3)
            .Path(nameof(Slider.Value)).Source(slider4)
            .Convert((bool v1, double v2, double v3, double v4) =>
            {
                return $"{v1}, {v2:F2}, {v3:F2}, {v4:F2}";
            }))
}
""";

    protected override void Build()
    {
        Content = new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new Example
            {
                new VStack
                {
                    new Slider(out var slider1)
                        .Minimum(1).Maximum(30),

                    new Slider(out var slider2)
                        .Minimum(1).Maximum(30),

                    new Slider(out var slider3)
                        .Minimum(1).Maximum(30),

                    new Slider(out var slider4)
                        .Minimum(1).Maximum(30),

                    new Label()
                        .Text(e => e
                            .Path(nameof(Slider.Value)).Source(slider1).Convert((double e) => (e > 10 ? true : false))
                            .Path(nameof(Slider.Value)).Source(slider2)
                            .Path(nameof(Slider.Value)).Source(slider3)
                            .Path(nameof(Slider.Value)).Source(slider4)
                            .Convert((bool v1, double v2, double v3, double v4) =>
                            {
                                return $"{v1}, {v2:F2}, {v3:F2}, {v4:F2}";
                            }))
                }
            }
            .IsExpanded(true)
            .Title("Styling and animation example")
            .SourceText(mySourceCode)
        };
    }
}
