# Custom ContentView

In `Sharp.UI` you can create custom control views and all interface bindable properties will be generated automatically.

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
    public CardView()
    {
        this.BindingContext = this;
        Content = new Border
        {
            new VStack
            {
                new Label()
                    .Text(e => e.Path(nameof(CardTitle)))
                    .FontSize(44)
                    .TextColor(Colors.White),

                new Label()
                    .Text(e => e.Path(nameof(CardDescription)))
            }
        }
        .StrokeShape(new RoundRectangle().CornerRadius(10))
        .Stroke(e => e.Path(nameof(BorderColor)))
        .BackgroundColor(e => e.Path(nameof(CardColor)))
        .SizeRequest(200, 300)
        .Margin(50)
        .Padding(20);
    }
}
```
#### Usage example

```cs
new CardView()
    .CardTitle("Title 2")
    .CardDescription("Yes I do")
    .CardColor(Colors.Red)
    .BorderColor(Colors.Blue)
```