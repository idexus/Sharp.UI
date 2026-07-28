
namespace ExampleApp;

using Microsoft.Maui.Controls.Shapes;
using Sharp.UI;

public sealed partial class MultiBindingPage : ContentPage
{
    string mySourceCode1 = """
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
            .MultiConvert((bool v1, double v2, double v3, double v4) =>
            {
                return $"{v1}, {v2:F2}, {v3:F2}, {v4:F2}";
            })),
}
""";

    string mySourceCode2 = """
new VStack
{
    new HStack {
        new Label("Terms"),
        new CheckBox(out var terms),
    },

    new HStack {
        new Label("Privacy"),
        new CheckBox(out var privacy),
    },

    new HStack {
        new Label("Markwting"),
        new CheckBox(out var marketing),
    },

    new Button()
        .IsEnabled(e => e
            .Path(nameof(CheckBox.IsChecked)).Source(terms)
            .Path(nameof(CheckBox.IsChecked)).Source(privacy)
            .Path(nameof(CheckBox.IsChecked)).Source(marketing)
            .MultiAll())
}
""";

    string mySourceCode3 = """
new VStack
{
    new ContentView(out var rect)
        .SizeRequest(100,100)
        .Background(Colors.Red),

    new Entry()
        .Text(e => e
            .Path(nameof(ContentView.WidthRequest)).Source(rect)
            .Path(nameof(ContentView.HeightRequest)).Source(rect)
            .MultiMode(BindingMode.TwoWay)
            .MultiConvert((double w, double h) => $"{w} x {h}")
            .MultiConvertBack((string s) =>
            {
                var parts = s.Split('x');
                try {
                    return (double.Parse(parts[0]), double.Parse(parts[1]));
                }
                catch
                {
                    return (100, 100);
                }
            }))
}
""";
    protected override void Build()
    {
        Content = new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new VStack {
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
                                .MultiConvert((bool v1, double v2, double v3, double v4) =>
                                {
                                    return $"{v1}, {v2:F2}, {v3:F2}, {v4:F2}";
                                })),
                    }
                }
                .IsExpanded(true)
                .Title("Multi-Binding example")
                .SourceText(mySourceCode1),

                new Example
                {
                    new VStack
                    {
                        new HStack {
                            new CheckBox(out var terms),
                            new Label("Terms").CenterVertically(),
                        },

                        new HStack {
                            new CheckBox(out var privacy),
                            new Label("Privacy").CenterVertically(),
                        },

                        new HStack {
                            new CheckBox(out var marketing),
                            new Label("Marketing").CenterVertically(),
                        },

                        new Button("OK")
                            .WidthRequest(300)
                            .IsEnabled(e => e
                                .Path(nameof(CheckBox.IsChecked)).Source(terms)
                                .Path(nameof(CheckBox.IsChecked)).Source(privacy)
                                .Path(nameof(CheckBox.IsChecked)).Source(marketing)
                                .MultiAll())
                    }
                }
                .IsExpanded(true)
                .Title("MultiAll() example")
                .SourceText(mySourceCode2),

                new Example
                {
                    new VStack
                    {
                        new ContentView(out var rect)
                            .SizeRequest(100,100)
                            .Background(Colors.Red),

                        new Entry()
                            .Text(e => e
                                .Path(nameof(ContentView.WidthRequest)).Source(rect)
                                .Path(nameof(ContentView.HeightRequest)).Source(rect)
                                .MultiMode(BindingMode.TwoWay)
                                .MultiConvert((double w, double h) => $"{w} x {h}")
                                .MultiConvertBack((string s) =>
                                {
                                    var parts = s.Split('x');
                                    try {
                                        return (double.Parse(parts[0]), double.Parse(parts[1]));
                                    }
                                    catch
                                    {
                                        return (100, 100);
                                    }
                                }))
                    }
                }
                .IsExpanded(true)
                .Title("ConvertBack Multi-Binding example")
                .SourceText(mySourceCode3)
            }
        };
    }
}
