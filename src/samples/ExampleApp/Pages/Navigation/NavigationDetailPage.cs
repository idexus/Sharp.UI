namespace ExampleApp.Pages;

using Sharp.UI;

public class NavigationDetailPage : ContentPage
{
	public NavigationDetailPage()
	{
		Content = new VStack(e => e.Center())
		{
			new Label("Detail Page").FontSize(90)
		};
	}
}