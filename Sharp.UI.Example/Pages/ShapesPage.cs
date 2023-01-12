using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp
{
	using Sharp.UI;
	
	public class ShapesPage : ContentPage
	{
		public ShapesPage()
		{
			Resources = new ResourceDictionary
			{
				new Style<ContentView>
				{
					ContentView.VerticalOptionsProperty.Set(LayoutOptions.Center),
					ContentView.HorizontalOptionsProperty.Set(LayoutOptions.Center)
				}
			};

			this.BackgroundColor(Colors.White);

			Content = new Grid
			{
				new ContentView
				{
					new Polygon
					{
						new Point(40,10),
						new Point(70,80),
						new Point(10,50)
					}
					.Fill(Colors.AliceBlue)
					.Stroke(Colors.Green)
					.StrokeThickness(5)
				},

				new ContentView(e => e.Column(1))
				{
					new Polygon
					{
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
					}
					.Fill(Colors.Blue)
					.Stroke(Colors.Red)
					.StrokeThickness(3)
				},

				new ContentView(e => e.Column(2))
				{
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
				},

				new ContentView(e => e.Row(1))
				{
					new Ellipse(100,80)
						.Fill(Colors.Yellow)
						.Stroke(Colors.Green)
						.StrokeThickness(4)
				},

				new ContentView(e => e.Row(1).Column(1))
				{
					new Path
					{
						new GeometryGroup
						{
							new EllipseGeometry(50, 50, new Point(75,75)),
							new EllipseGeometry(70, 70, new Point(75,75)),
							new EllipseGeometry(100, 100, new Point(75,75)),
							new EllipseGeometry(120, 120, new Point(75,75)),
						}
						.FillRule(FillRule.EvenOdd)
					}
					.Stroke(Colors.Blue)
					.Aspect(Stretch.Uniform)
					.HorizontalOptions(LayoutOptions.Start)
				},

                new ContentView(e => e.Row(1).Column(2))
				{
					new Path
					{
						new PathGeometry
						{
							// -- H --
							new PathFigure(0,0)	{ new LineSegment(0, 100) },
							new PathFigure(0,50) { new LineSegment(50,50) },
							new PathFigure(50,0) { new LineSegment(50,100) },

							// -- E --
							new PathFigure(125,0)
							{
								new BezierSegment()
									.Point1(new Point(60,-10))
									.Point2(new Point(60,60))
									.Point3(new Point(125,50)),

                                new BezierSegment()
                                    .Point1(new Point(60,40))
                                    .Point2(new Point(60,110))
                                    .Point3(new Point(125,100))
                            },

							// -- L --
							new PathFigure(150, 0)
							{
								new LineSegment(150,100),
								new LineSegment(200,100)
							},

							// -- L --
							new PathFigure(225, 0)
                            {
                                new LineSegment(225,100),
                                new LineSegment(275,100)
                            },

							// -- O --
							new PathFigure(300,50)
							{
								new ArcSegment()
									.Size(new Size(25,50))
									.Point(new Point(300, 49.9))
									.IsLargeArc(true)
							}
                        }
                    }
					.Stroke(Colors.Red)
					.StrokeThickness(12)
					.StrokeLineJoin(PenLineJoin.Round)
				}
            }
			.ColumnDefinitions(e => e.Star(1).Star(1).Star(1))
			.RowDefinitions(e => e.Star(1).Star(1));
		}
	}
}
