# Gradients

`Sharp.UI` provides a way to create visual effects using gradient brushes in curly braces. There are two defined types of gradient brushes: 

- LinearGradientBrush 
- RadialGradientBrush.

### Example

Here is an example of a `Border` element with a `LinearGradientBrush` as its background. The gradient effect goes from the top-left corner to the bottom-right corner.

```cs
new Border
{
    e => e
        .SizeRequest(400,200)
        .Stroke(Colors.Blue)
        .StrokeThickness(4)
        .StrokeShape(new RoundRectangle().CornerRadius(40))
        .Background(new LinearGradientBrush(new Point(0,0), new Point(1,1))
        {
            new GradientStop(Colors.Yellow, 0.0),
            new GradientStop(Colors.Red, 0.25),
            new GradientStop(Colors.Blue, 0.75),
            new GradientStop(Colors.LimeGreen, 1.0)
        }),

    // container content here

    new Label("This is a test")
        .Padding(20)
        .FontSize(30)
        .HorizontalOptions(LayoutOptions.Center)
        .VerticalOptions(LayoutOptions.Center)
}
```
