namespace ExampleApp;

using Sharp.UI;

public partial class HelloWorldPage : ContentPage 
{
    int count = 0; 

    public HelloWorldPage()
	{
        Content =

        new VStack(e => e
            .Spacing(25)
            .Padding(new Thickness(30, 0))
            .CenterVertically())
	    {
            new Image("dotnet_bot.png", out var image)        
			    .HeightRequest(280) 
			    .CenterHorizontally(),

		    new Label("Welcome to .NET Multi-platform App UI")
                .FontSize(e => e.Default(30).OnPhone(16))
                .CenterHorizontally(),

            new Button("Click me")
			    .FontSize(20)
                .CenterHorizontally()
                .OnClicked(button =>
			    {
                    count++;
				    button.Text = $"Clicked {count} ";
                    button.Text += count == 1 ? "time" : "times";
                })
	    }; 
	}
}