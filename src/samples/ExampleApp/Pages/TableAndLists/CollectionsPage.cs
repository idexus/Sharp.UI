using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using CodeMarkup.Maui;

    public class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            Content = 
                new VStack(e => e.Margin(bottom: 30).BackgroundColor(Colors.Black))
                {
                    new Label("CollectionView")
                        .FontSize(40)
                        .TextColor(AppColors.Gray400)
                        .BackgroundColor(AppColors.Gray900),

                    new CollectionView()
                        .ItemsSource(DataModel.SimpleData)
                        .ItemTemplate(() => 
                            new HStack(e => e.CenterVertically().Padding(10))
                            {
                                new Image("dotnet_bot.png")
                                        .WidthRequest(50)
                                        .HeightRequest(50),

                                new Label()
                                    .Text(e => e.Path("Id").StringFormat("Id: {0}, "))
                                    .FontSize(25).TextColor(AppColors.Gray400),

                                new Label()
                                    .Text(e => e.Path("Name").StringFormat("Name: {0} "))
                                    .FontSize(25)
                            })                
                };
        }
    }
}