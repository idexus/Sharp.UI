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
                    new Label("Hot Reload Test :)")
                        .FontSize(55)
                        .TextColor(Colors.Red)
                        .HorizontalOptions(LayoutOptions.Center),

                    new Slider(1, 20, 1, out var slider)
                        .Value(e => e.Path(nameof(MyViewModel.SliderValue)))
                        .Margin(new Thickness(80, 30)),

                    new Border
                    {
                        new Grid
                        {
                            new Label()
                                .FontSize(40)
                                .Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F2}"))
                                .HorizontalOptions(LayoutOptions.Center)
                                .VerticalOptions(LayoutOptions.Center)
                                .TextColor(AppColors.Gray200),

                            new Image("dotnet_bot.png").Row(1),

                            new Label("Hello, World").Row(2)
                                .FontSize(40)
                                .TextColor(AppColors.Gray200)
                                .HorizontalOptions(LayoutOptions.Center)
                                .VerticalOptions(LayoutOptions.Center),
                        }
                        .RowDefinitions(e => e.Star().Star(2).Star())
                    }
                    .SizeRequest(300, 500)
                    .StrokeShape(new RoundRectangle().CornerRadius(30))
                    .BackgroundColor(Colors.DarkSlateGray),

                    new Label()
                        .Text(e => e.Path("Counter").StringFormat("Counter : {0}"))
                        .TextColor(Colors.Red)
                        .FontSize(50)
                        .HorizontalOptions(LayoutOptions.Center)
                        .Margin(20),

                    new Button("Count")
                        .WidthRequest(300)
                        .FontSize(30)
                        .Command(e => e.Path(nameof(MyViewModel.CountCommand)))
                }
                .VerticalOptions(LayoutOptions.Center)
            }
            .Background(AppColors.Gray950);
        }
    }
}

