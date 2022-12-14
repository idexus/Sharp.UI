namespace Sharp.UI.Example;

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
				.Column(1)
				.Text(e => e.Path("Title"))
				.FontSize(20)
				.FontAttributes(FontAttributes.Italic)
				.VerticalTextAlignment(TextAlignment.Center)
		}
		.ColumnDefinitions(e => e.Star(0.2).Star(0.8));
	}
}
