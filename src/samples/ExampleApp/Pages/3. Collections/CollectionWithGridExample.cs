using System;
using System.Linq;

namespace ExampleApp;

using System.Data.Common;
using Sharp.UI;

public sealed partial class CollectionWithGridExample : ContentPage
{
    string mySourceCode = """
new CollectionView()
    .ItemsSource(MyData.Source)
    .Margin(new Thickness(0, 20, 0, 0))              
    .ItemTemplate(() =>
        new Grid
        {
            e => e
                .ColumnDefinitions(e => e.Auto().Star())
                .Padding(10),

            new Label()
                .Text(e => e.Path("Id"))
                .FontSize(50)
                .Margin(right: 20)
                .TextColor(Colors.Blue)
                .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)

            new Label()
                .Column(1)
                .FontSize(20)
                .Text(e => e.Path("Text"))
                .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)
        })
""";

    public static int count = 0;

    protected override void Build()
    {
        Content = new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new Example
            {
                new CollectionView()
                    .ItemsSource(MyData.Source)
                    .Margin(new Thickness(0, 20, 0, 0))              
                    .ItemTemplate(() =>
                        new Grid
                        {
                            e => e
                                .ColumnDefinitions(e => e.Auto().Star())
                                .Padding(10),

                            new Label()
                                .Text(e => e.Path("Id"))
                                .FontSize(50)
                                .Margin(right: 20)
                                .TextColor(Colors.Blue)
                                .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)

                            new Label()
                                .Column(1)
                                .FontSize(20)
                                .Text(e => e.Path("Text"))
                                .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)
                        })
            }
            .IsExpanded(true)
            .Title("CollectionView with Grid example")
            .SourceText(mySourceCode)
        };
    }
}