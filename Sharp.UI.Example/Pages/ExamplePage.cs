using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExampleApp;

using Sharp.UI;

public class ExamplePage : ContentPage
{
    private int counter;

    public ExamplePage()
    {
        Resources = new ResourceDictionary {
            new Style<Label>
            {
                Label.TextColorProperty.Set().OnDark(Colors.LightCyan),
                Label.FontSizeProperty.Set(20),
                Label.HorizontalOptionsProperty.Set(LayoutOptions.Center),
                Label.PaddingProperty.Set().OniOS(20)
            }
        };

        Content = new ScrollView {
            new VStack
            {
                new Label("This is a test"),

                new HStack {
                    new Label("It is a simple label", out var label1),
                    new Label().Text(" (+)"),
                }
                .HorizontalOptions(LayoutOptions.Center),

                new Label()
                    .FontSize(e => e.Path(nameof(Slider.Value)))
                    .Assign(out var label2)
                    .Text(e => e.Path(nameof(Slider.Value)).StringFormat("Slider Value : {0}")),

                new Button("Test it")
                    .HorizontalOptions(LayoutOptions.Center)
                    .OnClicked(o =>
                    {
                        counter++;
                        label1.Text = $"Counter : {counter}";
                        label2.TextColor = Colors.Red;
                    }),

                new Slider(10, 50)
                    .Value(50)
                    .Assign(out var slider)
            }
            .Configure(e =>
            {
                e.Add(new Label($"Added Labels")
                        .FontSize(40)
                        .TextColor(Colors.Yellow)
                        .Margin(30));

                for (int i = 1; i<50; i++) {
                    e.Add(new Label($"Label id: {i}")
                        .FontSize(40));
                }
            })

        }        
        .Margin(new Thickness(0,50,0,0))
        .Configure(e =>
        {
            label2.BindingContext = slider;
        });
    }
}