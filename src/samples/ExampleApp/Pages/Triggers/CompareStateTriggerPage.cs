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
            new VisualState<Grid>
            {
                e => e.BackgroundColor(Colors.Black),

                new CompareStateTrigger()
                    .Binding(e => e.Path("IsToggled")
                    .Source(testSwitch))
                    .Value(true),
            },
            new VisualState<Grid>
            {
                e => e.BackgroundColor(Colors.White),

                new CompareStateTrigger()
                    .Binding(e => e.Path("IsToggled")
                    .Source(testSwitch))
                    .Value(false),
            }
        });
    }
}
