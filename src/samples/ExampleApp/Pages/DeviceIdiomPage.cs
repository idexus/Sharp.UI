namespace ExampleApp;

using System.Linq.Expressions;
using CodeMarkup.Maui;

public class DeviceIdiomPage : ContentPage
{

    ResourceDictionary pageResources => new ResourceDictionary
    {
        new Style<Label>(e => e
            .TextColor(e => e.OnLight(Colors.Red).OnDark(Colors.Blue))
            .FontSize(50.0)
            .CenterHorizontally()
            .CenterVertically()
            .Margin(new Thickness(10,0))),
        
        new Style<Image>(e => e
            .CenterHorizontally()
            .HeightRequest(60)),
        
        new Style<VStack>(e => e
            .CenterHorizontally()
            .Margin(new Thickness(0,30,0,0)))        
    };

    public DeviceIdiomPage()
	{        
        Content = new ContentView(out var contentView)
        {
            (Info.CurrentIdiom switch 
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
