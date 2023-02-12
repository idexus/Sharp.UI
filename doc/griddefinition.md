# Grid Definition

The `Grid` element allows you to create complex, multi-row and multi-column layout using Row and Column definitions. You can define the number and size of the rows and columns using the `RowDefinitions` and `ColumnDefinitions` methods, respectively.

You can set the position of a child element within the grid using the `Row()`, `Column()`, `ColumnSpan()`, and `RowSpan()` methods. These methods match the attached properties `Grid.Row`, `Grid.Column`, `Grid.ColumnSpan`, and `Grid.RowSpan`, respectively.

### Row and column definition

You can define the number and size of the rows and columns in a Grid element using the following methods:

```cs
new Grid
{
    ...
}
.RowDefinitions(e => e.Star(2).Star().Star(3))
.ColumnDefinitions(e => e.Absolute(100).Star());
``` 

In this example, you are defining:

- Three rows (`Star(2)`, `Star()`, `Star(3)`)
- Two columns (`Absolute(100)`, `Star()`)

### Example grid definition

Here is an example of a grid definition:

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
