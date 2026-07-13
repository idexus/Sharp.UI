using System;
using System.Linq;

namespace ExampleApp;

using System.Data.Common;
using Sharp.UI;

public class CollectionWithGridExample : ContentPage
{
    string mySourceCode = """
new CollectionView()
    .ItemsSource(MyData.Source)
    .Margin(new Thickness(0, 50, 0, 0))
    .ItemTemplate(() =>
        new Grid
        {
            e => e.ColumnDefinitions(e => e.Auto().Star()),

            new Label()
                .Text(e => e.Path("Id"))
                .Padding(20)
                .FontSize(50)
                .TextColor(Colors.Blue)
                .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)

            new Label()
                .Column(1)
                .FontSize(20)
                .Text(e => e.Path("Text"))
                .HeightRequest(200)
                .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)
        })
""";

    public static int count = 0;

    protected override View Build()
    {
        return new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new Example
            {
                new CollectionView()
                    .ItemsSource(MyData.Source)
                    .Margin(new Thickness(0, 50, 0, 0))
                    .ItemTemplate(() =>
                        new Grid
                        {
                            e => e.ColumnDefinitions(e => e.Auto().Star()),

                            new Label()
                                .Text(e => e.Path("Id"))
                                .Padding(20)
                                .FontSize(50)
                                .TextColor(Colors.Blue)
                                .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)

                            new Label()
                                .Column(1)
                                .FontSize(20)
                                .Text(e => e.Path("Text"))
                                .HeightRequest(200)
                                .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)
                        })
            }
            .IsExpanded(true)
            .Title("Hello World Example")
            .SourceText(mySourceCode)
        };
    }
}