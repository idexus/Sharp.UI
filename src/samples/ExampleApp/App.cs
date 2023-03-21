 
namespace ExampleApp;

using System.Net;
using Microsoft.Maui;
using CodeMarkup.Maui;

public partial class App : Application
{
    public App()
    {
        MainPage = new ContentPage(e => e.Resources(AppResources.Default))
        {
            new VStack(e => e.CenterVertically())
            {
                new Button("Single Page")
                    .Margin(10)
                    .WidthRequest(200)
                    .OnClicked(b =>
                    {
                        MainPage = ActivatorUtilities.GetServiceOrCreateInstance<TestPage>(Application.Services);
                    }),

                new Button("Flyout Application")
                    .Margin(10)
                    .WidthRequest(200)
                    .OnClicked(b =>
                    {
                        MainPage = ActivatorUtilities.GetServiceOrCreateInstance<FlyoutMainPage>(Application.Services);
                    }),

                new Button("Shell Application")
                    .Margin(10)
                    .WidthRequest(200)
                    .OnClicked(b =>
                    {
                        MainPage = new AppShell();
                    }),
            }
        };
    }
}