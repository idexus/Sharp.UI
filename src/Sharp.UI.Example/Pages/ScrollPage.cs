using System;
using System.Linq;

namespace ExampleApp;

using System.Data.Common;
using Sharp.UI;

public class ScrollPage : ContentPage
{
    public static int count = 0;
    public ScrollPage()
    {
        Content =
            new CollectionView(e => e
                .ItemsSource(MyData.Source)
                .Margin(new Thickness(0,50,0,0)))
            {
                () => new Grid
                {
                    new Grid(e => e.ColumnDefinitions(e => e.Auto().Star()))
                    {
                        new Label(),

                        new Label()
                            .Margin(50)
                            .Text(e => e.Path("Id"))
                            .HorizontalOptions(LayoutOptions.Center)
                            .VerticalOptions(LayoutOptions.Center)
                            .FontSize(50)
                            .TextColor(Colors.Blue)
                            .HeightRequest(50),

                        new Label()
                            .Column(1)
                            .FontSize(20)
                            .Text(e => e.Path("Text"))
                            .HeightRequest(200),
                    }
                }
            };
    }
}