# Grid Definition

The `Grid` element allows you to create complex, multi-row and multi-column layout using Row and Column definitions. You can define the number and size of the rows and columns using the `RowDefinitions` and `ColumnDefinitions` methods, respectively.

You can set the position of a child element within the grid using the `Row()`, `Column()`, `ColumnSpan()`, and `RowSpan()` methods. These methods match the attached properties `Grid.Row`, `Grid.Column`, `Grid.ColumnSpan`, and `Grid.RowSpan`, respectively.

### Row and column definition

Defining the number and size of rows and columns is done using the `RowDefinitions` and `ColumnDefinitions` methods, respectively. These methods take a lambda function that defines the properties for the row or column.

In the following example, you're defining a `Grid` element with four rows and two columns:

```cs
new Grid
{
    e => e
        .RowDefinitions(e => e.Star(2).Star(0.5, count: 3)))
        .ColumnDefinitions(e => e.Absolute(100).Star()),
    
    // grid content here
    ...
}
``` 

Here's what the code is doing:

The `RowDefinitions` method is defining four rows with different sizes. The first row takes up 2 stars, which means it will take up twice as much vertical space as any other row in the Grid. The second, third, and fourth rows each take up 0.5 stars. The count parameter is optional and specifies how many rows of the same size should be added to the Grid. In this case, it adds 3 rows of size 0.5 stars.

The `ColumnDefinitions` method is defining two columns. The first column is set to a fixed width of 100 pixels using the `Absolute` method, and the second column takes up the remaining space using the `Star` method.


### Example

Here is a full example of a grid definition:

```cs
new Grid
{
    e => e
        .RowDefinitions(e => e.Star(2).Star())
        .ColumnDefinitions(e => e.Absolute(200).Star()),

    new BoxView().Color(Colors.Green),
    new Label("Column 0, Row 0"),

    new BoxView().Color(Colors.Blue).Column(1).Row(0),
    new Label("Column 1, Row 0").Column(1).Row(0),

    new BoxView().Color(Colors.Teal).Column(0).Row(1),
    new Label("Column 0, Row 1").Column(0).Row(1),

    new BoxView().Color(Colors.Purple).Column(1).Row(1),
    new Label("Column 1, Row 1").Column(1).Row(1),
}
```
