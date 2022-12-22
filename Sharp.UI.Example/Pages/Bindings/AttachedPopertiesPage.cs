namespace Sharp.UI.Example;

using Sharp.UI;

public class CustomShadow
{
    public static readonly BindableProperty HasShadowProperty =
        BindableProperty.CreateAttached("HasShadow", typeof(bool), typeof(Shadow), false);

    public static bool GetHasShadow(BindableObject obj)
    {
        return (bool)obj.GetValue(HasShadowProperty);
    }

    public static void SetCustomHasShadow(BindableObject obj, bool value)
    {
        obj.SetValue(HasShadowProperty, value);
    }
}

[AttachedProperties(typeof(CustomShadow))]
public interface IViewShadowAttachedProperties
{
    [AttachedName("HasShadow")]
    bool HasCustomShadow { get; set; }
}

[SharpObject(typeof(View))]
[AttachedInterfaces(new[] { typeof(IViewShadowAttachedProperties) })]
public static class ViewAttachedPropertiesExtension
{

}

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
