namespace Sharp.UI.Example;

public class CompareStateTriggerPage : ContentPage
{
    private Switch testSwitch;

    public CompareStateTriggerPage()
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
            .StateTriggers(new StateTriggerBase[]
            {
                new CompareStateTrigger(e => e.Path("IsToggled").Source(testSwitch), true)
            }),

            new VisualState()
            {
                VisualElement.BackgroundColorProperty.Set(Colors.White),
            }
            .StateTriggers(new StateTriggerBase[]
            {
               new CompareStateTrigger(e => e.Path("IsToggled").Source(testSwitch), false)
            }),
        });
    }
}
