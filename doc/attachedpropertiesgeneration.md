# Attached properties

In `Sharp.UI` attached properties fluent helper methods can be generated automatically.

### Create an attached property

```cs
public class CustomShadow
{
    public static readonly BindableProperty HasShadowProperty =
        BindableProperty.CreateAttached("HasShadow", typeof(bool), typeof(CustomShadow), false);

    public static bool GetHasShadow(BindableObject obj)
    {
        return (bool)obj.GetValue(HasShadowProperty);
    }

    public static void SetCustomHasShadow(BindableObject obj, bool value)
    {
        obj.SetValue(HasShadowProperty, value);
    }
}
```

### Attached properties and fluent methods

To auto-generate fluent methods, first you need to create an interface with the `[AttachedProperies(attachedType)]` attribute:

```cs
[AttachedProperties(typeof(CustomShadow))]
public interface IViewShadowAttachedProperties
{
    [AttachedName("HasShadow")]
    bool HasCustomShadow { get; set; }
}
```
Than, attach this interface to a static class with the `[AttachedInterfaces(..)]` attribute, and use the `[SharpObject(type)]` attribute with the type you want to attach.

```cs
[SharpObject(typeof(View))]
[AttachedInterfaces(new[] { typeof(IViewShadowAttachedProperties) })]
public static class ViewAttachedPropertiesExtension
{

}
```

### Consume an attached property

```cs
public class AttachedPopertiesPage : ContentPage
{
    public AttachedPopertiesPage()
    {
        Content = new VStack
        {
            new Label()
                .HasCustomShadow(true),

            new Button()
                .HasCustomShadow(false)
        };
    }
}
```