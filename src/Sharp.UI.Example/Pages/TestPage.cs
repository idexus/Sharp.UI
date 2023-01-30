using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp
{
    using Sharp.UI;

    public class TestPage : ContentPage
    {
        public class GraphicsDrawable : IDrawable
        {
            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                canvas.StrokeColor = Colors.Red;
                canvas.StrokeSize = 4;
                canvas.StrokeDashPattern = new float[] { 2, 2 };
                canvas.DrawLine(10, 10, 90, 100);
            }
        }

        List<string> data = new List<string>
        {
            "paul", "julian", "luciano"
        };

        private readonly Label label2;
        private readonly Label label3;

        public TestPage()
        {
            Title = "Test Page";

            Content =  new ScrollView {
                new VStack(out var vstack, e => e.WidthRequest(400).BackgroundColor(AppColors.Gray900))                        
                {
                    new ActivityIndicator()
                        .IsRunning(true)
                        .Color(Colors.Blue),

                    new Border
                    {
                        new Label("This is a test", out var label)
                            .Padding(20)
                            .FontSize(30)
                            .HorizontalOptions(LayoutOptions.Center)
                            .VerticalOptions(LayoutOptions.Center)
                    }
                    .Background(new LinearGradientBrush(new Point(0,0), new Point(1,1))
                    {
                        new GradientStop(Colors.Yellow, 0.0),
                        new GradientStop(Colors.Red, 0.25),
                        new GradientStop(Colors.Blue, 0.75),
                        new GradientStop(Colors.LimeGreen, 1.0)
                    })
                    .SizeRequest(300,150)
                    .Stroke(Colors.Blue)
                    .StrokeThickness(4)
                    .StrokeShape(new RoundRectangle().CornerRadius(40)),

                    new CheckBox(out var checkBox),

                    new DatePicker()
                        .HorizontalOptions(LayoutOptions.Center),

                    new ScrollView
                    {
                        new CardView 
                        {
                            new Image("dotnet_bot.png")
                                .Aspect(Aspect.AspectFit)
                        }
                        .CardTitle("My Card")
                        .ButtonTitle("Play")
                        .CardDescription("Do you like it?")
                        .CardColor(Colors.Blue)
                        .BorderColor(Colors.Red)
                        .OnClicked(e =>
                        {
                            e.CardDescription = "Let's play :)";
                        }),
                    },

                    new Editor("Enter text")
                        .HeightRequest(100),

                    new ContentView(out var contentView)
                    {
                        new Ellipse(100, 50)
                            .Fill(Colors.Red)
                    },

                    new VStack
                    {
                        new Label("Hello,")
                            .FontSize(40),
                        new Label("World!"),
                        new Ellipse()
                            .WidthRequest(100)
                            .HeightRequest(40)
                    },

                    new Entry("Enter text", out var entry),

                    new Frame()
                    {
                        new Label("TEST")
                            .FontSize(50)
                            .HorizontalOptions(LayoutOptions.Center)
                    }
                    .BorderColor(Colors.Blue)
                    .CornerRadius(20)
                    .Margin(20)
                    .SizeRequest(400,100),

                    new Label().Text(e => e.Path("Text").Source(entry)),

                    new GraphicsView(new GraphicsDrawable())
                        .HeightRequest(100)
                        .WidthRequest(100),

                    new Image("dotnet_bot.png")
                        .WidthRequest(200)
                        .HeightRequest(200),

                    new ImageButton("dotnet_bot.png")
                        .WidthRequest(100)
                        .HeightRequest(100)
                        .OnClicked(e =>
                        {
                            entry.Text = "I wiil do it";

                            contentView.Content = new HStack {

                                new Label("Exchange is working")
                                    .FontSize(50),

                                new Label("...hehe")
                                    .FontSize(30)

                            }
                            .HorizontalOptions(LayoutOptions.Center);

                            checkBox.IsChecked = true;
                            label.TextColor = Colors.Blue;
                        }),

                    new IndicatorView()
                        .IndicatorColor(Colors.Red)
                        .SelectedIndicatorColor(Colors.Blue)
                        .Margin(20)
                        .Count(10)
                        .HorizontalOptions(LayoutOptions.Center),

                    new IndicatorView()
                        .Margin(20)
                        .IndicatorColor(Colors.Red)
                        .SelectedIndicatorColor(Colors.Blue)
                        .Count(10)
                        .HorizontalOptions(LayoutOptions.Center)
                        .IndicatorTemplate(new DataTemplate(() => new Label("X").FontSize(20))),

                    new Label("This is a test", out label2)
                        .FontSize(30)
                        .HorizontalOptions(LayoutOptions.Center),

                    new Line(40, 0, 0, 120)
                        .StrokeThickness(4)
                        .Stroke(Colors.Blue)
                        .StrokeDashArray(new DoubleCollection {2,3})
                        .StrokeDashOffset(4)
                        .HorizontalOptions(LayoutOptions.Center),

                    new Picker("Select person")
                        .ItemsSource(data)
                        .OnSelectedIndexChanged(OnChanged),

                    new Polygon
                    {
                        new Point(40,10),
                        new Point(70,80),
                        new Point(10,50)
                    }
                    .Fill(Colors.AliceBlue)
                    .Stroke(Colors.Green)
                    .StrokeThickness(5),

                    new Polyline
                    {
                        new Point(0,0),
                        new Point(10,30),
                        new Point(15,0),
                        new Point(18,60),
                        new Point(23,30),
                        new Point(35,30),
                        new Point(40,0),
                        new Point(43,60),
                        new Point(48,30),
                        new Point(100,30)
                    }
                    .Stroke(Colors.Red),

                    new ProgressBar(0.5)
                        .ProgressColor(Colors.BlueViolet),

                    new StackLayout()
                    {
                        new Label("What's your favorite animal?"),
                        new RadioButton { "Dog" },
                        new RadioButton(e => e.IsChecked(true))
                        {
                            new HStack(e => e.HorizontalOptions(LayoutOptions.Start))
                            {
                                new Image("dotnet_bot.png")
                                    .SizeRequest(50,50),
                                        
                                new Label("Robot animal")
                                    .VerticalOptions(LayoutOptions.Center)
                                    .TextColor(Colors.Yellow)
                                    .FontSize(18)
                            }
                        },
                        new RadioButton { "Elephant" },
                        new RadioButton { "Monkey" },
                    },

                    new Rectangle(100, 100, out var rect).Stroke(Colors.Wheat).StrokeThickness(10),

                    new RoundRectangle(100, 100, 10).Stroke(Colors.Pink).StrokeThickness(10),

                    new Label("Wait...", out label3).FontSize(30).TextColor(Colors.Violet),
                    new SearchBar("Search...").OnTextChanged(OnSearch),

                    new HStack
                    {                            
                        new Stepper(minimum: 10, maximum: 20, increment: 1).Assign(out var stepper),
                        new Label()
                            .Text(e => e.Path("Value").Source(stepper))
                            .FontSize(30)
                    }
                    .BackgroundColor(AppColors.Gray900)
                    .Padding(20)
                    ,

                    new Switch(),

                    new TimePicker(),

                    new WebView("https://learn.microsoft.com/dotnet/maui").SizeRequest(500, 500)                            
                }
            }
            .Margin(new Thickness(0, 30, 0, 0));
        }

        private void OnSearch(SearchBar sender)
        {
            label3.Text = sender.Text;
        }

        private void Refreshing(RefreshView sender)
        {
            sender.IsRefreshing = false;
        }

        private void OnChanged(Picker sender)
        {
            label2.Text = sender.SelectedIndex.ToString();
        }
    }
}
