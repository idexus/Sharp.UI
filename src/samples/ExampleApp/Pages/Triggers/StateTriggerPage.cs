using System.Globalization;

namespace ExampleApp;

using CodeMarkup.Maui;

public partial class StateTriggerPage : ContentPage
{
    private Switch testSwitch;

    public StateTriggerPage()
	{
        Content = new Grid
        {
            new Switch(out testSwitch)
                .CenterVertically()
                .CenterHorizontally()
        }
        .Style(
            new Style<Grid>(e => e.BackgroundColor(Colors.Red))
            {
                new VisualState<Grid>
                {
                    async e => {
                        await e.AnimateBackgroundColorTo(Colors.Blue, 1000);
                    },

                    new StateTrigger()
                        .IsActive(e => e.Path("IsToggled").Source(testSwitch))
                        .OnIsActiveChanged(OnCheckedStateIsActiveChanged)
                },

                new VisualState<Grid>
                {
                    async e => {
                        await e.AnimateBackgroundColorTo(Colors.Yellow, 300);
                    },

                    new StateTrigger()
                        .IsActive(e => e.Path("IsToggled").Source(testSwitch).Negate())
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
