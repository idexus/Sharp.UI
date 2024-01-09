# User defined extension methods

In `Sharp.UI`, you can create your own extension methods by defining a static method within a static class.

Here's an example of extension methods that set a label font size:

```cs
public static T FontSize<T>(this T self,
    double fontSize)
    where T : Microsoft.Maui.Controls.Label
{
    self.SetValue(Microsoft.Maui.Controls.Label.FontSizeProperty, fontSize);
    return self;
}
        
public static T FontSize<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
    where T : Microsoft.Maui.Controls.Label
{
    var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.Label.FontSizeProperty);
    configure(context).Build();
    return self;
}
        
public static SettersContext<T> FontSize<T>(this SettersContext<T> self,
    double fontSize)
    where T : Microsoft.Maui.Controls.Label
{
    self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.Label.FontSizeProperty, Value = fontSize });
    return self;
}
        
public static SettersContext<T> FontSize<T>(this SettersContext<T> self, Func<PropertySettersContext<double>, IPropertySettersBuilder<double>> configure)
    where T : Microsoft.Maui.Controls.Label
{
    var context = new PropertySettersContext<double>(self.XamlSetters, Microsoft.Maui.Controls.Label.FontSizeProperty);
    configure(context).Build();
    return self;
}
        
public static Task<bool> AnimateFontSizeTo<T>(this T self, double value, uint length = 250, Easing? easing = null)
    where T : Microsoft.Maui.Controls.Label
{
    double fromValue = self.FontSize;
    var transform = (double t) => Transformations.DoubleTransform(fromValue, value, t);
    var callback = (double actValue) => { self.FontSize = actValue; };
    return Transformations.AnimateAsync<double>(self, "AnimateFontSizeTo", transform, callback, length, easing);
}
```

it allows you the following usage:

```cs
new Label().FontSize(28)
```

or:

```cs
new Label().FontSize(e => e.Path("MyFontSize").Source(myModel))
new Label().FontSize(e => e.OnPhone(30).OnTablet(50).Default(40))
```

or use it in a style context:

```cs
new Style<Label>(e => e
    .FontSize(20)
    .CenterVertically()
    .CenterHorizontally())
```


or use in an animation context.