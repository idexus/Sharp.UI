# Overview

Wrapper Library for .NET MAUI: Code-Only UI dev with Fluent Methods, Hot Reload and No XAML

# Hello, World!

```cs
namespace ExampleApp;
using Sharp.UI;

[SharpObject]
public partial class HelloWorldPage : ContentPage 
{
    int count = 0; 

    public HelloWorldPage()
	{
        Content = 
            new VStack(e => e
                .Spacing(25)
                .Padding(new Thickness(30, 0))
                .VerticalOptions(LayoutOptions.Center))
	        {
                new Image("dotnet_bot.png", out var image)        
			        .HeightRequest(280) 
			        .HorizontalOptions(LayoutOptions.Center),

		        new Label("Welcome to .NET Multi-platform App UI")
                    .FontSize(e => e.Default(30).OnPhone(16))
                    .HorizontalOptions(LayoutOptions.Center),

                new Button("Click me")
			        .HorizontalOptions(LayoutOptions.Center)
			        .FontSize(20)
			        .OnClicked(button =>
			        {
                        count++;
				        button.Text = $"Clicked {count} ";
                        button.Text += count == 1 ? "time" : "times";
                    })
	        }; 
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
