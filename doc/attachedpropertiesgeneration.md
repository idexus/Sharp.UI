# Attached properties

In `Sharp.UI` attached properties fluent helper methods can be generated automatically.

### Create an attachable property

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

### Fluent helper methods

First you need to create an interface with the `[AttachedProperies(attachedType)]` attribute:

```cs
[AttachedProperties(typeof(CustomShadow))]
public interface IViewShadowAttachedProperties
{
    bool HasCustomShadow { get; set; }
}
```
Attach this interface to the static class with the `[AttachedInterfaces(..)]` attribute, and use the `[SharpObject(type)]` attribute with the type you want to attach.

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