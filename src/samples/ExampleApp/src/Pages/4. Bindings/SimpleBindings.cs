namespace ExampleApp;

using Sharp.UI;

public sealed partial class SimpleBindings : ContentPage
{
    string mySourceCode1 = """
new VStack
{
    new Slider(out var slider)
        .Minimum(1)
        .Maximum(20)
        .Margin(30),

    new Label()
        .Text(e => e
            .Path("Value")
            .Source(slider)
            .StringFormat("Slider value: {0:F3}")
        )
        .FontSize(28)
        .TextColor(Colors.Blue)
        .CenterHorizontally()
}
""";

    string mySourceCode2 = """
new VStack
{
    new Slider(out var slider2)
        .Minimum(1).Maximum(30),

    new Slider()
        .Value(e => e
            .Path(nameof(Slider.Value))
            .Source(slider2)
            .Convert((double e) => e + 10)
            .ConvertBack((double e) => e - 10))
        .Minimum(1).Maximum(100),
}
""";

    protected override void Build()
    {
        Content = new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new VStack
            {
                new Example
                {
                    new VStack
                    {
                        new Slider(out var slider)
                            .Minimum(1)
                            .Maximum(20)
                            .Margin(30),

                        new Label()
                            .Text(e => e
                                .Path("Value")
                                .Source(slider)
                                .StringFormat("Slider value: {0:F3}")
                            )
                            .FontSize(28)
                            .TextColor(Colors.Blue)
                            .CenterHorizontally()
                    }
                }
                .IsExpanded(true)
                .Title("Simple binding example")
                .SourceText(mySourceCode1),

                new Example
                {
                    new VStack
                    {
                        new Slider(out var slider2)
                            .Minimum(1).Maximum(30),

                        new Slider()
                            .Value(e => e
                                .Path(nameof(Slider.Value))
                                .Source(slider2)
                                .Convert((double e) => e + 10)
                                .ConvertBack((double e) => e - 10))
                            .Minimum(1).Maximum(100),
                    }
                }
                .IsExpanded(true)
                .Title("ConvertBack example")
                .SourceText(mySourceCode2)
            }
        };
    }
}