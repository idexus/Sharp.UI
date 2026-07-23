namespace ExampleApp;

using Sharp.UI;

public partial class FlyoutHeaderTemplate : ContentView
{
    public FlyoutHeaderTemplate()
    {
        this.Content = new Grid
        {
            e => e
				.RowDefinitions(e => e.Absolute(150).Auto())
				.HeightRequest(200),

            new Image("dotnet_bot.png")
				.Opacity(0.6)
				.Aspect(Aspect.AspectFit)
				.Margin(20),

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
