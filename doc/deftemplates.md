# Templates
Using `LazyValueBuilder<T>` class you can create templates depending on device idiom, platform, or app theme

```cs
new LazyValueBuilder<VStack>(e => e
        .BackgroundColor(Colors.Red)
        .Padding(20)
    )
    .OnDesktop(() =>
        new VStack
        {
            new Label("Desktop version"),
            new Image("dotnet_bot.png"),
        })
    .OnPhone(() =>
        new VStack
        {
            new Label("This is a phone version"),
            new Label("No images...")
        })
    .GetValue(),
```