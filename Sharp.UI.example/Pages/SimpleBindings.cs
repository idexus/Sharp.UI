using Sharp.UI;

public class SimpleBindings : ContentPage
{
    public SimpleBindings()
    {
        this.Content = new VStack
        {
            new Slider(out var slider)
                .Minimum(1)
                .Maximum(20),

            new Label()
                .Text(e => e
                    .BindTo("Value")
                    .Source(slider)
                    .StringFormat("Slider value: {0}")
                )
                .FontSize(28)
                .TextColor(Colors.Blue)
        }
        .VerticalOptions(LayoutOptions.Center);
    }
}