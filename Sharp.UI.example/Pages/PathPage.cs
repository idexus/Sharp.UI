
namespace Sharp.UI.Example
{
    public class PathPage : ContentPage
    {
        public PathPage()
        {
            Content = new ContentView {
                new ScrollView {
                    new VStack(out var vstack)
                    {
                        new Path()
                        {
                            new EllipseGeometry()
                                .Center(new Point(100,100))
                                .RadiusX(100)
                                .RadiusY(50)
                        }
                        .Fill(Colors.Blue)
                        .Stroke(Colors.Red)
                        .WidthRequest(200).HeightRequest(200),

                        new Image("dotnet_bot.png")
                            .WidthRequest(300)
                            .HeightRequest(300)
                            .Clip(new EllipseGeometry().RadiusX(100).RadiusY(100).Center(new Point(150, 150))),

                        new Path()
                            .WidthRequest(200).HeightRequest(200)
                            .Stroke(Colors.Red)
                            .Data(new GeometryGroup
                            {
                                new EllipseGeometry()
                                    .Center(new Point(50,70))
                                    .RadiusX(10)
                                    .RadiusY(50),

                                new RectangleGeometry().Rect(new Rect(30,10,170,100)),

                                new LineGeometry()
                                    .StartPoint(new Point(30,30))
                                    .EndPoint(new Point(170,170))
                            }),

                        new Path
                        {
                            new GeometryGroup
                            {
                                new PathGeometry
                                {
                                    new PathFigure(15, 50)
                                    {
                                        new LineSegment(800,150),
                                        new LineSegment(500,50)
                                    }
                                },

                                new EllipseGeometry()
                                    .Center(new Point(50,70))
                                    .RadiusX(10)
                                    .RadiusY(50),
                            }
                        }
                        .Stroke(Colors.Yellow)
                        .Fill(Colors.Red),

                        new Path()
                            .Stroke(Colors.White)
                            .StrokeThickness(5)
                            .WidthRequest(200).HeightRequest(200)
                            .Data(new RectangleGeometry(30,10,170,100)),
                    }
                }
            }
            .Margin(new Thickness(0, 30, 0, 0));
        }
    }
}