namespace ExampleApp;

using Sharp.UI;

[SharpObject]
public partial class HelloWorldPage : ContentPage 
{
    int count = 0; 

    public HelloWorldPage()
	{
		Content = new VStack   
		{			
			new Image("dotnet_bot.png", out var image)        
				.HeightRequest(280) 
				.HorizontalOptions(LayoutOptions.Center),

			new Label("Welcome to .NET Multi-platform App UI")
                .FontSize(e => e.Default(30).OnPhone(20))
                .HorizontalOptions(LayoutOptions.Center),

            new Button("Click me")
				.HorizontalOptions(LayoutOptions.Center)
				.FontSize(20)
				.OnClicked(button =>
				{
                    count++;
					button.Text = $"Clicked {count} ";
                    button.Text += count == 1 ? "time" : "times";
                })
		}
		.Spacing(25)
		.Padding(new Thickness(30, 0))
		.VerticalOptions(LayoutOptions.Center); 
	}
}
 