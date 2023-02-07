namespace ExampleApp;

using Sharp.UI;

public class ShellItemTemplate : ContentView
{
	public ShellItemTemplate()
	{
		Content = new Grid
		{
			new Image()
				.Source(e => e.Path("FlyoutIcon"))
				.Margin(5)
				.HeightRequest(45),

			new Label()
				.Row(1)
				.Text(e => e.Path("Title"))
				.FontSize(20)
				.FontAttributes(FontAttributes.Italic)
				.VerticalTextAlignment(TextAlignment.Center)
		}
		.RowDefinitions(e => e.Star(0.2).Star(0.8));
	}
}
