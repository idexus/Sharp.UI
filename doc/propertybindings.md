# Property Bindings

`Sharp.UI` provides a way to bind properties of an element to a source, so that when the source changes, the property changes as well. You can bind a property by using the fluent method e.g. `Text()`, `TextColor()` etc. and calling the method `Path()` to specify the property you want to bind to.


```cs
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

In this example, the text property of the label is bound to the `Value` property of a `Slider` element named `slider`. When the value of the slider changes, the text of the label will automatically update to reflect the new value.

You can also bind a property to an object that is not part of the visual tree. This is useful when you have a separate data source, such as a model or a view model, that you want to bind to a visual element.



