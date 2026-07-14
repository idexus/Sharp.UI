namespace ExampleApp;

using Sharp.UI;

public sealed partial class NavigationSecondDetailPage : ContentPage
{
    protected override View Build()
    {
        return new VStack(e => e.Center())
		{
			new Label("Second Page").FontSize(70)
		};
	}
}