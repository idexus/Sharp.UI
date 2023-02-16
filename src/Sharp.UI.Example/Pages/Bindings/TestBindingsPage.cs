namespace ExampleApp;

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
			new Rectangle(200, 200, out var rect)
				.Stroke(Colors.Blue)
				.StrokeThickness(10)
				.Margin(50),

			new Ellipse(out var ellipse)
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
						rect.MauiObject.RotateTo(360, 2000);
						ellipse.MauiObject.RotateTo(360, 1000);
					}
					else
					{
						ellipse.MauiObject.RotateTo(0, 1000);
						rect.MauiObject.RotateTo(0, 2000);
					}
				})
		}
        .HorizontalOptions(LayoutOptions.Center)
        .VerticalOptions(LayoutOptions.Center);
	}
}