
namespace ExampleApp;

using Microsoft.Maui.Controls.Shapes;
using Sharp.UI;

public sealed partial class TestPage : ContentPage
{
    string mySourceCode = """

// Styling using Sharp.UI in C# for .NET MAUI

ResourceDictionary localResources = new()  {

    { "myColor", AppColors.Gray200 },

    new Style<Label>(e => e
        .TextColor(AppColors.Gray200)
        .CenterHorizontally()),

    new Style<Border>(e => e
        .BackgroundColor(AppColors.Gray950)
        .StrokeShape(new RoundRectangle().CornerRadius(40))),

    new Style<Slider>(e => e
        .WidthRequest(300)
        .Margin(50, 0)
        .MaximumTrackColor(Colors.White)
        .MinimumTrackColor(Colors.Gray)),

    new Style<Button>(e => e
        .BackgroundColor(AppColors.Gray950)
        .Padding(20)
        .CornerRadius(10)
        .WidthRequest(270)
        .WidthRequest(250)
        .FontSize(16)) {

        new VisualState<Button>(VisualStates.Button.Normal, e => e
            .TextColor(AppColors.Gray200))
        {            
            async button => {
                await button.RotateToAsync(0);   // create animations inside VisualState
            }
        },

        new VisualState<Button>(VisualStates.Button.Disabled, e => e
            .TextColor(AppColors.Gray600))
        {            
            async button => {
                await button.RotateToAsync(180);
            }
        },
    }
};

// UI in C# using Sharp.UI

new VStack(out var vStack)
{
    new Label(out var label)
        .TextColor(e => e.DynamicResource("myColor"))
        .Text("Sharp.UI")
        .FontSize(e => e.OnDesktop(60).Default(40)),

    new Label("for .NET Maui")
        .FontSize(20)
        .TextColor(Colors.Red),

    new Slider(out var slider)
        .Minimum(1).Maximum(30)
        .Value(e => e.Path("SliderValue"))
        .OnValueChanged(slider => button.IsEnabled = slider.Value < 10),

    new Switch(out testSwitch).Row(3)
                .Center()
                .Margin(5),

    new Border
    {
        new Grid(e => e.RowDefinitions(e => e.Star(1.3).Star(3)))
        {
            new Label()
                .Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F1}"))
                .FontSize(20)
                .Margin(5),

            new Image().Source("dotnet_bot.png").Row(1).HeightRequest(60),
        },
    }
    .SizeRequest(200, 120)
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

    new Button("Click me", out button)
        .Margin(top: 30)
        .OnClicked(async (Button b) =>
        {
            count++;
            b.Text = $"Clicked {count} ";
            b.Text += count == 1 ? "time" : "times";

            await vStack.RotateYToAsync(((count % 4) switch { 0 => 0, 1 => 20, 2 => 0, _ => -20 }));
            await label.RotateToAsync(360 * (count % 2), 300);
        })
}
.Resources(localResources)            
""";

    int count = 0;

    Button button;
    Switch testSwitch;

    protected override void Build()
    {
        Content = new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new Example
            {
                new VStack(out var vStack)
                {
                    new Label(out var label)
                        .TextColor(e => e.DynamicResource("myColor"))
                        .Text("Sharp.UI")
                        .FontSize(e => e.OnDesktop(60).Default(40)),

                    new Label("for .NET Maui")
                        .FontSize(20)
                        .TextColor(Colors.Red),

                    new Slider(out var slider)
                        .Minimum(1).Maximum(30)
                        .Value(e => e.Path("SliderValue"))
                        .OnValueChanged(slider => button.IsEnabled = slider.Value < 10),

                    new Switch(out testSwitch).Row(3)
                                .Center()
                                .Margin(5),

                    new Border
                    {
                        new Grid(e => e.RowDefinitions(e => e.Star(1.3).Star(3)))
                        {
                            new Label()
                                .Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F1}"))
                                .FontSize(20)
                                .Margin(5),

                            new Image().Source("dotnet_bot.png").Row(1).HeightRequest(60),
                        },
                    }
                    .SizeRequest(200, 120)
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

                    new Button("Click me", out button)
                        .Margin(top: 30)
                        .OnClicked(async (Button b) =>
                        {
                            count++;
                            b.Text = $"Clicked {count} ";
                            b.Text += count == 1 ? "time" : "times";

                            await vStack.RotateYToAsync(((count % 4) switch { 0 => 0, 1 => 20, 2 => 0, _ => -20 }));
                            await label.RotateToAsync(360 * (count % 2), 300);
                        })
                }
                .Resources(localResources)
            }
            .IsExpanded(true)
            .Title("Styling and animation example")
            .SourceText(mySourceCode)
        };
    }
}