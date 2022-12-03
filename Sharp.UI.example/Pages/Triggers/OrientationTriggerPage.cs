namespace Sharp.UI.Example;

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
        .Style(new Style<StackLayout>
        {
            new VisualState()
            {
                StackLayout.BackgroundColorProperty.Set(Colors.Blue)
            }
            .StateTriggers(new OrientationStateTrigger().Orientation(DisplayOrientation.Portrait)),

            new VisualState()
            {
                StackLayout.BackgroundColorProperty.Set(Colors.Red)
            }
            .StateTriggers(new OrientationStateTrigger().Orientation(DisplayOrientation.Landscape)),
        });
    }
}
