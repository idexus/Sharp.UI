namespace ExampleApp;

using Sharp.UI;

public sealed partial class CompareStateTriggerPage : ContentPage
{
    private Switch testSwitch;

    protected override View Build()
    {
        return new Grid
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
