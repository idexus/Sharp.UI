using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExampleApp;

using Sharp.UI;

public partial class ExamplePage : ContentPage
{
    private int counter;

    protected override View Build()
    {
        Resources = new ResourceDictionary {
            new Style<Label>(e => e
                .TextColor(e => e.OnDark(Colors.LightCyan))
                .FontSize(20)
                .CenterHorizontally()
                .Padding(e => e.OniOS(20)))            
        };

        return new ScrollView
        {
            new VStack
            {
                new Label("Counter :", out var label1)
                    .FontSize(28),                    

                new Button("Count")
                    .CenterHorizontally()
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