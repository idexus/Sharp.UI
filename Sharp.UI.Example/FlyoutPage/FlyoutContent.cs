namespace Sharp.UI.Example;

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
				.HeightRequest(new OnPlatform<double>(Default: 24, iOS: 22, WinUI: 16))
				.Margin(new OnPlatform<Thickness>(WinUI: new Thickness(12,0,12,0))),

			new Label()
				.GridColumn(1)
				.Text(e => e.Path("Title"))
				.FontSize(14)
				.FontAttributes(new OnTheme<FontAttributes>(light:FontAttributes.Bold))
				.HorizontalOptions(new OnPlatform<LayoutOptions>(Default: LayoutOptions.Center, WinUI: LayoutOptions.Start))
				.HorizontalTextAlignment(TextAlignment.Start)
				.VerticalTextAlignment(TextAlignment.Center)

		}
		.ColumnDefinitions(e => e.Absolute(50).Auto());
	}
}
