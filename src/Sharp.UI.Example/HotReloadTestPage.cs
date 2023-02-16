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

            Content =
                new VStack
                {
                    e => e
                        .BackgroundColor(Colors.Black)
                        .Margin(e => e.Default(new Thickness(0,30,0,0)).OnWinUI(0))
                        .VerticalOptions(LayoutOptions.Center)
                        .HorizontalOptions(LayoutOptions.Center),

                    new Label("Hot Reload :)")
                        .FontSize(e => e.Default(40).OnDesktop(70))
                        .TextColor(Colors.Red)
                        .HorizontalOptions(LayoutOptions.Center),

                    new Slider(1, 20, 1, out var slider)
                        .Value(e => e.Path(nameof(MyViewModel.SliderValue)))
                        .Margin(new Thickness(50, 30))
                        .WidthRequest(400),

                    new Border
                    {
                        e => e
                            .WidthRequest(e => e.Default(220).OnDesktop(300))
                            .HeightRequest(e => e.Default(350).OnDesktop(500))
                            .StrokeShape(new RoundRectangle().CornerRadius(40))
                            .BackgroundColor(AppColors.Gray950),

                        new Grid
                        {
                            e => e.RowDefinitions(e => e.Star().Star(2).Star()),

                            new Label()
                                .FontSize(30)
                                .Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F2}"))
                                .HorizontalOptions(LayoutOptions.Center)
                                .VerticalOptions(LayoutOptions.Center)
                                .TextColor(AppColors.Gray200),

                            new Image("dotnet_bot.png").Row(1),

                            new Label("Hello, World").Row(2)
                                .FontSize(25)
                                .TextColor(AppColors.Gray200)
                                .HorizontalOptions(LayoutOptions.Center)
                                .VerticalOptions(LayoutOptions.Center),
                        }                        
                    },

                    new Label()
                        .Text(e => e.Path("Counter").StringFormat("Counter : {0}"))
                        .TextColor(AppColors.Gray400)
                        .FontSize(40)
                        .HorizontalOptions(LayoutOptions.Center)
                        .Margin(20),

                    new Button("Count")
                        .BackgroundColor(AppColors.Gray950)
                        .TextColor(AppColors.Gray100)
                        .WidthRequest(200)
                        .FontSize(22)
                        .Command(e => e.Path(nameof(MyViewModel.CountCommand)))
                };
        }
    }
}