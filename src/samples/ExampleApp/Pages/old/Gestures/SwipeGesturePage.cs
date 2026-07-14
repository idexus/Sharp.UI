namespace ExampleApp;

using Sharp.UI;

public partial class SwipeGesturePage : ContentPage
{
    protected override View Build()
    {
        return new VStack
        {
            new Label("Swipe image right"),
            new Label(out var label).FontSize(20).TextColor(Colors.Blue),
            new Image("dotnet_bot.png", out var image)
                .SizeRequest(300,300)
                .GestureRecognizers(new SwipeGestureRecognizer()
                    .Direction(SwipeDirection.Right)
                    .OnSwiped((e, args) => label.Text = "Swiped"))
        }
        .CenterHorizontally()
        .CenterVertically();
    }
}
