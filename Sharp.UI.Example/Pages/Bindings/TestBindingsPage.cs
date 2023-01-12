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
			new Rectangle(500, 500, out var rect).Stroke(Colors.Blue).StrokeThickness(10),
			new Label(out var label).Text(e => e.Path("Rotation")).BindingContext(rect),
			new Ellipse(out var ellipse).SizeRequest(300,100).Rotation(e => e.Path("Rotation").Source(rect)).Stroke(Colors.Blue),
			new Button("Test it")
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