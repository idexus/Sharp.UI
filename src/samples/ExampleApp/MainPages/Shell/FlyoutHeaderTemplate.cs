namespace ExampleApp;

using CodeMarkup.Maui;

public class FlyoutHeaderTemplate : ContentView
{
	public FlyoutHeaderTemplate()
	{
		Content = new Grid
        {
            e => e
				.RowDefinitions(e => e.Absolute(150).Auto())
				.HeightRequest(200),

            new Image("dotnet_bot.png")
				.Opacity(0.6)
				.Aspect(Aspect.AspectFit),

			new Label(".NET Bot Menu")
				.Row(1)
				.FontAttributes(FontAttributes.Bold)
				.TextColor(AppColors.Gray400)
				.FontSize(24)
				.TextColor(Colors.White)
				.HorizontalTextAlignment(TextAlignment.Center)
				.VerticalTextAlignment(TextAlignment.Center)
		};
	}
}
