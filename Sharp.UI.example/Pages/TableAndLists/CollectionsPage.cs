using System;
using System.Collections.ObjectModel;

namespace Sharp.UI.Example
{

    public class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            Content = new VStack
            {
                new Label("CollectionView")
                    .FontSize(40)
                    .TextColor(Colors.Yellow)
                    .BackgroundColor(AppColors.Gray900),

                new CollectionView()
                    .ItemsSource(DataModel.SimpleData)
                    .ItemTemplate(() =>
                        new HStack()
                            .VerticalOptions(LayoutOptions.Center)
                            .Padding(new Thickness(10))
                            .Assign(out var hStack)
                            .Children(new View[]
                            {
                                new Image("dotnet_bot.png")
                                    .WidthRequest(50)
                                    .HeightRequest(50),

                                new Label()
                                    .Text(e => e.Path("Id").StringFormat("Id: {0}, "))
                                    .FontSize(30).TextColor(Colors.Blue),

                                new Label()
                                    .Text(e => e.Path("Name").StringFormat("Name: {0} "))
                                    .FontSize(30)
                            })),
            }
            .Margin(new Thickness(0, 30, 0, 0));
        }
    }
}
