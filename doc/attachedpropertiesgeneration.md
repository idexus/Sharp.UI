# Attached properties

In `Sharp.UI` attached properties fluent helper methods can be generated automatically.

### Create an attached property

```cs
public class CustomShadow
{
    public static readonly BindableProperty HasCustomShadowProperty =
        BindableProperty.CreateAttached("HasCustomShadow", typeof(bool), typeof(Shadow), false);

    public static bool GetHasCustomShadow(BindableObject obj)
    {
        return (bool)obj.GetValue(HasCustomShadowProperty);
    }

    public static void SetCustomHasShadow(BindableObject obj, bool value)
    {
        obj.SetValue(HasCustomShadowProperty, value);
    }
}
```

### Attached properties and fluent methods

To auto-generate fluent methods, first you need to create an interface with the `[AttachedProperies(attachedType)]` attribute:

```cs
[AttachedProperties(typeof(CustomShadow))]
public interface IViewShadowAttachedProperties
{
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