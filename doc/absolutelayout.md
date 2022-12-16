# Absolute Layout

### Example content page

```cs
using Sharp.UI;

public class AbsoluteLayoutPage : ContentPage
{
    public AbsoluteLayoutPage()
    {
        Content = new AbsoluteLayout
        {
            new Grid
            {
                new Label("Absolute Layout")
                    .FontSize(30)
                    .HorizontalOptions(LayoutOptions.Center)
                    .VerticalOptions(LayoutOptions.Center)
            }
            .BackgroundColor(Colors.Red)
            .AbsoluteLayoutBounds(new Rect(100,100,400,400)),

            new Border
            {
                new Label("This is a test", out var label)
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
            .AbsoluteLayoutBounds(new Rect(600,400,300,200))
            .Stroke(Colors.Blue)
            .StrokeThickness(4)
            .StrokeShape(new RoundRectangle().CornerRadius(40)),
        };
    }
}
```

Using `AbsoluteLayoutBounds()` you can define the bounds of the view in the layout.

## Attached poperties

| Maui attached property | `Sharp.UI` fluent method |
|-|-|
|`AbsoluteLayout.LayoutFlags`|`AbsoluteLayoutFlags(layoutFlags)`|
|`AbsoluteLayout.LayoutBounds`|`AbsoluteLayoutBounds(layoutBounds)`|