using System;
using System.Collections.ObjectModel;

namespace ExampleApp
{
    using Sharp.UI;

    public class StyleTestPage : ContentPage
    {
        ResourceDictionary localResources => new ResourceDictionary
        {
            new Style<RadioButton>(applyToDerivedTypes: true)
            {
                RadioButton.ControlTemplateProperty.Set(new ControlTemplate(typeof(RadioButtonTemplate)))
            },
            new Style<VStack>
            {
                VStack.VerticalOptionsProperty.Set(LayoutOptions.Center),
                VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center)
            },
            new Style<HStack>
            {
                HStack.VerticalOptionsProperty.Set(LayoutOptions.Center),
                HStack.HorizontalOptionsProperty.Set(LayoutOptions.Center)
            },
            new Style<Label>
            {
                Label.TextColorProperty.Set(Colors.Red),
                Label.FontSizeProperty.Set(30.0),
                Label.MarginProperty.Set(new Thickness(10,10)),
                Label.HorizontalOptionsProperty.Set(LayoutOptions.Center)
            },
        };

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

            //button.Style = new Style<Button>
            //{
            //    Button.FontSizeProperty.Set(50),
            //    Button.BackgroundColorProperty.Set(AppColors.Gray100)
            //};

            Content.Resources = localResources;
        }
    }
}
