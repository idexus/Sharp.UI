using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            Content = new VStack
            {
                e => e
                    .Margin(new Thickness(0, 30, 0, 0))
                    .BackgroundColor(Colors.Black),

                new Label("CollectionView")
                    .FontSize(40)
                    .TextColor(AppColors.Gray400)
                    .BackgroundColor(AppColors.Gray900),

                new CollectionView()
                    .ItemsSource(DataModel.SimpleData)
                    .ItemTemplate(() =>
                        new HStack
                        {
                            e => e
                                .VerticalOptions(LayoutOptions.Center)
                                .Padding(new Thickness(10))
                                .Assign(out var hStack),

                            new Image("dotnet_bot.png")
                                    .WidthRequest(50)
                                    .HeightRequest(50),

                            new Label()
                                .Text(e => e.Path("Id").StringFormat("Id: {0}, "))
                                .FontSize(25).TextColor(AppColors.Gray400),

                            new Label()
                                .Text(e => e.Path("Name").StringFormat("Name: {0} "))
                                .FontSize(25)
                        }),
            };
        }
    }
}
