using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp;

using Sharp.UI;

[BindableProperties]
public interface IEmptyCardViewProperties
{
    string CardTitle { get; set; }
    string CardDescription { get; set; }
    Color CardColor { get; set; }
    Color BorderColor { get; set; }
}

[SharpObject]
public partial class EmptyCardView : ContentView, IEmptyCardViewProperties
{
}

public class CardViewTemplateView : ContentView
{
    public CardViewTemplateView()
    {
        Content = new Border
        {
            new VStack
            {
                new Label()
                    .Text(e => e.Path("CardTitle").Source(RelativeBindingSource.TemplatedParent))
                    .FontSize(44)
                    .TextColor(Colors.White),

                new Label()
                    .Text(e => e.Path("CardDescription").Source(RelativeBindingSource.TemplatedParent))
            }
        }
        .StrokeShape(new RoundRectangle().CornerRadius(10))
        .Stroke(e => e.Path("BorderColor").Source(RelativeBindingSource.TemplatedParent))
        .BackgroundColor(e => e.Path("CardColor").Source(RelativeBindingSource.TemplatedParent))
        .SizeRequest(200, 300)
        .Margin(20)
        .Padding(20);
    }
}

public class TemplatedParentPage : ContentPage
{    
    public TemplatedParentPage()
    {
        var controlTemplate = new ControlTemplate(typeof(CardViewTemplateView));

        this.Content = new ScrollView
        {
            //e => e.Margin(new Thickness(0,30,0,0)),

            new VStack
            {
                new Slider(1,100, out var slider)
                    .Margin(50),

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
            .VerticalOptions(LayoutOptions.Center)
        };
    }
}