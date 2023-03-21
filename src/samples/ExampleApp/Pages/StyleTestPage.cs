using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using CodeMarkup.Maui;

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
            };

            Content.Resources = localResources;
        }
    }
}
