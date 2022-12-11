## Gradients

Example of a linear gradient brush

```cs
new Border
{
    new Label("This is a test")
        .Padding(20)
        .FontSize(30)
        .HorizontalOptions(LayoutOptions.Center)
        .VerticalOptions(LayoutOptions.Center)
}
.Background(new LinearGradientBrush(new Point(0,0), new Point(1,1))
{
    new GradientStop(Colors.Yellow, 0.0),
    new GradientStop(Colors.Red, 0.25),
    new GradientStop(Colors.Blue, 0.75),
    new GradientStop(Colors.LimeGreen, 1.0)
})
.SizeRequest(400,200)
.Stroke(Colors.Blue)
.StrokeThickness(4)
.StrokeShape(new RoundRectangle().CornerRadius(40)),
```