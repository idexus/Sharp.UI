namespace ExampleApp;

using Sharp.UI;

public partial class CardViewPage : ContentPage
{    
    public CardViewPage()
    {
        var labelStyle = new Style<Label>(e => e.TextColor(Colors.Blue).FontSize(21));

        this.Content = new ScrollView
        {
            e => e
                .Margin(new Thickness(0, 30, 0, 0))
                .BackgroundColor(Colors.Black),

            new VStack
            {
                e => e.CenterHorizontally(),

                new Label(out var label)
                    .CenterHorizontally()
                    .Text($"Counter {counter}")
                    .FontSize(30)
                    .Margin(40),

                new Slider(1,100, out var slider)
                    .Margin(30),

                new StackLayout
                {
                    e => e                        
                        .Orientation(e => e.OnPhone(StackOrientation.Vertical).Default(StackOrientation.Horizontal))
                        .CenterHorizontally(),

                    new CardView(out var cardNo1, e => e
                        .CardTitle(e => e.Path("Value").Source(slider).StringFormat("Value {0:F1}"))
                        .ButtonTitle("Play")
                        .CardDescription("Do you like it?")
                        .CardColor(AppColors.Gray950))
                    {
                        new Image("dotnet_bot.png")
                            .Aspect(Aspect.AspectFit),

                        e => e.OnClicked(e =>
                        {
                            cardNo1.CardDescription = "Let's play :)";
                        })
                    },

                    new CardView(out var cardView, e => e
                        .CardTitle("Title")
                        .CardDescription("Yes I do")
                        .CardColor(AppColors.Gray950)
                        .DescriptionStyle(labelStyle)
                        .ButtonTitle("Count"))
                    {
                        new VStack
                        {
                            new Label("This is a simple card view example"),
                            new Label("Second label")
                                .FontSize(20)
                                .TextColor(AppColors.Gray200)
                        },

                        e => e.OnClicked(button =>
                        {
                            counter += 1;
                            label.Text = $"Counter {counter}";
                        }),

                    }
                }
            }            
        };
    }
}