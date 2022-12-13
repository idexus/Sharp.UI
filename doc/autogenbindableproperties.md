# Bindable Properties

Sharp.UI automatically generates bindable properties and helper methods for `[SharpObject]` classes with interfaces with the `[BindableProperties]` attribute.

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

A control template view

```cs
public class CardViewTemplateView : ContentView
{
    public CardViewTemplateView()
    {
        Content = new Border
        {
            new VStack
            {
                new Label()
                    .Text(e => e.TemplatedPath("CardTitle"))
                    .FontSize(44)
                    .TextColor(Colors.White),

                new Label()
                    .Text(e => e.TemplatedPath("CardDescription"))
            }
        }
        .StrokeShape(new RoundRectangle().CornerRadius(10))
        .Stroke(e => e.TemplatedPath("BorderColor"))
        .BackgroundColor(e => e.TemplatedPath("CardColor"))
        .SizeRequest(200, 300)
        .Margin(50)
        .Padding(20);
    }
}
```

### Usage example

```cs
public class TemplatedParentPage : ContentPage
{    
    public TemplatedParentPage()
    {
        var controlTemplate = new ControlTemplate(typeof(CardViewTemplateView));

        this.Content = new VStack
        {
            new Slider(1,100, out var slider),

            new EmptyCardView()
                .CardTitle(e => e
                    .Path("Value")
                    .Source(slider)
                    .StringFormat("Value {0:F2}"))
                .CardDescription("Do you like it")
                .CardColor(Colors.Blue)
                .BorderColor(Colors.Red)
                .ControlTemplate(controlTemplate),

            new EmptyCardView()
                .CardTitle("Title 2")
                .CardDescription("Yes I do")
                .CardColor(Colors.Red)
                .BorderColor(Colors.Blue)
                .ControlTemplate(controlTemplate),

        }
        .VerticalOptions(LayoutOptions.Center);
    }
}
```