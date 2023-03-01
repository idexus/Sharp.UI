namespace ExampleApp.Pages;

using Sharp.UI;

public class NavigationDetailPage : ContentPage
{
	public NavigationDetailPage()
	{
		Content = new VStack(e => e.Center())
		{
			new Label("Detail Page").FontSize(90),

            new Button("Go to next page")
                .OnClicked(async button =>
                {
                    await Shell.Current.GoToAsync("seconddetails");
                })
        };
	}
}