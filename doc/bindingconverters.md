# Binding Converters

This code is an example of how to use binding converters in `Sharp.UI`. 

A `CollectionView` is defined and for each item in the `Numbers` list, a label is created with text equal to the value of the item. The `BackgroundColor` property of the label is bound to the item using the `Convert` method, which takes in a function that converts the value of the item (an integer) to a color. In this case, the function checks if the number is even or odd, and returns either `Colors.White` or `Colors.Black` based on the result.

```cs
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
                    .FontSize(30)
                    .Text(e => e.Path("."))
                    .TextColor(Colors.Gray)
                    .BackgroundColor(e => e
                        .Path(".")
                        .Convert((int n) => n % 2 == 0 ? Colors.White : Colors.Black)
                    )
            }
            .ItemsSource(Numbers)
        };
    }
}
```
