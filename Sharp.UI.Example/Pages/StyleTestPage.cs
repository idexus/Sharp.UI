using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public partial class StyleTestPage : ContentPage
    {
        public StyleTestPage()
        {
            Content = new VStack()
            {
                new HStack
                {
                    new RadioButton { new Image("dotnet_bot.png") },
                    new RadioButton { new Image("dotnet_bot.png") }.IsChecked(true),
                    new RadioButton { new Image("dotnet_bot.png") },
                },
                new Label("This is a test of style"),
                new Button("Test", out var button)
                    .Style(new Style<Button>
                    {
                        Button.FontSizeProperty.Set(50),
                        Button.BackgroundColorProperty.Set(AppColors.Gray100)
                    })
                    .OnClicked(e =>
                    {
                        e.IsEnabled = false;
                    })
            };

            Content.Resources = localResources;
        }
    }
}
