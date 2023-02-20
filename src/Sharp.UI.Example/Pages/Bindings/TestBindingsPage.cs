using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp
{
	using Sharp.UI;

	public class TestBindingsPage : ContentPage
	{
		ResourceDictionary localResources => new ResourceDictionary
		{
			new Style<Ellipse>
			{
				Ellipse.FillProperty.Set(Colors.Red),
			},
		};

		public TestBindingsPage()
		{
			Resources = localResources;
			Content = new VStack
		{
			new Rectangle()
				.SizeRequest(200,200)
				.Assign(out var rect)
				.Stroke(Colors.Blue)
				.StrokeThickness(10)
				.Margin(50),

			new Ellipse()
				.Assign(out var ellipse)
				.SizeRequest(300,100)
				.Rotation(e => e.Path("Rotation")
				.Source(rect))
				.Stroke(Colors.Blue)
				.Margin(30),

			new Button("Test it")
				.FontSize(30)
				.Margin(20)
				.OnClicked(e =>
				{
					if (rect.Rotation < 180)
					{
						rect.RotateTo(360, 2000);
						ellipse.RotateTo(360, 1000);
					}
					else
					{
						ellipse.RotateTo(0, 1000);
						rect.RotateTo(0, 2000);
					}
				})
		}
			.HorizontalOptions(LayoutOptions.Center)
			.VerticalOptions(LayoutOptions.Center);
		}
	}
}