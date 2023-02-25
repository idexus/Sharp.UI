namespace Sharp.UI;

using Sharp.UI;

public class SwipeViewPage : ContentPage
{
	public SwipeViewPage()
	{
		Content = new VStack
		{
			new SwipeView
			{
				//------ content -----
				new Grid
				{
					new Label("Swipe right")
						.AlignCenterHorizontal()
						.AlignCenterVertical()
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
                        .AlignCenterHorizontal()
                        .AlignCenterVertical()
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
							.AlignCenterHorizontal()
							.WidthRequest(200),
						new Label("Check")
							.FontAttributes(FontAttributes.Bold)
							.AlignCenterHorizontal()
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
