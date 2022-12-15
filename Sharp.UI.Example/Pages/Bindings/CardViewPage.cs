namespace Sharp.UI.Example;

using Sharp.UI;

public class NewStyle : Style
{
    public NewStyle(Microsoft.Maui.Controls.Style style) : base(style)
    {
    }
}

[BindableProperties]
public interface ICardViewProperties
{
    string CardTitle { get; set; }
    string CardDescription { get; set; }
    Color CardColor { get; set; }
    Color BorderColor { get; set; }
    Style MyStyle { get; set; }
    NewStyle MyNewStyle { get; set; }
    View MyView { get; set; }
    HStack MyHStack { get; set; }
    object MyObject { get; set; }
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

public class CardView2 : CardView { }

public class CardViewPage : ContentPage
{    
    public CardViewPage()
    {
        this.Content = new VStack
        {
            new Slider(1,100, out var slider),

            new CardView2()
                .CardTitle(e => e
                    .Path("Value")
                    .Source(slider)
                    .StringFormat("Value {0:F2}"))
                .CardDescription("Do you like it")
                .CardColor(Colors.Blue)
                .BorderColor(Colors.Red),

            new CardView()
                .CardTitle("Title 2")
                .CardDescription("Yes I do")
                .CardColor(Colors.Red)
                .BorderColor(Colors.Blue)
        }
        .VerticalOptions(LayoutOptions.Center);
    }
}