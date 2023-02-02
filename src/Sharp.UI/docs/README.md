# Overview
An auto-generated wrapper library that allows you to use .NET MAUI only in C# code using fluent methods, without the need for XAML.

# Hello, World!

```cs
namespace ExampleApp;
using Sharp.UI;

public class HelloWorldPage : ContentPage
{
    int count = 0;

    public HelloWorldPage()
    {
        Content = new VStack
        {
            new Image("dotnet_bot.png")
                .HeightRequest(200)
                .HorizontalOptions(LayoutOptions.Center),

            new Label("Hello, World!")
                .FontSize(32)
                .HorizontalOptions(LayoutOptions.Center),

            new Label("Welcome to .NET Multi-platform App UI")
                .FontSize(18)
                .HorizontalOptions(LayoutOptions.Center),

            new Button("Click me")
                .HorizontalOptions(LayoutOptions.Center)
                .OnClicked(button =>
                {
                    count++;
                    button.Text = $"Clicked {count} ";
                    button.Text += count == 1 ? "time" : "times";
                })
        }
        .Spacing(25)
        .Padding(new Thickness(30, 0))
        .VerticalOptions(LayoutOptions.Center);
    }
}
```

# Before you start
If you want to use this library, you have to include the `using Sharp.UI` inside your app namespace, which replaces the standard MAUI classes.

```cs
namespace ExampleApp;
using Sharp.UI;
```

```cs
namespace ExampleApp
{
    using Sharp.UI;
    ...
}
```

# License 

[MIT License](../../License.txt), Copyright 2022 Pawel Krzywdzinski
