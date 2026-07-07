namespace ExampleApp;

using Sharp.UI;

public class OrientationTriggerPage : ContentPage
{
    protected override View Build()
    {
        return new VStack
        {
            new Label("Change orientation").FontSize(40)            
        }
        .CenterVertically()
        .CenterHorizontally()
        .Style(new Style<VStack>
        {
            new VisualState<VStack>(e => e.BackgroundColor(Colors.Blue))
            {
                new OrientationStateTrigger().Orientation(DisplayOrientation.Portrait),
            },
            new VisualState<VStack>(e => e.BackgroundColor(Colors.Red))
            {
                new OrientationStateTrigger().Orientation(DisplayOrientation.Landscape),
            },
        });
    }
}
