# Control template

In `Sharp.UI`, custom control views can be easily created by implementing an interface that defines bindable properties. When the interface is implemented, all of the bindable properties defined in the interface are automatically generated in the custom control view class. This makes it simple and straightforward to use and manipulate the properties in code, without having to manually write property implementations for each one.

### Example

This code demonstrates how to create a custom control view using a control template in `Sharp.UI`.

The `ICardViewProperties` interface defines four bindable properties: `CardTitle`, `CardDescription`, `CardColor`, and `BorderColor`. The `CardView` class implements the `ICardViewProperties` interface. These properties are automatically generated in the CardView class.

```cs
[BindableProperties]
public interface ICardViewProperties
{
    string CardTitle { get; set; }
    string CardDescription { get; set; }
    Color CardColor { get; set; }
    Color BorderColor { get; set; }
}

[SharpObject]
public partial class CardView : ContentView, ICardViewProperties
{
}
```

### Consume

```cs
public class TemplatedParentPage : ContentPage
{    
    public TemplatedParentPage()
    {
        var controlTemplate = new ControlTemplate(typeof(CardViewTemplateView));
        
        this.Content = new VStack
        {
            e => e.CenterVertically(),

            new Slider(1,100, out var slider),

            new CardView()
                .CardTitle(e => e
                    .Path("Value")
                    .Source(slider)
                    .StringFormat("Value {0:F2}"))
                .CardDescription("Do you like it")
                .CardColor(Colors.Blue)
                .BorderColor(Colors.Red)
                .ControlTemplate(controlTemplate),

            new CardView()
                .CardTitle("Title 2")
                .CardDescription("Yes I do")
                .CardColor(Colors.Red)
                .BorderColor(Colors.Blue)
                .ControlTemplate(controlTemplate),

        };
    }
}
```
