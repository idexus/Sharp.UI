namespace Sharp.UI.Example;

using Sharp.UI;

// --- attached properties declaration ---

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

// --- generate attached fluent methods ---

[SharpObject(typeof(View))]
[AttachedInterfaces(new[] { typeof(IViewShadowAttachedProperties) })]
public static class ViewAttachedPropertiesExtension
{

}

// --- consume attached properties ----

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
