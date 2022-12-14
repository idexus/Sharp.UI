# Attached properties generation

In `Sharp.UI` attached properties and their fluent helper methods can be generated automatically.

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

To auto-generate fluent methods, attach the interface to a static class with the `[AttachedInterfaces(..)]` attribute, and use the `[SharpObject(type)]` attribute with the type you want to attach.

```cs
[SharpObject(typeof(View))]
[AttachedInterfaces(new[] { typeof(IViewShadowAttachedProperties) })]
public static class ViewAttachedPropertiesExtension
{

}
```

### Consume attached properties

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
