namespace Sharp.UI.Example
{
    public class GridPage : ContentPage
    {
        public GridPage()
        {
            Content =
                new Grid(out var grid)
{
    new BoxView().Color(Colors.Green),
    new Label("Column 0, Row 0"),

    new BoxView().Color(Colors.Blue).Column(1).Row(0),
    new Label("Column 1, Row 0").Column(1).Row(0),

    new BoxView().Color(Colors.Teal).Column(0).Row(1),
    new Label("Column 0, Row 1").Column(0).Row(1),

    new BoxView().Color(Colors.Purple).Column(1).Row(1),
    new Label("Column 1, Row 1").Column(1).Row(1),
}
.RowDefinitions(e => e.Star(2).Star())
.ColumnDefinitions(e => e.Absolute(100).Star());
            //new Grid(out var grid)
            //{
            //    new BoxView().Color(Colors.Green),
            //    new Label("Column 0, Row 0"),

            //    new BoxView().Color(Colors.Blue).Column(1).Row(0),
            //    new Label("Column 1, Row 0").Column(1).Row(0),

            //    new BoxView().Color(Colors.Teal).Column(0).Row(1),
            //    new Label("Column 0, Row 1").Column(0).Row(1),

            //    new BoxView().Color(Colors.Purple).Column(1).Row(1),
            //    new Label("Column 1, Row 1").Column(1).Row(1),

            //    new BoxView().Color(Colors.Red).Column(0).Row(2).Span(column: 2),
            //    new Label("Column 0, Row 2, Span 2 columns").Column(0).Row(2).Span(column: 2),

            //    new Button("Change background color")
            //        .Column(0).Row(3)
            //        .Span(column: 2)
            //        .OnClicked(e =>
            //        {
            //            grid.BackgroundColor = Colors.DarkRed;
            //        })
            //}
            //.RowSpacing(15)
            //.ColumnSpacing(15)
            //.Padding(10)
            //.RowDefinitions(e => e.Star(2).Star().Absolute(100).Absolute(100))
            //.ColumnDefinitions(e => e.Absolute(100).Star());
        }
    }
}
