# User defined extension methods

In __Sharp.UI__, you can create your own extension methods by defining a static method within a static class.

Here's an example of extension methods that set a label font size:

```cs
public static T FontSize<T>(this T self,
    double fontSize)
    where T : Microsoft.Maui.Controls.Label
{
    self.SetValueOrAddSetter(Microsoft.Maui.Controls.Label.FontSizeProperty, fontSize);
    return self;
}
        
public static T FontSize<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
    where T : Microsoft.Maui.Controls.Label
{
    var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.Label.FontSizeProperty);
    configure(context).Build();
    return self;
}
```

the first extension method allows you the following usage:

```cs
new Label().FontSize(28)
```

the second:

```cs
new Label().FontSize(e => e.Path("MyFontSize").Source(myModel))
new Label().FontSize(e => e.OnPhone(30).OnTablet(50).Default(40))
```

In the extension methods, it's important to use the `SetValueOrAddSetter` method instead of setting the properties directly. `SetValueOrAddSetter` sets the value of the property if the property is used in a standard context, such as in object creation, or add a new `Setter` when you use the method to create a setter for a style definition.
