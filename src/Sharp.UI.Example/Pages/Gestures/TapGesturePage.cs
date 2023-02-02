namespace ExampleApp;

using Sharp.UI;

public class TapGesturePage : ContentPage
{
    public TapGesturePage()
    {
        Content = new VStack
        {
            new Label("Tap 2 times on the image", out var label).FontSize(20),
            new Image("dotnet_bot.png", out var image)
                .SizeRequest(100,100)
                .GestureRecognizers(new GestureRecognizer[]
                {
                    new TapGestureRecognizer().NumberOfTapsRequired(2).OnTapped((e, args) =>
                    {
                        label.Text = "You tapped 2 times";
                    })
                })
        }
        .HorizontalOptions(LayoutOptions.Center)
        .VerticalOptions(LayoutOptions.Center);
    }
}
