using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public class AlternateCollectionPage : ContentPage
    {
        class AlternateRowModel
        {
            public int Id { get; set; }
            public object DataModel { get; set; }
            public Style LabelStyle => new Style<Label> { Label.TextColorProperty.Set(Id % 2 == 0 ? Colors.DarkSlateGray : Colors.LightGray) };
            public Style GridStyle => new Style<Grid> { Grid.BackgroundProperty.Set(Id % 2 == 0 ? Colors.LightGray : Colors.DarkSlateGray) };
        }

        public AlternateCollectionPage()
        {
            var itemSource = DataModel.SimpleData
                .Select((e, i) => new AlternateRowModel { DataModel = e, Id = i });

            Content = new VStack
            {
                new CollectionView
                {
                    () => new Grid()
                    {
                        new Label()
                            .Text(e => e.Path("DataModel.Name"))
                            .Style(e => e.Path("LabelStyle"))

                    }
                    .Style(e => e.Path("GridStyle"))
                }
                .ItemsSource(itemSource)
            };
        }
    }
}
