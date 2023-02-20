using Microsoft.Maui.Controls.Shapes;
using Path = Microsoft.Maui.Controls.Shapes.Path;

namespace ExampleApp
{
    using Sharp.UI;

    public class PathPage : ContentPage
    {
        public PathPage()
        {
            Content =
                new ScrollView
                {
                    e => e.Margin(new Thickness(0, 30, 0, 0)),

                    new VStack(out var vstack)
                    {
                        new Path()
                            .Fill(Colors.Blue)
                            .Stroke(Colors.Red)
                            .WidthRequest(200).HeightRequest(200)
                            .Data(new EllipseGeometry()
                                .Center(new Point(100,100))
                                .RadiusX(100)
                                .RadiusY(50)),

                        new Path()
                            .Stroke(Colors.White)
                            .StrokeThickness(5)
                            .HorizontalOptions(LayoutOptions.Center)
                            .Data(new RectangleGeometry(0,0,200,100)),

                        new Image("dotnet_bot.png")
                            .WidthRequest(300)
                            .HeightRequest(300)
                            .Clip(new EllipseGeometry().RadiusX(80).RadiusY(80).Center(new Point(140, 120))),

                        new Path()
                            .WidthRequest(200).HeightRequest(200)
                            .Stroke(Colors.Red)
                            .Data(new GeometryGroup
                            {
                                new RectangleGeometry().Rect(new Rect(0,0,170,100)),

                                new LineGeometry()
                                    .StartPoint(new Point(0,0))
                                    .EndPoint(new Point(170,100))
                            }),

                        new Path()
                            .Stroke(Colors.Yellow)
                            .Fill(Colors.Red)
                            .HorizontalOptions(LayoutOptions.Center)
                            .Data(new GeometryGroup
                            {
                                new PathGeometry()
                                    .Figures(
                                        new PathFigure()
                                            .StartPoint(new Point(15, 50))
                                            .Segments(
                                                new LineSegment(100,100),
                                                new LineSegment(200,50)
                                            )
                                    ),

                                new EllipseGeometry()
                                    .Center(new Point(50,70))
                                    .RadiusX(10)
                                    .RadiusY(50)
                            })
                    }            
                };
        }
    }
}