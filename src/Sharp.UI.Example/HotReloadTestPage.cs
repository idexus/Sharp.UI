using System;
namespace ExampleApp
{
    using Sharp.UI;

    [SharpObject]
    public partial class HotReloadTestPage : ContentPage
    {
        MyViewModel viewModel => BindingContext as MyViewModel;

        public HotReloadTestPage(MyViewModel viewModel)
        {
            BindingContext = viewModel;
            Resources = AppResources.Default;

            Content = new Grid
            {
                e => e.BackgroundColor(Colors.Black),

                new VStack(out var vStack)
                {
                    e => e.VerticalOptions(LayoutOptions.Center),

                    new Label("Hot Reload :)")
                        .FontSize(45)
                        .TextColor(AppColors.Gray200)
                        .HorizontalOptions(LayoutOptions.Center)
                        .Configure(label =>
                        {
                            Task.Run(async () =>
                            {
                                await Task.Delay(200);
                                await label.RotateTo(360, 300);
                            });
                        }),

                    new Slider(1, 30, 1, out var slider)
                        .Value(e => e.Path("SliderValue"))
                        .Margin(new Thickness(50, 30))
                        .WidthRequest(400),

                    new Border
                    {
                        e => e
                            .SizeRequest(270, 430)
                            .Margin(10)
                            .StrokeShape(new RoundRectangle().CornerRadius(40))
                            .BackgroundColor(AppColors.Gray950),

                        new Grid
                        {
                            e => e.RowDefinitions(e => e.Star().Star(2).Star()),

                            new Label()
                                .Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F1}"))
                                .FontSize(40)
                                .TextColor(Colors.DarkGray)
                                .HorizontalOptions(LayoutOptions.Center)
                                .VerticalOptions(LayoutOptions.Center),

                            new Image("dotnet_bot.png").Row(1),

                            new Label("Hello, World!").Row(2)
                                .FontSize(30)
                                .TextColor(Colors.DarkGray)
                                .HorizontalOptions(LayoutOptions.Center)
                                .VerticalOptions(LayoutOptions.Center)
                        }
                    },

                    new Label()
                        .Text(e => e.Path("Counter").StringFormat("Counter : {0}"))
                        .FontSize(30)
                        .HorizontalOptions(LayoutOptions.Center)
                        .Margin(30),

                    new Button("Click me")
                        .BackgroundColor(AppColors.Gray950)
                        .TextColor(Colors.White)
                        .FontSize(22)
                        .WidthRequest(270)
                        .OnClicked(async (Button sender) =>
                        {
                            viewModel.Count();
                            await vStack.RotateYTo(15, 50);
                            await vStack.RotateYTo(-15, 150);
                            await vStack.RotateYTo(0, 150);
                        })
                }
            };
        }
    }

}