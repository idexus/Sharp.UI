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
            new CollectionView(e => e.ItemsSource(MyData.Source))
            {
                () => new Grid
                {
                    new Grid(e => e.ColumnDefinitions(e => e.Star(count: 2)))
                    {
                        new Label(),

                        new Label()
                            .Text(e => e.Path("Id"))
                            .FontSize(20)
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