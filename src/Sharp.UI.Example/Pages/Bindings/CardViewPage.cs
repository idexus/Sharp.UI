namespace ExampleApp;

using Sharp.UI;

public partial class CardViewPage : ContentPage
{    
    public CardViewPage()
    {
        var labelStyle = new Style<Label>
        {
            Label.TextColorProperty.Set(Colors.Blue),
            Label.FontSizeProperty.Set(21)
        };

        this.Content = new ScrollView
        {
            e => e.Margin(new Thickness(0, 30, 0, 0)),

            new VStack
            {
                e => e.HorizontalOptions(LayoutOptions.Center),

                new Label(out var label)
                    .HorizontalOptions(LayoutOptions.Center)
                    .Text($"Counter {counter}")
                    .FontSize(30)
                    .Margin(40),

                new Slider(1,100, out var slider)
                    .Margin(30),

                new StackLayout
                {
                    e => e                        
                        .Orientation(e => e.OnPhone(StackOrientation.Vertical).Default(StackOrientation.Horizontal))
                        .HorizontalOptions(LayoutOptions.Center),

                    new CardView(out var cardNo1)
                    {
                        e => e
                            .CardTitle(e => e.Path("Value").Source(slider).StringFormat("Value {0:F1}"))
                            .ButtonTitle("Play")
                            .CardDescription("Do you like it?")
                            .CardColor(Colors.Blue)
                            .BorderColor(Colors.Red)
                            .OnClicked(e =>
                            {
                                cardNo1.CardDescription = "Let's play :)";
                            }),

                        new Image("dotnet_bot.png")
                            .Aspect(Aspect.AspectFit)
                    },

                    new CardView(out var cardView)
                    {
                        e => e
                            .CardTitle("Title")
                            .CardDescription("Yes I do")
                            .CardColor(Colors.Red)
                            .BorderColor(Colors.Blue)
                            .DescriptionStyle(labelStyle)
                            .ButtonTitle("Count")
                            .OnClicked(button =>
                            {
                                counter += 1;
                                label.Text = $"Counter {counter}";
                            }),

                        new VStack
                        {
                            new Label("This is a simple card view example"),
                            new Label("Second label")
                                .FontSize(20)
                                .TextColor(AppColors.Gray200)
                        }
                    }                    
                }
            }            
        };
    }
}