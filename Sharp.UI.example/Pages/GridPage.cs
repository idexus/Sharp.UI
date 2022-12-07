namespace Sharp.UI.Example
{
    public class GridPage : ContentPage
    {
        public GridPage()
        {
            Content = new Grid(out var grid)
            {
                new BoxView().Color(Colors.Green),
                new Label("Column 0, Row 0"),

                new BoxView().Color(Colors.Blue).GridColumn(1).GridRow(0),
                new Label("Column 1, Row 0").GridColumn(1).GridRow(0),

                new BoxView().Color(Colors.Teal).GridColumn(0).GridRow(1),
                new Label("Column 0, Row 1").GridColumn(0).GridRow(1),

                new BoxView().Color(Colors.Purple).GridColumn(1).GridRow(1),
                new Label("Column 1, Row 1").GridColumn(1).GridRow(1),

                new BoxView().Color(Colors.Red).GridColumn(0).GridRow(2).Span(column: 2),
                new Label("Column 0, Row 2, Span 2 columns").GridColumn(0).GridRow(2).Span(column: 2),

                new Button("Change background color")
                    .GridColumn(0).GridRow(3)
                    .Span(column: 2)
                    .OnClicked(e =>
                    {
                        grid.BackgroundColor = Colors.DarkRed;
                    })
            }
            .RowSpacing(15)
            .ColumnSpacing(15)
            .Padding(10)
            .RowDefinitions(e => e.Star(2).Star().Absolute(100).Absolute(100))
            .ColumnDefinitions(e => e.Star().Star(2));

            this.ShellPresentationMode(PresentationMode.NotAnimated);
        }
    }
}
