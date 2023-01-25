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
                Label.TextColorProperty.Set().OnLight(Colors.Red).OnDark(Colors.Blue),
                Label.FontSizeProperty.Set(60.0),
                Label.HorizontalOptionsProperty.Set(LayoutOptions.Center),
                Label.VerticalOptionsProperty.Set(LayoutOptions.Center),
                Label.MarginProperty.Set(new Thickness(10,0)),
            },
            new Style<Button>
            {
                Button.TextColorProperty.Set(Colors.Blue),
                Button.WidthRequestProperty.Set(300)
            },
            new Style<VStack>
            {
                VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center),
                VStack.VerticalOptionsProperty.Set(LayoutOptions.Center)
            },
        };
    }
}

