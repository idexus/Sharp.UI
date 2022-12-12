using System.Globalization;

namespace Sharp.UI.Example;

public partial class StateTriggerPage : ContentPage
{
    private Switch testSwitch;

    public StateTriggerPage()
	{
        Content = new Grid
        {
            new Switch(out testSwitch)
                .VerticalOptions(LayoutOptions.Center)
                .HorizontalOptions(LayoutOptions.Center)
        }
        .Style(new Style<Grid>
        {
            new VisualState()
            { 
                VisualElement.BackgroundColorProperty.Set(Colors.Black),
            }
            .StateTriggers(
                new StateTrigger()
                    .IsActive(e => e.Path("IsToggled").Source(testSwitch))
                    .OnIsActiveChanged(OnCheckedStateIsActiveChanged)),

            new VisualState()
            {
                VisualElement.BackgroundColorProperty.Set(Colors.White),
            }
            .StateTriggers(
                new StateTrigger()
                    .IsActive(e => e.Path("IsToggled").Source(testSwitch).Converter(new NegateConverter()))
                    .OnIsActiveChanged(OnUncheckedStateIsActiveChanged)),
        });
	}

    void OnCheckedStateIsActiveChanged(StateTrigger sender)
    {
        Console.WriteLine($"Checked state active: {sender.IsActive}");
    }

    void OnUncheckedStateIsActiveChanged(StateTrigger sender)
    {
        Console.WriteLine($"Unchecked state active: {sender.IsActive}");
    }
}
