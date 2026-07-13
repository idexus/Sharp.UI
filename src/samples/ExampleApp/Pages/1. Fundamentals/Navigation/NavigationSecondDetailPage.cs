namespace ExampleApp;

using Sharp.UI;

public class NavigationSecondDetailPage : ContentPage
{
    protected override View Build()
    {
        return new VStack(e => e.Center())
		{
			new Label("Second Page").FontSize(70)
		};
	}
}