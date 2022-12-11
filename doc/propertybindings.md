## Bindings
Sharp.UI allows you to create bindings using a property method parameter and fluent methods.

```cs
new Label()
    .Text(e => e.Path("Author"))
    .TextColor(e => e.Path("TextColor").Source(myColors))
``` 
Example of bindings between objects

```cs
using Sharp.UI;

public class SimpleBindings : ContentPage
{
    public SimpleBindings()
    {
        this.Content = new VStack
        {
            new Slider(out var slider)
                .Minimum(1)
                .Maximum(20),

            new Label()
                .Text(e => e
                    .Path("Value")
                    .Source(slider)
                    .StringFormat("Slider value: {0}")
                )
                .FontSize(28)
                .TextColor(Colors.Blue)
        }
        .VerticalOptions(LayoutOptions.Center);
    }
}
```