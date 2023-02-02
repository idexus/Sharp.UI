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
                new VStack
                {
                    new Label("Hot Reload :)")
                        .FontSize(e => e.Default(40).OnDesktop(80))
                        .TextColor(Colors.Blue)
                        .HorizontalOptions(LayoutOptions.Center),

                    new Slider(1, 20, 1, out var slider)
                        .Value(e => e.Path(nameof(MyViewModel.SliderValue)))
                        .Margin(new Thickness(50, 30)),

                    new Border
                    {
                        new Grid
                        {
                            new Label()
                                .FontSize(35)
                                .Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F2}"))
                                .HorizontalOptions(LayoutOptions.Center)
                                .VerticalOptions(LayoutOptions.Center)
                                .TextColor(AppColors.Gray200),

                            new Image("dotnet_bot.png").Row(1),

                            new Label("Hello, World").Row(2)
                                .FontSize(30)
                                .TextColor(AppColors.Gray200)
                                .HorizontalOptions(LayoutOptions.Center)
                                .VerticalOptions(LayoutOptions.Center),
                        }
                        .RowDefinitions(e => e.Star().Star(2).Star())
                    }
                    .WidthRequest(e => e.Default(250).OnDesktop(300).OnAndroid(220))
                    .HeightRequest(e => e.Default(350).OnDesktop(500))
                    .StrokeShape(new RoundRectangle().CornerRadius(40))
                    .BackgroundColor(Colors.DarkSlateGray),

                    new Label()
                        .Text(e => e.Path("Counter").StringFormat("Counter : {0}"))
                        .TextColor(Colors.Red)
                        .FontSize(40)
                        .HorizontalOptions(LayoutOptions.Center)
                        .Margin(20),

                    new Button("Count")
                        .WidthRequest(200)
                        .FontSize(22)
                        .Command(e => e.Path(nameof(MyViewModel.CountCommand)))
                }
                .VerticalOptions(LayoutOptions.Center)
            }
            .Background(AppColors.Gray950);
        }
    }
}

