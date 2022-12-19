namespace Sharp.UI.Example;

using Sharp.UI;

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

[SharpObject]
public partial class CardView : ContentView, ICardViewProperties
{
    public event EventHandler Clicked;

    public CardView(int eventHandler)
    {
        this.BindingContext = this;
        Content = new Border
        {            
            new Grid
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
                    .HorizontalOptions(LayoutOptions.Center)
                    .VerticalOptions(LayoutOptions.Center)
                    .SizeRequest(120,120),

                new Button()
                    .Row(2)                    
                    .Text(e => e.Path(nameof(ButtonTitle)))
                    .BackgroundColor(AppColors.Gray600)
                    .TextColor(AppColors.Gray100)
                    .OnClicked((sender, e) => Clicked(sender,e))
            }
            .RowDefinitions(e => e.Star(1).Star(2).Star(0.7))
            .RowSpacing(10)
        }
        .StrokeShape(new RoundRectangle().CornerRadius(10))
        .Stroke(e => e.Path(nameof(BorderColor)))
        .BackgroundColor(e => e.Path(nameof(CardColor)))
        .SizeRequest(200, 300)
        .Margin(50)
        .Padding(20);
    }

}

public class CardViewPage : ContentPage
{    
    public CardViewPage()
    {
        this.Content = new VStack
        {
            new Slider(1,100, out var slider),

            new HStack
            {
                new CardView(out var cardNo1)
                    .CardTitle(e => e
                        .Path("Value")
                        .Source(slider)
                        .StringFormat("Value {0:F1}"))
                    .ButtonTitle("Play")
                    .CardDescription("Do you like it")
                    .CardColor(Colors.Blue)
                    .BorderColor(Colors.Red)
                    .ContentView(new Image("dotnet_bot.png").Aspect(Aspect.AspectFit))
                    .OnClicked(e =>
                    {
                        cardNo1.CardDescription = "Let's play :)";
                    }),

                new CardView(out var cardView)
                    .CardTitle("Title 2")
                    .ButtonTitle("Stop")
                    .CardDescription("Yes I do")
                    .CardColor(Colors.Red)
                    .BorderColor(Colors.Blue)
                    .ContentView(new VStack
                    {
                        new Label("This is a simple card view example")
                    })
                    .DescriptionStyle(new Style<Label>
                    {
                        Label.TextColorProperty.Set(Colors.Blue),
                        Label.FontSizeProperty.Set(20)
                    })
            }
            .HorizontalOptions(LayoutOptions.Center)
        }
        .VerticalOptions(LayoutOptions.Center)
        .Padding(100);
    }
}
