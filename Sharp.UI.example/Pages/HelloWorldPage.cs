namespace Sharp.UI.Example;

public class HelloWorldPage : ContentPage
{
    int count = 0;

    public HelloWorldPage()
	{
		Content = new VStack
		{
			new Image("dotnet_bot.png")
				.HeightRequest(200)
				.HorizontalOptions(LayoutOptions.Center),

			new Label("Hello, World!")
				.FontSize(32)
				.HorizontalOptions(LayoutOptions.Center),

			new Label("Welcome to .NET Multi-platform App UI")
				.FontSize(18)
				.HorizontalOptions(LayoutOptions.Center),

			new Button("Click me")
				.HorizontalOptions(LayoutOptions.Center)
				.OnClicked(button =>
				{
                    count++;
					if (count == 1)
                        button.Text = $"Clicked {count} time";
					else
                        button.Text = $"Clicked {count} times";
                })
		}
		.Spacing(25)
		.Padding(new Thickness(30, 0))
		.VerticalOptions(LayoutOptions.Center);
	}

    private void OnCounterClicked(Button sender)
    {
        count++;

        if (count == 1)
            sender.Text = $"Clicked {count} time";
        else
            sender.Text = $"Clicked {count} times";
    }
}
