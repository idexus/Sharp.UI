## Gesture recognizers

#### Tap gesture recognizer

```cs
new VStack
{
    new Label("Tap 2 times on the image", out var label),
    new Image("dotnet_bot.png", out var image)
        .SizeRequest(100,100)
        .GestureRecognizers(new GestureRecognizer[]
        {
            new TapGestureRecognizer()
                .NumberOfTapsRequired(2)
                .OnTapped((e, args) =>
                {
                    label.Text = "You tapped 2 times";
                })
        })
}
```

#### Pan gesture recognizer

```cs
public class PanGesturePage : ContentPage
{
    double x, y;

    public PanGesturePage()
    {
        Content = new Grid
        {
            new Image("dotnet_bot.png", out var image)
                .SizeRequest(100,100)
                .GestureRecognizers(new GestureRecognizer[]
                {
                    new PanGestureRecognizer()
                        .OnPanUpdated((e, args) =>
                        {
                            switch (args.StatusType)
                            {
                                case GestureStatus.Running:
                                    image.TranslationX = x + args.TotalX;
                                    image.TranslationY = y + args.TotalY;
                                    break;

                                case GestureStatus.Completed:
                                    x = image.TranslationX;
                                    y = image.TranslationY;
                                    break;
                            }
                        })
                })
        };
    }
}
```

#### Pointer gesture recognizer

```cs
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
                .GestureRecognizers(new GestureRecognizer[]
                {
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
                        })
                })
        }
        .HorizontalOptions(LayoutOptions.Center)
        .VerticalOptions(LayoutOptions.Center);
    }
}
```