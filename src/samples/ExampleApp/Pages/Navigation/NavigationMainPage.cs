namespace ExampleApp.Pages;

using Sharp.UI;

public class NavigationMainPage : ContentPage
{
	public NavigationMainPage()
	{
		Content = new VStack(e => e.Center())
		{
			new Label("Main Page")
				.FontSize(60)
				.TextColor(Colors.Red),

			new Button("Go to detail page")
				.OnClicked(async button =>
				{
                    await Shell.Current.GoToAsync("details");
                })
		};
	}
}