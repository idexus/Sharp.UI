# Properties and Fluent Methods

`Sharp.UI` provides a convenient way to set properties for UI elements by matching properties with fluent helper methods. This makes it easier and more readable to define the interface of your application.

Here is an example of using fluent methods to set properties on a `Label`:

```cs
new Label()
    .Text("This is a test")
    .Padding(20)
    .FontSize(30)
    .CenterInContainer())
```

Additionally, some common properties can be set directly as constructor arguments for even faster definition of the interface. Here is an example using a constructor argument to set the text property on a `Label`:

```cs
new Label("This is a test")
```

`Sharp.UI` also provides a way to set property values based on device idiom, platform, or app theme. Here is an example of setting the font size and text color of a `Label` based on the current device or theme:

```cs
new Label("Hello")
    .FontSize(e => e.Default(50).OnDesktop(80).OnPhone(30))
    .TextColor(e => e.OnLight(Colors.Black).OnDark(Colors.Teal))
```