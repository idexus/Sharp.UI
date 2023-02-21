namespace ExampleApp;

using Sharp.UI;

public class OrientationTriggerPage : ContentPage
{
	public OrientationTriggerPage()
	{
        Content = new VStack
        {
            new Label("Change orientation").FontSize(40)            
        }
        .VerticalOptions(LayoutOptions.Center)
        .HorizontalOptions(LayoutOptions.Center)
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
