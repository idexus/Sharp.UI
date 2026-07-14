namespace ExampleApp;

using Sharp.UI;

public sealed partial class FluentMethodsExamples : ContentPage
{

    string[] mySourceCode = [
        // -------------
"""
new Label()
    .Text("Hello World")
    .Padding(10)
    .FontSize(24)
    .BackgroundColor(Colors.Red)
""",
        // -------------
"""
new Button("Click me")
    .WidthRequest(100)
    .OnClicked(e =>
    {
        e.Text = "Clicked";
    }),
""",
        // -------------
"""
new Label("Assigning via fluent method")
    .Assign(out var myButton)
""",
     // -------------
"""
new Label("Assigning via contructor", out var button)
"""];

    protected override View Build()
    {
        return new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new VStack {
                new Example
                {
                    new Label()
                        .Text("Hello World")
                        .Padding(10)
                        .FontSize(24)
                        .BackgroundColor(Colors.Red)
                }
                .IsExpanded(true)
                .Title("An example of using fluent methods to set properties")
                .SourceText(mySourceCode[0]),

                new Example
                {
                    new Button("Click me")
                        .WidthRequest(100)
                        .OnClicked(e =>
                        {
                            e.Text = "Clicked";
                        })
                }
                .IsExpanded(true)
                .Title("An example of using fluent methods to set handler")
                .SourceText(mySourceCode[1]),

                new Example
                {
                    new Label("Assigning via fluent method")
                        .Assign(out var myButton)
                }
                .IsExpanded(true)
                .Title("Assigning objects")
                .SourceText(mySourceCode[2]),

                new Example
                {
                    new Label("Assigning via contructor", out var button)
                }
                .IsExpanded(true)
                .Title("Assigning objects via constructor")
                .SourceText(mySourceCode[3])
            }
            .Spacing(20)
        };
    }
}
