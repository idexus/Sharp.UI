# Grid Definition

Using the `GridRow()`, `GridColumn()`, `GridColumnSpan()`, `GridRowSpan()` and `GridSpan()`, you can set the row, column and span within the grid definition.

```cs
new Label("Column 0, Row 2, Span 2 columns")
    .GridColumn(0)
    .GridRow(2)
    .GridColumnSpan(2)
```

Methods like `GridRow()`, `GridColumn()`, `GridColumnSpan()`, `GridRowSpan()` matches attached properties: `Grid.Row`, `Grid.Column`, `Grid.ColumnSpan` and `Grid.RowSpan`.

#### Row and column definition
Using folowing fluent methods you can define the number and sizes of rows and columns.

```cs
new Grid
{
    ...
}
.RowDefinitions(e => e.Star(2).Star().Star(3))
.ColumnDefinitions(e => e.Absolute(100).Star());
``` 

In this example you define
- 3 rows - `Star(2)`, `Star()`, `Star(3)`) 
- 2 columns - `Absolute(100)`, `Star()`


#### Example grid definition

```cs
new Grid
{
    new BoxView().Color(Colors.Green),
    new Label("Column 0, Row 0"),

    new BoxView().Color(Colors.Blue).GridColumn(1).GridRow(0),
    new Label("Column 1, Row 0").GridColumn(1).GridRow(0),

    new BoxView().Color(Colors.Teal).GridColumn(0).GridRow(1),
    new Label("Column 0, Row 1").GridColumn(0).GridRow(1),

    new BoxView().Color(Colors.Purple).GridColumn(1).GridRow(1),
    new Label("Column 1, Row 1").GridColumn(1).GridRow(1),
}
.RowDefinitions(e => e.Star(2).Star())
.ColumnDefinitions(e => e.Absolute(200).Star());
```