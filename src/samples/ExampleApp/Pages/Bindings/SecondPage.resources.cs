using System;

namespace ExampleApp
{
    using Sharp.UI;

    public partial class SecondPage
	{
        ResourceDictionary pageResources => new ResourceDictionary
        {
            new Style<Label>(e => e
                .TextColor(AppColors.Gray400)
                .FontSize(40.0)
                .HorizontalOptions(LayoutOptions.Center)
                .VerticalOptions(LayoutOptions.Center)
                .Margin(new Thickness(10,0))),

            new Style<Button>(e => e
                .TextColor(AppColors.Gray100)
                .WidthRequest(300)
                .BackgroundColor(AppColors.Gray950)
                .FontSize(40)),

            new Style<VStack>(e => e
                .HorizontalOptions(LayoutOptions.Center)
                .VerticalOptions(LayoutOptions.Center)),

            new Style<HStack>(e => e
                .HorizontalOptions(LayoutOptions.Center)
                .VerticalOptions(LayoutOptions.Center))            
        };
    }
}

