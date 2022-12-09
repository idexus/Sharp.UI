namespace Sharp.UI.Example;

using Sharp.UI;

[Bindable]
public interface ICardViewProperties
{
    string CardTitle { get; set; }
    string CardDescription { get; set; }
    Color CardColor { get; set; }
    Color BorderColor { get; set; }
}

[MauiWrapper]
public partial class CardView : ContentView, ICardViewProperties
{
}

public class TemplatedParentPage : ContentPage
{    
    public TemplatedParentPage()
    {
        var template = new ControlTemplate(() =>
            new Border
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
            .Padding(20)
        );

        this.Content = new VStack
        {
            new CardView()
                .CardTitle("Title 1")
                .CardDescription("Do you like it")
                .CardColor(Colors.Blue)
                .BorderColor(Colors.Red)
                .ControlTemplate(template),

            new CardView()
                .CardTitle("Title 2")
                .CardDescription("Yes I do")
                .CardColor(Colors.Red)
                .BorderColor(Colors.Blue)
                .ControlTemplate(template)
        }
        .VerticalOptions(LayoutOptions.Center);
    }
}