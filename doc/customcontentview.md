# Custom Control Views

In `CodeMarkup.Maui`, you can create custom control views, and all interface bindable properties and fluent helper methods for event handlers will be generated automatically.

### Interface

To auto-generate properties, you have to use the `[BindableProperties]` attribute in the interface declaration and the `[SharpObject]` attribute in the class declaration. For example, you can declare an interface `ICardViewProperties` as follows:

```cs
[BindableProperties]
public interface ICardViewProperties
{
    string CardTitle { get; set; }
    string CardDescription { get; set; }
    Color CardColor { get; set; }
    Color BorderColor { get; set; }
    Style DescriptionStyle { get; set; }
    View ContentView { get; set; }
    string ButtonTitle { get; set; }
}
```

### Class Declaration

To automatically generate bindable properties and fluent helper methods for event handlers, you need to inherit the interface and use the `[SharpObject]` attribute. In the following example, a CardView class is declared that implements the `ICardViewProperties` interface:

```cs
[CodeMarkup]
[ContentProperty(nameof(ContentView))]
public partial class CardView : ContentView, ICardViewProperties
{
    public event EventHandler Clicked;

    public CardView()
    {
        this.BindingContext = this;

        Content =
        new Border(e => e
            .StrokeShape(new RoundRectangle().CornerRadius(10))
            .Stroke(e => e.Path(nameof(BorderColor)))
            .BackgroundColor(e => e.Path(nameof(CardColor)))
            .SizeRequest(200, 300)
            .Margin(50)
            .Padding(20))
        {
            new Grid(e => e
                .RowDefinitions(e => e.Star(1).Star(2).Star(0.7))
                .RowSpacing(10))
            {
                new VStack
                {
                    new Label()
                        .Text(e => e.Path(nameof(CardTitle)))
                        .FontSize(25)
                        .TextColor(Colors.White),

                    new Label()
                        .Text(e => e.Path(nameof(CardDescription)))
                        .Style(e => e.Path(nameof(DescriptionStyle))),
                },

                new ContentView()
                    .Row(1)
                    .Content(e => e.Path(nameof(ContentView)))
                    .Center())
                    .SizeRequest(120,120),

                new Button()
                    .Row(2)                    
                    .Text(e => e.Path(nameof(ButtonTitle)))
                    .BackgroundColor(AppColors.Gray600)
                    .TextColor(AppColors.Gray100)
                    .OnClicked((sender, e) => Clicked(sender,e))
            }
        };
    }
}
```

In the example above, the `OnClicked` fluent helper method is used to add a click event handler to the button. When the button is clicked, the code inside the lambda expression will be executed, in this case displaying an alert to the user.

Fluent helper methods are generated for each `EventHandler` in the class declaration, so you can add event handlers for different events in a similar way.
