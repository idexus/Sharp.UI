# Attached properties generation

This code demonstrates how to generate attached properties and their fluent helper methods in `Sharp.UI`.

Attached properties and their fluent helper methods can be generated automatically using the `AttachedProperties` and `AttachedInterfaces` attributes, along with the `SharpObject` attribute.

```cs
[AttachedProperties(typeof(CustomShadow))]
public interface IViewShadowAttachedProperties
{
    [AttachedName("HasShadow")]
    [PropertyCallbacks(propertyChanged: "OnHasShadowChanged")]
    bool HasCustomShadow { get; set; }

    double ShadowSize { get; set; }

    [DefaultValue("Colors.Red")]
    Color ShadowColor { get; set; }
}

[SharpObject]
[AttachedInterfaces(new[] {typeof(IViewShadowAttachedProperties) })]
public partial class CustomShadow
{
    static void OnHasShadowChanged(BindableObject bindable, object oldValue, object newValue)
    {
        // On HasShadow changed
    }
}
```

### Generate attached fluent methods

To auto-generate fluent methods for the attached properties, a static class named `ViewAttachedPropertiesExtension` is decorated with the `SharpObject` attribute and the `AttachedInterfaces` attribute, specifying the `IViewShadowAttachedProperties` interface.

```cs
[SharpObject(typeof(View))]
[AttachedInterfaces(new[] { typeof(IViewShadowAttachedProperties) })]
public static class ViewAttachedPropertiesExtension
{

}
```

### Consume attached properties

The attached properties can be consumed by creating instances of the type to which they are attached, and then using the fluent helper methods to set the values of the attached properties. For example, in the `AttachedPropertiesPage` class, a `Label` and a `Button` object are created, and their `HasCustomShadow`, `ShadowSize`, and `ShadowColor` properties are set using the corresponding fluent helper methods.

```cs
public class AttachedPopertiesPage : ContentPage
{
    public AttachedPopertiesPage()
    {
        Content = new VStack
        {
            new Label()
                .HasCustomShadow(true)
                .ShadowSize(23)
                .ShadowColor(Colors.Blue),

            new Button()
                .HasCustomShadow(false)
        };
    }
}
```
