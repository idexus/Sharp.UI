using System;

namespace ExampleApp
{
    using CodeMarkup.Maui;

    public partial class SecondPage
	{
        ResourceDictionary pageResources => new ResourceDictionary
        {
            new Style<Label>(e => e
                .TextColor(AppColors.Gray400)
                .FontSize(40.0)
                .CenterHorizontally()
                .CenterVertically()
                .Margin(new Thickness(10,0))),

            new Style<Button>(e => e
                .TextColor(AppColors.Gray100)
                .WidthRequest(300)
                .BackgroundColor(AppColors.Gray950)
                .FontSize(40)),

            new Style<VStack>(e => e
                .CenterHorizontally()
                .CenterVertically()),

            new Style<HStack>(e => e
                .CenterHorizontally()
                .CenterVertically())            
        };
    }
}

