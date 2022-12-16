# Grid Definition

Using the `Row()`, `Column()`, `ColumnSpan()`, `RowSpan()` and `GridSpan()` methods, you can set the row, column and span within the grid definition.

```cs
new Label("Column 0, Row 2, Span 2 columns")
    .Column(0)
    .Row(2)
    .ColumnSpan(2)
```

Methods like `Row()`, `Column()`, `ColumnSpan()`, `RowSpan()` matches attached properties: `Grid.Row`, `Grid.Column`, `Grid.ColumnSpan` and `Grid.RowSpan`.

### Row and column definition
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


### Example grid definition

```cs
new Grid
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
.ColumnDefinitions(e => e.Absolute(200).Star());
```
