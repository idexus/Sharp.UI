namespace ExampleApp;

using Sharp.UI;

public class FlyoutContent : ContentView
{
	public FlyoutContent()
	{
		Content = new Grid
		{
			new Image()
				.Source(e => e.Path("Icon"))
				.VerticalOptions(LayoutOptions.Center)
				.HorizontalOptions(LayoutOptions.Center)
				.HeightRequest(e => e.Default(24).OniOS(22).OnWinUI(16)),

			new Label()
				.Column(1)
				.Text(e => e.Path("Title"))
				.FontSize(14)
				.HorizontalTextAlignment(TextAlignment.Start)
				.VerticalTextAlignment(TextAlignment.Center)

		}
		.ColumnDefinitions(e => e.Absolute(50).Auto());
	}
}
