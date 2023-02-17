namespace ExampleApp;

using System.Linq.Expressions;
using Sharp.UI;

public class DeviceIdiomPage : ContentPage
{

    ResourceDictionary pageResources => new ResourceDictionary
    {
        new Style<Label>
        {
            Label.TextColorProperty.Set().OnLight(Colors.Red).OnDark(Colors.Blue),
            Label.FontSizeProperty.Set(50.0),
            Label.HorizontalOptionsProperty.Set(LayoutOptions.Center),
            Label.VerticalOptionsProperty.Set(LayoutOptions.Center),
            Label.MarginProperty.Set(new Thickness(10,0)),
        },
        new Style<Image>
        {
            Image.HorizontalOptionsProperty.Set(LayoutOptions.Center),
            Image.HeightRequestProperty.Set(60),
        },
        new Style<VStack>
        {
            VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center),
            VStack.MarginProperty.Set(new Thickness(0,30,0,0))
        }
    };

    public DeviceIdiomPage()
	{        
        Content = new ContentView(out var contentView)
        {
            (DeviceIdiom.Current switch 
            {
                DeviceIdiom.Desktop =>
                    new VStack
                    {
                        new Label("Desktop version"),
                        new Image("dotnet_bot.png"),
                    },

                DeviceIdiom.Phone =>
                    new VStack
                    {
                        new Label("Phone version"),
                        new Image("dotnet_bot.png"),
                    },

                DeviceIdiom.Tablet =>
                    new VStack
                    {
                        new Label("Tablet version"),
                        new Label("This is a tablet version"),
                        new Label("No images...")
                    },

                _ => null

            })?
            .BackgroundColor(AppColors.Gray900)
            .Padding(20)
        }
        .Resources(pageResources);
	}
}
