# User defined extension methods

In __CodeMarkup.Maui__, you can create your own extension methods by defining a static method within a static class.

Here's an example of extension methods that set an entry font size:

```cs
public static T FontSize<T>(this T self,
    double fontSize)
    where T : Microsoft.Maui.Controls.Entry
{
    self.SetValue(Microsoft.Maui.Controls.Entry.FontSizeProperty, fontSize);
    return self;
}
        
public static T FontSize<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
    where T : Microsoft.Maui.Controls.Entry
{
    var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.Entry.FontSizeProperty);
    configure(context).Build();
    return self;
}
        
public static SettersContext<T> FontSize<T>(this SettersContext<T> self,
    double fontSize)
    where T : Microsoft.Maui.Controls.Entry
{
    self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.Entry.FontSizeProperty, Value = fontSize });
    return self;
}
        
public static SettersContext<T> FontSize<T>(this SettersContext<T> self, Func<PropertySettersContext<double>, IPropertySettersBuilder<double>> configure)
    where T : Microsoft.Maui.Controls.Entry
{
    var context = new PropertySettersContext<double>(self.XamlSetters, Microsoft.Maui.Controls.Entry.FontSizeProperty);
    configure(context).Build();
    return self;
}
```
