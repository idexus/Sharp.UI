namespace Sharp.UI.Example;

using Sharp.UI;

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

[AttachedProperties(typeof(CustomShadow))]
public interface IViewShadowAttachedProperties
{
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
