namespace ExampleApp;

using Sharp.UI;

public sealed partial class SimpleBindings : ContentPage
{
    string mySourceCode = """
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

    protected override void Build()
    {
        Content = new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
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
            .SourceText(mySourceCode)
        };
    }
}