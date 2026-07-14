using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp
{
	using Sharp.UI;

    public partial class TestBindingsPage : ContentPage
	{
		ResourceDictionary localResources => new ResourceDictionary
		{
			new Style<Ellipse>(e => e.Fill(Colors.Red))
		};

        protected override View Build()
        {
            Resources = localResources;
			return new VStack
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
							rect.RotateToAsync(360, 2000);
							ellipse.RotateToAsync(360, 1000);
						}
						else
						{
							ellipse.RotateToAsync(0, 1000);
							rect.RotateToAsync(0, 2000);
						}
					})
			}
			.CenterHorizontally()
			.CenterVertically();
		}
	}
}