using System;
using System.Linq;

namespace ExampleApp;

using System.Data.Common;
using CodeMarkup.Maui;

public class ScrollPage : ContentPage
{
    public static int count = 0;
    public ScrollPage()
    {
        Content =
            new CollectionView()
                .ItemsSource(MyData.Source)
                .Margin(new Thickness(0, 50, 0, 0))
                .ItemTemplate(() =>
                    new Grid
                    {
                        e => e.ColumnDefinitions(e => e.Auto().Star()),

                        new Label(),

                        new Label()
                            .Margin(50)
                            .Text(e => e.Path("Id"))
                            .CenterHorizontally()
                            .CenterVertically()
                            .FontSize(50)
                            .TextColor(Colors.Blue)
                            .HeightRequest(50),

                        new Label()
                            .Column(1)
                            .FontSize(20)
                            .Text(e => e.Path("Text"))
                            .HeightRequest(200),
                    });            
    }
}