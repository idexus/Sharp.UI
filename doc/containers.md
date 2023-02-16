# Containers

`Sharp.UI` allows you to create single and multi-element containers using curly braces `{ }`.

### Single item containers

Objects such as `ScrollView`, `Border`, `ContentView` etc. can contain only one element.

```cs
new Scrollview
{
    new VStack
    {
        ...
    }
}
```

### Multi item containers

Objects such as `Grid`, `VStack` (short name for the Maui `VerticalStackLayout`), `HStack` (short name for the Maui `HorizontalStackLayout`) etc. can contain multiple elements.

```cs
new VStack
{
    new Label("Hello,")
        .FontSize(40),
    new Label("World!"),
    new Ellipse()
        .WidthRequest(100)
        .HeightRequest(40)
},
```

### Setting containers properties

In `Sharp.UI`, you can set properties for containers using lambda syntax inside the curly braces of the container. The lambda function is a preferred style for setting container properties because it allows you to chain multiple property setters in a single expression, making the code more concise and readable.


```cs
new Grid
{
    // setting properties

    e => e
        .BackgroundColor(Colors.Red)
        .AbsoluteLayoutBounds(new Rect(30,170,300,100))
        .Background(new LinearGradientBrush(new Point(0, 0), new Point(1, 1))
        {
            new GradientStop(Colors.Yellow, 0.0),
            new GradientStop(Colors.Red, 0.25),
            new GradientStop(Colors.Blue, 0.75),
            new GradientStop(Colors.LimeGreen, 1.0)
        }),

    // container content here

    new Label("Label"),
    new Button("Count")
    ...
},
```

You can also set the properties of a container outside the curly braces by chaining the property setters on the container object, like this:

```cs
new Grid
{
    // container content here

    new Label("Label"),
    new Button("Count")
    ...
}
.BackgroundColor(Colors.Red)
.AbsoluteLayoutBounds(new Rect(30,170,300,100))
.Background(new LinearGradientBrush(new Point(0, 0), new Point(1, 1))
{
    new GradientStop(Colors.Yellow, 0.0),
    new GradientStop(Colors.Red, 0.25),
    new GradientStop(Colors.Blue, 0.75),
    new GradientStop(Colors.LimeGreen, 1.0)
})
```