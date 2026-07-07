namespace ExampleApp;

using Sharp.UI;

public class SimpleBindings : ContentPage
{
    protected override View Build()
    {
        return new VStack
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
        .CenterVertically();
    }
}