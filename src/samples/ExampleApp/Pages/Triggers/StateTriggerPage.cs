using System.Globalization;

namespace ExampleApp;

using Sharp.UI;

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
        .Style(
            new Style<Grid>
            {
                new VisualState<Grid>(e => e.Background(Colors.Black))
                {
                    new StateTrigger()
                        .IsActive(e => e.Path("IsToggled").Source(testSwitch))
                        .OnIsActiveChanged(OnCheckedStateIsActiveChanged)
                },

                new VisualState<Grid>(e => e.BackgroundColor(Colors.White))
                {
                    new StateTrigger()
                        .IsActive(e => e.Path("IsToggled").Source(testSwitch).Converter(new NegateConverter()))
                        .OnIsActiveChanged(OnUncheckedStateIsActiveChanged)
                },
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
