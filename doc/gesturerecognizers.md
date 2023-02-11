# Gesture Recognizers

The following gesture recognizers are available:

- `TapGestureRecognizer`
- `PanGestureRecognizer`
- `PointerGestureRecognizer`

### Tap Gesture Recognizer

The `TapGestureRecognizer` class is used to detect tap gestures on a view. You can specify the number of taps required using the `NumberOfTapsRequired` property.

Here's an example of using the TapGestureRecognizer to detect a double-tap gesture on an image:

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

### Pan Gesture Recognizer

The `PanGestureRecognizer` class is used to detect pan gestures on a view. You can use the `OnPanUpdated` method to handle the pan gesture event and update the position of the view.

Here's an example of using the `PanGestureRecognizer` to move an image on the screen:

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

### Pointer Gesture Recognizer

The `PointerGestureRecognizer` class is used to detect pointer events such as entering, exiting, and moving on a view. You can use the `OnPointerEntered`, `OnPointerExited`, and `OnPointerMoved` methods to handle these events and update the view accordingly.

Here's an example of using the `PointerGestureRecognizer` to display the position of a pointer on an image:

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
