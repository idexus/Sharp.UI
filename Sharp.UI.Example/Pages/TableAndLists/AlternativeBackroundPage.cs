using System;
using System.Collections.ObjectModel;

namespace Sharp.UI.Example
{
    using Sharp.UI;

    public class AlternativeBackroundPage : ContentPage
    {
        private List<int> _nubmers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public List<int> Numbers => _nubmers;

        public AlternativeBackroundPage()
        {
            Content = new VStack
            {
                new CollectionView
                {
                    () => new Label()
                            .Text(e => e.Path("."))
                            .TextColor(Colors.Gray)
                            .BackgroundColor(e => e
                                .Path(".")
                                .Convert((int n) => n%2 == 0 ? Colors.White : Colors.Black))
                }
                .ItemsSource(Numbers)
            };
        }
    }
}
