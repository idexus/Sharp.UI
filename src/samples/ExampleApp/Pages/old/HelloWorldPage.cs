
namespace ExampleApp;

using Sharp.UI;

public sealed partial class HelloWorldPage : ContentPage
{
    int count = 0;

    protected override View Build()
    {
        return new VStack(e => e
            .Spacing(25)
            .Padding(new Thickness(30, 0))
            .CenterVertically())
        {
            new Image("dotnet_bot.png", out var image)
                .HeightRequest(280)
                .CenterHorizontally(),

            new Label("Welcome to .NET Multi-platform App")
                .FontSize(e => e.OnPhone(16).Default(30))
                .CenterHorizontally(),

            new Button("Click me")
                .FontSize(20)
                .CenterHorizontally()
                .OnClicked(button =>
                {
                    count++;
                    button.Text = $"Clicked n {count} ";
                    button.Text += count == 1 ? "time" : "times";
                })
        };
    }
}
