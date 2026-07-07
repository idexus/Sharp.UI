 
namespace ExampleApp;

using System.Net;
using Microsoft.Maui;
using Sharp.UI;

public partial class App : Application
{
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = new Window(new AppShell())
        {
            Title = "Moja Aplikacja",
            Width = 1200,
            Height = 800,
            MinimumWidth = 600,
            MinimumHeight = 400,
            X = 100,  // pozycja od lewej
            Y = 100   // pozycja od góry
        };

        return window;
    }

    // public App()
    // {
    //     MainPage = new ContentPage(e => e.Resources(AppResources.Default))
    //     {
    //         new VStack(e => e.CenterVertically())
    //         {
    //             new Button("Single Page")
    //                 .Margin(10)
    //                 .WidthRequest(200)
    //                 .OnClicked(b =>
    //                 {
    //                     MainPage = ActivatorUtilities.GetServiceOrCreateInstance<TestPage>(Application.Services);
    //                 }),

    //             new Button("Flyout Application")
    //                 .Margin(10)
    //                 .WidthRequest(200)
    //                 .OnClicked(b =>
    //                 {
    //                     MainPage = ActivatorUtilities.GetServiceOrCreateInstance<FlyoutMainPage>(Application.Services);
    //                 }),

    //             new Button("Shell Application")
    //                 .Margin(10)
    //                 .WidthRequest(200)
    //                 .OnClicked(b =>
    //                 {
    //                     MainPage = new AppShell();
    //                 }),
    //         }
    //     };
    // }
}