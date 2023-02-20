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

        Content =
            new ScrollView
            {
                new VStack
                {
                    new Label("Counter :", out var label1)
                        .FontSize(28),                    

                    new Button("Count")
                        .HorizontalOptions(LayoutOptions.Center)
                        .SizeRequest(100,50)
                        .OnClicked(o =>
                        {
                            counter++;
                            label1.Text = $"Counter : {counter}";
                        }),

                    Enumerable.Range(1, 100).Select(e => new Label($"Label id: {e}").FontSize(20))
                }
            }
            .Margin(new Thickness(0, 50, 0, 0));
    }
}