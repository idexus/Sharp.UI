 
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
            X = 100,  
            Y = 100  
        };

        return window;
    }
}