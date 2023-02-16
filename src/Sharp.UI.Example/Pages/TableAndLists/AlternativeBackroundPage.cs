using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public class AlternativeBackroundPage : ContentPage
    {
        private List<int> _nubmers = Enumerable.Range(1,100).ToList();
        public List<int> Numbers => _nubmers;

        public AlternativeBackroundPage()
        {
            Content =
                new CollectionView(e => e
                    .Margin(new Thickness(0, 30, 0, 0))
                    .ItemsSource(Numbers))
                {
                    () => new Label()
                        .FontSize(30)
                        .Text(e => e.Path("."))
                        .TextColor(Colors.Gray)
                        .BackgroundColor(e => e
                            .Path(".")
                            .Convert((int n) => n%2 == 0 ? Colors.White : Colors.Black)
                        )
                };
        }
    }
}
