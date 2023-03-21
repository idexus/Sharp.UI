namespace ExampleApp;

using CodeMarkup.Maui;

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
				.Padding(new Thickness(50,0,0,0))
				.FontSize(20)
				.FontAttributes(FontAttributes.Italic)
				.VerticalTextAlignment(TextAlignment.Center)
		}
		.ColumnDefinitions(e => e.Absolute(30).Auto());
	}
}
