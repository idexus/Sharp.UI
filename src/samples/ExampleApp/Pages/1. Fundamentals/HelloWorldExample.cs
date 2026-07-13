
namespace ExampleApp;

using Sharp.UI;

public partial class HelloWorldExample : ContentPage
{
    private int count;

    string mySourceCode = """
namespace ExampleApp;

using Sharp.UI;

public partial class HelloWorldPage : ContentPage
{
    int count = 0;

    protected override View Build()
    {
        return new VStack()
        {
            new Label("Hello, World!")
                .FontSize(e => e.OnPhone(40).Default(60))
                .CenterHorizontally(),

            new Label("Welcome to Sharp.UI Quick Samples Gallery")
                .FontSize(e => e.OnPhone(15).Default(25))
                .CenterHorizontally(),

            new Button("Click me")
                .FontSize(20)
                .CenterHorizontally()
                .Margin(0,20,0,20)
                .OnClicked(button =>
                {
                    count++;
                    button.Text = $"Clicked n {count} ";
                    button.Text += count == 1 ? "time" : "times";
                })
        }
    }
}
""";

    protected override View Build()
    {
        return new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new Example
            {
                new VStack()
                {
                    new Label("Hello, World!")
                        .FontSize(e => e.OnPhone(40).Default(60))
                        .CenterHorizontally(),

                    new Label("Welcome to Sharp.UI Quick Samples Gallery")
                        .FontSize(e => e.OnPhone(12).Default(20))
                        .CenterHorizontally(),

                    new Button("Click me")
                        .FontSize(20)
                        .CenterHorizontally()
                        .Margin(top: 20)
                        .OnClicked(button =>
                        {
                            count++;
                            button.Text = $"Clicked n {count} ";
                            button.Text += count == 1 ? "time" : "times";
                        })
                }
            }
            .IsExpanded(true)
            .Title("Hello World Example")
            .SourceText(mySourceCode)
        };
    }
}
