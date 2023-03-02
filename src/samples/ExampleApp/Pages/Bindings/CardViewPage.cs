namespace ExampleApp;

using Sharp.UI;

public partial class CardViewPage : ContentPage
{
    private readonly Label label;

    public CardViewPage()
    {
        var labelStyle = new Style<Label>(e => e.TextColor(AppColors.Gray300).FontSize(21));

        this.Content = 
            new ScrollView(e => e
                .Margin(top: Shell.Current != null ? 30 : 0)
                .BackgroundColor(Colors.Black)) {

                new VStack(e => e.Center())
                {
                    new Label(out label)
                        .CenterHorizontally()
                        .Text($"Counter Value : {counter}")
                        .FontSize(30)
                        .Margin(top: 20, bottom: 20),

                    new StackLayout(e => e
                        .Orientation(e => e.OnPhone(StackOrientation.Vertical).Default(StackOrientation.Horizontal))
                        .CenterHorizontally()) {

                        new CardView
                        {
                            new Grid(e => e.RowDefinitions(e => e.Star(2).Star()))
                            {
                                new Image("dotnet_bot.png")
                                    .Aspect(Aspect.AspectFit),
                                
                                new Slider(1,100, out var slider)
                                    .Row(1)
                                    .Margin(20,0),
                            },

                            e => e
                                .CardTitle(e => e.Path("Value").Source(slider).StringFormat("Value {0:F1}"))
                                .ButtonTitle("Play")
                                .CardDescription("Do you like it?")
                                .CardColor(AppColors.Gray950)
                                .OnClicked(e =>
                                {
                                    e.CardDescription = "Let's play :)";
                                })
                        },

                        new CardView(e => e
                            .CardTitle("Title")
                            .CardDescription("Subtitle")
                            .CardColor(AppColors.Gray950)
                            .DescriptionStyle(labelStyle)
                            .ButtonTitle("Count")) {

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
                    },
                }            
            };
    }
}