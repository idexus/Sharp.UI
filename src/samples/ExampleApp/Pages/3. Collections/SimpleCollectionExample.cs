using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public class SimpleCollectionExample : ContentPage
    {
        string mySourceCode = """
public static List<int> Numbers = Enumerable.Range(1, 10).ToList();

// CollectionView with a simple list of numbers

new CollectionView()
.Margin(new Thickness(0, 30, 0, 0))
.ItemsSource(Numbers)
.ItemTemplate(() =>
    new Label()
        .FontSize(30)
        .Text(e => e.Path("."))
        .BackgroundColor(Colors.Transparent)) // has to be set (MAUI bug workaround)
""";

        public static List<int> Numbers = Enumerable.Range(1, 10).ToList();

        protected override View Build()
        {
            return new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
            {
                new Example
                {
                    new CollectionView()
                        .Margin(new Thickness(0, 30, 0, 0))
                        .ItemsSource(Numbers)
                        .ItemTemplate(() =>
                            new Label()
                                .FontSize(30)
                                .Text(e => e.Path("."))
                                .BackgroundColor(Colors.Transparent)) // has to be set (MAUI bug workaround)
                }
                .IsExpanded(true)
                .Title("Hello World Example")
                .SourceText(mySourceCode)
            };
        }
    }
}
