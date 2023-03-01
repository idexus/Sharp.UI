namespace ExampleApp.Pages;

using Sharp.UI;

public class NavigationSecondDetailPage : ContentPage
{
	public NavigationSecondDetailPage()
	{
		Content = new VStack(e => e.Center())
		{
			new Label("Last Page").FontSize(90)
		};
	}
}