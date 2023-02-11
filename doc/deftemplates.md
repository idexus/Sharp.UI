# Templates

This below code demonstrates how to use the `LazyValueBuilder<T>` class to create templates that vary based on the device's idiom, platform, or app theme. The `LazyValueBuilder<T>` class constructor takes a `Func<T>` as an argument that specifies the default template. In this case, the default template is a VStack with a red background color and 20 pixels of padding.

The `OnDesktop` method allows you to specify a different template for desktop devices. In this case, the desktop template is a `VStack` containing a label with the text "Desktop version" and an image of the dotnet bot.

Similarly, the `OnPhone` method allows you to specify a different template for phone devices. In this case, the phone template is a `VStack` containing a label with the text "This is a phone version" and another label with the text "No images...".

Finally, the `GetValue()` method returns the correct template based on the current device's idiom, platform, or app theme.

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