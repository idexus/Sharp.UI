namespace ExampleApp;

using CodeMarkup.Maui;

public class CompareStateTriggerPage : ContentPage
{
    private Switch testSwitch;

    public CompareStateTriggerPage()
	{
        Content = new Grid
        {
            new Switch(out testSwitch)
                .CenterVertically()
                .CenterHorizontally()
        }
        .Style(new Style<Grid>
        {
            new VisualState<Grid>(e => e.BackgroundColor(Colors.Black))
            {
                new CompareStateTrigger()
                    .Binding(e => e.Path("IsToggled")
                    .Source(testSwitch))
                    .Value(true),
            },
            new VisualState<Grid>(e => e.BackgroundColor(Colors.White))
            {
                new CompareStateTrigger()
                    .Binding(e => e.Path("IsToggled")
                    .Source(testSwitch))
                    .Value(false),
            }
        });
    }
}
