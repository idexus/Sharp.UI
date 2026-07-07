namespace ExampleApp;

using Sharp.UI;

public class NavigationMainPage : ContentPage
{
    protected override View Build()
    {
        return new VStack(e => e.Center())
		{
			new Label("Main Page")
				.FontSize(60)
				.Margin(bottom: 20)
				.TextColor(Colors.Red),

			new Button("Go to detail page")
				.OnClicked(async button =>
				{
					if (Shell.Current != null)
						await Shell.Current.GoToAsync("details");
					else
						await Navigation.PushAsync<NavigationDetailPage>();
                })
		};
	}
}