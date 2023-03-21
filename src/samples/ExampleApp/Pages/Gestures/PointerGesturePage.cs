namespace ExampleApp;

using CodeMarkup.Maui;

public class PointerGesturePage : ContentPage
{
    public PointerGesturePage()
    {
        Content = new VStack
        {
            new Label(out var label).FontSize(20),
            new Label(out var enterExitLabel).FontSize(20).TextColor(Colors.Blue),
            new Image("dotnet_bot.png", out var image)
                .SizeRequest(300,300)
                .GestureRecognizers(
                    new PointerGestureRecognizer()
                        .OnPointerEntered((e, args) =>
                        {
                            enterExitLabel.Text = "Entered";
                        })
                        .OnPointerExited((e, args) =>
                        {
                            enterExitLabel.Text = "Exited";
                        })
                        .OnPointerMoved((e, args) =>
                        {
                            var pos = args.GetPosition(relativeTo: image).Value;
                            label.Text = $"point: {pos.X}, {pos.Y}";
                        }))
        }
        .CenterHorizontally()
        .CenterVertically();
    }
}
