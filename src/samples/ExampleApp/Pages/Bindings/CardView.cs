using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp;

using CodeMarkup.Maui;

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

[CodeMarkup]
[ContentProperty(nameof(ContentView))]
public partial class CardView : ContentView, ICardViewProperties
{
    public event EventHandler Clicked;

    public CardView() 
    {
        BindingContext = this; 

        Content =
            new Border(e => e
                .StrokeShape(new RoundRectangle().CornerRadius(20))
                .Stroke(e => e.Path(nameof(BorderColor)))
                .BackgroundColor(e => e.Path(nameof(CardColor)))
                .SizeRequest(250, 350)
                .Margin(20)
                .Padding(25))
            {                
                new Grid
                {
                    e => e
                        .RowDefinitions(e => e.Star(1).Star(2).Star(0.7))
                        .RowSpacing(10),

                    new VStack 
                    {
                        new Label()
                            .Text(e => e.Path(nameof(CardTitle)))
                            .FontSize(25)
                            .HorizontalTextAlignment(TextAlignment.Center)
                            .TextColor(Colors.White),

                        new Label()
                            .HorizontalTextAlignment(TextAlignment.Center)
                            .Text(e => e.Path(nameof(CardDescription)))
                            .Style(e => e.Path(nameof(DescriptionStyle))),
                    },

                    new ContentView()
                        .Row(1)
                        .Content(e => e.Path(nameof(ContentView)))
                        .FillHorizontally(),

                    new Button()
                        .Row(2)
                        .FontSize(18)
                        .Text(e => e.Path(nameof(ButtonTitle)))
                        .BackgroundColor(AppColors.Gray600)
                        .TextColor(AppColors.Gray100)
                        .OnClicked((sender, e) => Clicked(sender,e))
                }
            };
    }
}
