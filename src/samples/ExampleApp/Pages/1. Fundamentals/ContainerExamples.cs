namespace ExampleApp;

using Sharp.UI;

public partial class ContainerExamples : ContentPage
{

    string[] mySourceCode = [
        // -------------
"""
new VStack
{
    new Label("VStack example")
        .FontSize(25)
        .CenterHorizontally(),

    new Button("Click me")
        .Margin(0, 10)
        .SizeRequest(100, 50)
        .OnClicked(e =>
        {
            e.Text = "Clicked";
        })
}
""",
        // -------------
"""
new HStack
{
    new Label("HStack")
        .FontSize(20),

    new Button("Click me")
        .Margin(0, 10)
        .SizeRequest(100, 50)
        .OnClicked(e =>
        {
            e.Text = "Clicked";
        })
}
.BackgroundColor(Colors.Green)
.CenterHorizontally()
.Padding(20)
.Spacing(20)
""",
     // -------------
"""
new VStack
{
    e => e
        .BackgroundColor(Colors.Green)
        .CenterHorizontally()                           
        .Padding(20),

    new Label("VStack")
        .FontSize(20),

    new Button("Click me")
        .Margin(0, 10)
        .SizeRequest(100, 50)
        .OnClicked(e =>
        {
            e.Text = "Clicked";
        })
}
"""];

    protected override View Build()
    {
        return new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new VStack {
                new Example
                {
                    new VStack
                    {
                        new Label("VStack example")
                            .FontSize(25)
                            .CenterHorizontally(),

                        new Button("Click me")
                            .Margin(0, 10)
                            .SizeRequest(100, 50)
                            .OnClicked(e =>
                            {
                                e.Text = "Clicked";
                            })
                    }
                }
                .IsExpanded(true)
                .Title("An example of VStack container")
                .SourceText(mySourceCode[0]),

                new Example
                {
                    new HStack
                    {
                        new Label("HStack")
                            .FontSize(20),

                        new Button("Click me")
                            .Margin(0, 10)
                            .SizeRequest(100, 50)
                            .OnClicked(e =>
                            {
                                e.Text = "Clicked";
                            })
                    }
                    .BackgroundColor(Colors.Green)
                    .CenterHorizontally()
                    .Padding(20)
                    .Spacing(20)
                }
                .Title("Setting containers properties")
                .SourceText(mySourceCode[1]),

                new Example
                {
                    new VStack
                    {
                        e => e
                            .BackgroundColor(Colors.Green)
                            .CenterHorizontally()                           
                            .Padding(20),

                        new Label("VStack")
                            .FontSize(20),

                        new Button("Click me")
                            .Margin(0, 10)
                            .SizeRequest(100, 50)
                            .OnClicked(e =>
                            {
                                e.Text = "Clicked";
                            })
                    }
                }
                .Title("Setting containers properties in body")
                .SourceText(mySourceCode[2]),
            }
            .Spacing(20)
        };
    }
}
