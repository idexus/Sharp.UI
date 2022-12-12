namespace Sharp.UI;

public class SwipeViewPage : ContentPage
{
	public SwipeViewPage()
	{
		Content = new VStack
		{
			new Image("dotnet_bot.png").SizeRequest(100,100),

			new SwipeView
			{
				//------ content -----
				new Grid
				{
					new Label("Swipe right")
						.HorizontalOptions(LayoutOptions.Center)
						.VerticalOptions(LayoutOptions.Center)
				}
                .HeightRequest(80)
                .BackgroundColor(Colors.LightGray)
			}
			.LeftItems(new SwipeItems
			{
				new SwipeItem()
					.Text("Favourite")
					.IconImageSource("dotnet_bot.png")
					.BackgroundColor(Colors.LightGray),

				new SwipeItem()
					.Text("Delete")
					.IconImageSource("dotnet_bot.png")
					.BackgroundColor(Colors.LightPink),
			}),

            new SwipeView
            {
				//------ content -----
				new Grid
                {
                    new Label("Swipe to answer")
                        .HorizontalOptions(LayoutOptions.Center)
                        .VerticalOptions(LayoutOptions.Center)
                }
                .HeightRequest(80)
                .BackgroundColor(Colors.Blue)
            }
            .LeftItems(new SwipeItems
            {
                new SwipeItemView
				{
					new StackLayout
					{
						new Entry("Enter answer")
							.HorizontalOptions(LayoutOptions.Center)
							.WidthRequest(200),
						new Label("Check")
							.FontAttributes(FontAttributes.Bold)
							.HorizontalOptions(LayoutOptions.Center)
                            .TextColor(Colors.White)
                    }
					.WidthRequest(300)
					.BackgroundColor(Colors.DarkBlue)
				}
            }),
        }
        .Margin(new Thickness(0, 30, 0, 0));
	}
}
