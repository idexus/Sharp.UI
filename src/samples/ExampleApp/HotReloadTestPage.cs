using System;
using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp
{
    using System.ComponentModel;
    using Sharp.UI;

    [SharpObject]
    public partial class HotReloadTestPage : ContentPage
    {
        private readonly Button button;
        private readonly Switch testSwitch;

        MyViewModel viewModel => BindingContext as MyViewModel;

        public HotReloadTestPage(MyViewModel viewModel)
        {
            BindingContext = viewModel;
            Content = new Grid(out var grid)
            {
                new VStack(out var vStack, e => e.VerticalOptions(LayoutOptions.Center))
                {
                    new Label("Hot Reload :)", out var label),

                    new Slider(1, 30, 1, out var slider)
                        .Value(e => e.Path("SliderValue"))
                        .Margin(new Thickness(50, 20))
                        .WidthRequest(400)
                        .OnValueChanged(s =>
                        {
                            button.IsEnabled = s.Value < 10;
                        }),
                    
                    new Border(e => e
                        .SizeRequest(270, 430)
                        .StrokeShape(new RoundRectangle().CornerRadius(40)))
                    {
                        new Grid(e => e.RowDefinitions(e => e.Star(1.3).Star(3).Star().Star()))
                        {
                            new Label()
                                .Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F1}"))
                                .FontSize(40),

                            new Image("dotnet_bot.png").Row(1),

                            new Label("Hello, World!").Row(2)
                                .VerticalOptions(LayoutOptions.End)
                                .FontSize(30),

                            new Switch(out testSwitch).Row(3)
                                .VerticalOptions(LayoutOptions.Center)
                                .HorizontalOptions(LayoutOptions.Center)

                        }
                    },

                    new Label()
                        .Text(e => e.Path("Counter").StringFormat("Counter : {0}"))
                        .Margin(20),

                    new Button("Click me", out button)
                        .OnClicked(async (Button sender) =>
                        {
                            viewModel.Count();
                            _ = sender.AnimateFontSizeTo((viewModel.Counter % 2 == 1 ? 30 : 50));
                            await vStack.RotateYTo(((viewModel.Counter%4) switch { 0 => 20, 1 => 0, 2 => -20, _ => 0 }));
                        })
                }
            };

            Resources = new ResourceDictionary
            {
                new Style<Label>(e => e
                    .FontSize(35)
                    .TextColor(AppColors.Gray200)
                    .HorizontalOptions(LayoutOptions.Center)
                    .VerticalOptions(LayoutOptions.Center)),

                new Style<Border>
                {
                    e => e.BackgroundColor(AppColors.Gray950),

                    new VisualState<Border> {
                        async border => {
                            await border.AnimateBackgroundColorTo(Colors.Red, 700);
                            await label.RotateXTo(360, 400);
                        },
                        new StateTrigger().IsActive(e => e.Path("IsToggled").Source(testSwitch))
                    },

                    new VisualState<Border> {
                        async border => {
                            await border.AnimateBackgroundColorTo(AppColors.Gray950, 700);
                            await label.RotateXTo(0, 400);
                        },
                        new StateTrigger().IsActive(e => e.Path("IsToggled").Source(testSwitch).Negate())
                    }
                },

                new Style<Button>
                {
                    e => e
                        .BackgroundColor(AppColors.Gray950)
                        .Padding(20)
                        .FontSize(30)
                        .CornerRadius(10)
                        .SizeRequest(180,60),

                    new VisualState<Button>(VisualStates.Button.Normal)
                    {
                        button => {
                            button.AnimateSizeRequestTo(270, 90);
                            button.RotateTo(0);
                        }
                    },

                    new VisualState<Button>(VisualStates.Button.Disabled)
                    {
                        button => {
                            button.AnimateSizeRequestTo(180,60);
                            button.RotateTo(180);
                        }
                    }
                }
            };
        }
    }
}