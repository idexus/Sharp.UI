using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public sealed partial class StyleTestPage : ContentPage
    {
        protected override void Build()
        {            
            this.Resources = localResources;
            Content = new VStack()
            {
                new HStack
                {
                    new RadioButton { new Image("dotnet_bot.png") },
                    new RadioButton { new Image("dotnet_bot.png") }.IsChecked(true),
                    new RadioButton { new Image("dotnet_bot.png") },
                },              
            };

        }
    }
}
