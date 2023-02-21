using Microsoft.Maui.Controls.Shapes;
using Path = Microsoft.Maui.Controls.Shapes.Path;

namespace ExampleApp
{
	using Sharp.UI;
	
	public class ShapesPage : ContentPage
	{
		public ShapesPage()
		{
			Resources = new ResourceDictionary
			{
				new Style<ContentView>(e => e
					.VerticalOptions(LayoutOptions.Center)
					.HorizontalOptions(LayoutOptions.Center))				
			};

			this.BackgroundColor(Colors.White);

			Content =
				new Grid(e => e
                    .BackgroundColor(Colors.Cyan)
                    .Padding(50)
                    .ColumnDefinitions(e => e.Star(count: 3))
                    .RowDefinitions(e => e.Star(count: 2)))
				{
                    new ContentView
					{
						new Polygon()                        
							.Fill(Colors.AliceBlue)
							.Stroke(Colors.Green)
							.StrokeThickness(5)
							.Points(
								new Point(40,10),
								new Point(70,80),
								new Point(10,50)
							)
					},
					
					new ContentView(e => e.Column(1))
					{
                        new Polygon()
							.Fill(Colors.Blue)
							.Stroke(Colors.Red)
							.StrokeThickness(3)
							.Scale(e => e.Default(1).OnPhone(0.5))
							.Points(
								new Point(0,48),
								new Point(0,144),
								new Point(96,150),
								new Point(100, 0),
								new Point(192, 0),
								new Point(192,96),
								new Point(50,96),
								new Point(48,192),
								new Point(150,200),
								new Point(144,48)
							)
					},

					new ContentView(e => e.Column(2))
					{
                        new Polyline()
							.Stroke(Colors.Red)
							.Points(
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
							)
					},

					new ContentView(e => e.Row(1))
					{
                        new Ellipse()
							.SizeRequest(60,180)
							.Fill(Colors.Yellow)
							.Stroke(Colors.Green)
							.StrokeThickness(4)
					},

					new ContentView(e => e.Row(1).Column(1))
					{
                        new Path()
                            .Stroke(Colors.Blue)
                            .Aspect(Stretch.Uniform)
                            .HorizontalOptions(LayoutOptions.Start)
                            .Data(new GeometryGroup
                            {
                                e => e.FillRule(FillRule.EvenOdd),

                                new EllipseGeometry(50, 50, new Point(75,75)),
								new EllipseGeometry(70, 70, new Point(75,75)),
								new EllipseGeometry(100, 100, new Point(75,75)),
								new EllipseGeometry(120, 120, new Point(75,75)),
							})										
					},

					new ContentView
					{
                        e => e.Row(1).Column(2),

                        new Path()
							.Stroke(Colors.Red)
                            .StrokeThickness(12)
                            .StrokeLineJoin(PenLineJoin.Round)
                            .Scale(e => e.Default(0.7).OnPhone(0.25))
							.Data(new PathGeometry()
								.Figures(

									// -- H --
									new PathFigure().StartPoint(0,0).Segments(new LineSegment(0, 100)),
									new PathFigure().StartPoint(0,50).Segments(new LineSegment(50,50)),
									new PathFigure().StartPoint(50,0).Segments(new LineSegment(50,100)),

									// -- E --
									new PathFigure()
										.StartPoint(125,0)
										.Segments(
											new BezierSegment()
												.Point1(new Point(60,-10))
												.Point2(new Point(60,60))
												.Point3(new Point(125,50)),

											new BezierSegment()
												.Point1(new Point(60,40))
												.Point2(new Point(60,110))
												.Point3(new Point(125,100))
										),

									// -- L --
									new PathFigure()
										.StartPoint(150, 0)
										.Segments(
											new LineSegment(150,100),
											new LineSegment(200,100)
										),

									// -- L --
									new PathFigure()
										.StartPoint(225, 0)
										.Segments(
											new LineSegment(225,100),
											new LineSegment(275,100)
										),

									// -- O --
									new PathFigure()
										.StartPoint(300,50)
										.Segments(
											new ArcSegment()
												.Size(new Size(25,50))
												.Point(new Point(300, 49.9))
												.IsLargeArc(true)
										)								
								)
							)											
					}					
				};
		}
	}
}
