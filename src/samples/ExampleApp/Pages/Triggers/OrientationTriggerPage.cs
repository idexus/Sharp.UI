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
            new VisualState()
            {
                new OrientationStateTrigger().Orientation(DisplayOrientation.Portrait),

                StackLayout.BackgroundColorProperty.Set(Colors.Blue),                
            },
            new VisualState()
            {
                new OrientationStateTrigger().Orientation(DisplayOrientation.Landscape),

                StackLayout.BackgroundColorProperty.Set(Colors.Red)
            },
        });
    }
}
