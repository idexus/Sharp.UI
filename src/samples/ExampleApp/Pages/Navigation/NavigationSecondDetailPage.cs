namespace ExampleApp;

using CodeMarkup.Maui;

public class NavigationSecondDetailPage : ContentPage
{
	public NavigationSecondDetailPage()
	{
		Content = new VStack(e => e.Center())
		{
			new Label("Second Page").FontSize(70)
		};
	}
}