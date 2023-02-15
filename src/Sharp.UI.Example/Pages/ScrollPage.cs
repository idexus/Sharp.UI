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
                () => new VStack
                {
                    new Label()
                        .Text(e => e.Path("Id"))
                        .FontSize(30)
                        .TextColor(Colors.Blue),

                    new Label()
                        .FontSize(20)
                        .Text(e => e.Path("Text"))
                        .HeightRequest(200),
                }
            };
    }
}