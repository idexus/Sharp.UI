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
            Content = new CollectionView()
                .Margin(new Thickness(0, 30, 0, 0))
                .ItemsSource(Numbers)
                .ItemTemplate(() =>
                    new Label()
                        .FontSize(30)
                        .Text(e => e.Path("."))
                        .TextColor(e => e.Path(".").Convert((int n) => n % 2 == 0 ? AppColors.Gray600 : AppColors.Gray300))
                        .BackgroundColor(e => e.Path(".").Convert((int n) => n % 2 == 0 ? AppColors.Gray200 : AppColors.Gray600)));            
        }
    }
}
