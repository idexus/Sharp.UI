using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public partial class StyleTestPage : ContentPage
    {
        protected override View Build()
        {
            this.Resources = localResources;

            return new VStack()
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
