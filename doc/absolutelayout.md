# Absolute Layout

The `AbsoluteLayout` class allows you to position elements in a precise, absolute manner within the layout.

### Defining the boundaries of a view

You can use the `AbsoluteLayoutBounds` fluent method to specify the boundaries of a view within the `AbsoluteLayout`. The method takes a `Rect` object, which defines the x and y coordinates of the view, as well as its width and height.

Here's an example of how you can use the `AbsoluteLayoutBounds` method to define the boundaries of two different views:

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

### Using attached properties

In addition to the `AbsoluteLayoutBounds` method, Sharp.UI also provides access to the following attached properties for the AbsoluteLayout class:

| Attached property | Fluent method |
|-|-|
|`AbsoluteLayout.LayoutFlags`|`AbsoluteLayoutFlags(layoutFlags)`|
|`AbsoluteLayout.LayoutBounds`|`AbsoluteLayoutBounds(layoutBounds)`|

These properties can be used to further customize the behavior and appearance of elements within the `AbsoluteLayout`.