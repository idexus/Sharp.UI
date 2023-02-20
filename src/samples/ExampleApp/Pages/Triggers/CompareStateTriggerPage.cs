namespace ExampleApp;

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
                new CompareStateTrigger().Binding(e => e.Path("IsToggled").Source(testSwitch)).Value(true),

                VisualElement.BackgroundColorProperty.Set(Colors.Black)
            },
            new VisualState()
            {
                new CompareStateTrigger().Binding(e => e.Path("IsToggled").Source(testSwitch)).Value(false),

                VisualElement.BackgroundColorProperty.Set(Colors.White),
            }
        });
    }
}
