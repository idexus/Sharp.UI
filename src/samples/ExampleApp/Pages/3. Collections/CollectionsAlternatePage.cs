using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public class AlternateCollectionPage : ContentPage
    {
        string mySourceCode = """


class AlternateRowModel
{
    public int Id { get; set; }
    public object DataModel { get; set; }
    public Style LabelStyle => new Style<Label>(e => e.TextColor(Id % 2 == 0 ? Colors.DarkSlateGray : Colors.LightGray));
    public Style GridStyle => new Style<Grid>(e => e.Background(Id % 2 == 0 ? Colors.LightGray : Colors.DarkSlateGray));
}

// CollectionView with alternating row colors

new VStack
{
    new Label("CollectionView")
        .FontSize(40)
        .TextColor(AppColors.Gray400)
        .BackgroundColor(AppColors.Gray900),

    new CollectionView()
        .ItemSizingStrategy(ItemSizingStrategy.MeasureAllItems)
        .ItemsSource(itemSource)
        .ItemTemplate(() =>
            new Grid(e => e.ColumnDefinitions(e => e.Auto(count: 2)))
            {
                e => e.Style(e => e.Path("GridStyle")),

                new Label()
                    .Column(0)
                    .Text(e => e.Path("DataModel.Id").StringFormat("Id: {0}, "))
                    .FontSize(25).TextColor(AppColors.Gray400)
                    .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)

                new Label()
                    .Column(1)
                    .Text(e => e.Path("DataModel.Name").StringFormat("Name: {0} "))
                    .FontSize(25)
                    .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)
            })
}
""";
        class AlternateRowModel
        {
            public int Id { get; set; }
            public object DataModel { get; set; }
            public Style LabelStyle => new Style<Label>(e => e.TextColor(Id % 2 == 0 ? Colors.DarkSlateGray : Colors.LightGray));
            public Style GridStyle => new Style<Grid>(e => e.Background(Id % 2 == 0 ? Colors.LightGray : Colors.DarkSlateGray));
        }

        static List<AlternateRowModel> itemSource = DataModel.SimpleData
                .Select((e, i) => new AlternateRowModel { DataModel = e, Id = i }).ToList();

        protected override View Build()
        {
            return new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
            {
                new Example
                {
                    new VStack
                    {
                        new Label("CollectionView")
                            .FontSize(40)
                            .TextColor(AppColors.Gray400)
                            .BackgroundColor(AppColors.Gray900),

                        new CollectionView()
                            .ItemSizingStrategy(ItemSizingStrategy.MeasureAllItems)
                            .ItemsSource(itemSource)
                            .ItemTemplate(() =>
                                new Grid(e => e.ColumnDefinitions(e => e.Auto(count: 2)))
                                {
                                    e => e.Style(e => e.Path("GridStyle")),

                                    new Label()
                                        .Column(0)
                                        .Text(e => e.Path("DataModel.Id").StringFormat("Id: {0}, "))
                                        .FontSize(25).TextColor(AppColors.Gray400)
                                        .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)

                                    new Label()
                                        .Column(1)
                                        .Text(e => e.Path("DataModel.Name").StringFormat("Name: {0} "))
                                        .FontSize(25)
                                        .BackgroundColor(Colors.Transparent), // has to be set (MAUI bug workaround)
                                })
                    }
                }
                .IsExpanded(true)
                .Title("Hello World Example")
                .SourceText(mySourceCode)
            };
        }
    }
}
