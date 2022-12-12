namespace Sharp.UI.Example;

public class FlyoutHeaderTemplate : ContentView
{
	public FlyoutHeaderTemplate()
	{
		Content = new Grid
		{
			new Image("dotnet_bot.png")
				.Opacity(0.6)
				.Aspect(Aspect.AspectFit),

			new Label("Bot")
				.FontAttributes(FontAttributes.Bold)
				.FontSize(24)
				.TextColor(Colors.White)
				.HorizontalTextAlignment(TextAlignment.Center)
				.VerticalTextAlignment(TextAlignment.Center)
		}
		.HeightRequest(200);
	}
}
