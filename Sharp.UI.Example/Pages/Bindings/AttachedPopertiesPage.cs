namespace Sharp.UI.Example;

using Sharp.UI;

public class CustomShadow
{
    public static readonly BindableProperty HasCustomShadowProperty =
        BindableProperty.CreateAttached("HasCustomShadow", typeof(bool), typeof(Shadow), false);

    public static bool GetHasCustomShadow(BindableObject view)
    {
        return (bool)view.GetValue(HasCustomShadowProperty);
    }

    public static void SetCustomHasShadow(BindableObject view, bool value)
    {
        view.SetValue(HasCustomShadowProperty, value);
    }
}

[AttachedProperties(typeof(CustomShadow))]
public interface IViewShadowAttachedProperties
{
    bool HasCustomShadow { get; set; }
}

[SharpObject(typeof(Microsoft.Maui.Controls.View))]
[AttachedInterfaces(new[] { typeof(IViewShadowAttachedProperties) })]
public static class ViewExtension
{

}

public class AttachedPopertiesPage : ContentPage
{
	public AttachedPopertiesPage()
	{
		Content = new VStack
		{
            new Label()
                .HasCustomShadow(true)
		};
	}
}
