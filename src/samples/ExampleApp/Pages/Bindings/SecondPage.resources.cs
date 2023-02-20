using System;

namespace ExampleApp
{
    using Sharp.UI;

    public partial class SecondPage
	{
        ResourceDictionary pageResources => new ResourceDictionary
        {
            new Style<Label>
            {
                Label.TextColorProperty.Set(AppColors.Gray400),
                Label.FontSizeProperty.Set(40.0),
                Label.HorizontalOptionsProperty.Set(LayoutOptions.Center),
                Label.VerticalOptionsProperty.Set(LayoutOptions.Center),
                Label.MarginProperty.Set(new Thickness(10,0)),
            },
            new Style<Button>
            {
                Button.TextColorProperty.Set(AppColors.Gray100),
                Button.WidthRequestProperty.Set(300),
                Button.BackgroundColorProperty.Set(AppColors.Gray950),
                Button.FontSizeProperty.Set(40)
            },
            new Style<VStack>
            {
                VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center),
                VStack.VerticalOptionsProperty.Set(LayoutOptions.Center)
            },
            new Style<HStack>
            {
                HStack.HorizontalOptionsProperty.Set(LayoutOptions.Center),
                HStack.VerticalOptionsProperty.Set(LayoutOptions.Center)
            },
        };
    }
}

