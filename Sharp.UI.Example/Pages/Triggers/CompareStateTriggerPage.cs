namespace Sharp.UI.Example;

using Sharp.UI;

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
            .StateTriggers(new CompareStateTrigger(e => e.Path("IsToggled").Source(testSwitch), true)),

            new VisualState()
            {
                VisualElement.BackgroundColorProperty.Set(Colors.White),
            }
            .StateTriggers(new CompareStateTrigger(e => e.Path("IsToggled").Source(testSwitch), false)),
        });
    }
}
