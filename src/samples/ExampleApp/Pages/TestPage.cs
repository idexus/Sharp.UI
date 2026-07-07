
namespace ExampleApp; 

using Microsoft.Maui.Controls.Shapes;
using Sharp.UI;

public partial class TestPage : ContentPage
{
    int count = 0;

    Button button;
    Switch testSwitch;
    
    protected override View Build()
    {
        Resources = localResources;

        return new Grid(e => e.BackgroundColor(Colors.Black))
        {
            new VerticalStackLayout(out var vStack, e => e.VerticalOptions(LayoutOptions.Center))
            {
                new Label(out var label)
                    .TextColor(e => e.DynamicResource("myColor"))
                    .Text("Sharp.UI")
                    .FontSize(e => e.OnDesktop(100).Default(70)),

                new Label("for .NET Maui")
                    .FontSize(30)
                    .TextColor(Colors.Red),

                new Slider(out var slider)
                    .Minimum(1).Maximum(30)
                    .WidthRequest(300)
                    .Value(e => e.Path("SliderValue"))
                    .Margin(50, 30)
                    .OnValueChanged(slider => button.IsEnabled = slider.Value < 10),

                new Border
                {
                    new Grid(e => e.RowDefinitions(e => e.Star(1.3).Star(3).Star().Star()))
                    {
                        new Label()
                            .Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F1}"))
                            .FontSize(20)
                            .Margin(5),

                        new Image().Source("dotnet_bot.png").Row(1).HeightRequest(60),

                        new Label()
                            .Text("Hello, World!")
                            .Row(2)
                            .FontSize(15)
                            .TextColor(Colors.DarkGray),

                        new Switch(out testSwitch).Row(3)
                            .Center()
                            .Margin(5)
                    },
                }
                .SizeRequest(200, 200)
                .BackgroundColor(AppColors.Gray950)
                .StrokeShape(new RoundRectangle().CornerRadius(40))
                .VisualStateGroups(new VisualStateGroupList
                {
                    new VisualState<Border> {
                        async border => {
                            await border.AnimateBackgroundColorTo(Colors.Red, 500);
                            await label.RotateXToAsync(360, 400);
                        },
                        new StateTrigger().IsActive(e => e.Path("IsToggled").Source(testSwitch))
                    },

                    new VisualState<Border> {
                        async border => {
                            await border.AnimateBackgroundColorTo(AppColors.Gray950, 500);
                            await label.RotateXToAsync(0, 400);
                        },
                        new StateTrigger().IsActive(e => e.Path("IsToggled").Source(testSwitch).Negate())
                    }
                }),

                new Button(out button)
                    .Text("Click me")
                    .WidthRequest(250)
                    .Margin(30)
                    .OnClicked(async (Button b) =>
                    {
                        count++;
                        b.Text = $"Clicked {count} ";
                        b.Text += count == 1 ? "time" : "times";

                        await vStack.RotateYToAsync(((count % 4) switch { 0 => 0, 1 => 20, 2 => 0, _ => -20 }));
                        await label.RotateToAsync(360 * (count % 2), 300);
                    })
            }
        };
    }
}
