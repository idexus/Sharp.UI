# Properties and fluent methods
The properties of the MAUI classes are matched with their fluent helper methods

```cs
new Label()
    .Text("This is a test")
    .Padding(20)
    .FontSize(30)
    .HorizontalOptions(LayoutOptions.Center)
    .VerticalOptions(LayoutOptions.Center)
```

To speed up defining the interface, some common properties are placed directly as constructor arguments

```cs
new Label("This is a test")
```

You can set the property value depending on the device idiom, platform, or app theme

```cs
new Label("Hello")
    .FontSize(e => e.Default(50).OnDesktop(80).OnPhone(30))
    .TextColor(e => e.Light(Colors.Black).Dark(Colors.Teal))
```