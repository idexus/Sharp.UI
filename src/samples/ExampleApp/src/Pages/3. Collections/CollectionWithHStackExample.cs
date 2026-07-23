using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public sealed partial class CollectionWithHStackExample : ContentPage
    {
        string mySourceCode = """
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
                    .FontSize(25)
                    .TextColor(AppColors.Gray400)
                    .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)

                new Label()
                    .Text(e => e.Path("Name").StringFormat("Name: {0} "))
                    .FontSize(25)
                    .BackgroundColor(Colors.Transparent) // has to be set (MAUI bug workaround)
            })
}
""";

        protected override void Build()
        {
            Content = new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
            {
                new Example
                {
                    new VStack(e => e.BackgroundColor(Colors.Black))
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
                                        .FontSize(25)
                                        .TextColor(AppColors.Gray400)
                                        .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)

                                    new Label()
                                        .Text(e => e.Path("Name").StringFormat("Name: {0} "))
                                        .FontSize(25)
                                        .BackgroundColor(Colors.Transparent) // has to be set (MAUI bug workaround)
                                })
                    }
                }
                .IsExpanded(true)
                .Title("CollectionView with HStack example")
                .SourceText(mySourceCode)
            };
        }
    }
}