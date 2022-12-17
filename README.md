# Overview
Sharp.UI allows you to build a .NET Multi-platform App User Interface (.NET MAUI) declaratively in C# code using fluent methods, without the need for XAML. It is a wrapper library, mostly auto-generated.

## Hello, World!

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

## Before you start

- [Before you start](./doc/howtostart.md)

## Examples

Here are some examples showing how to use the Sharp.UI library

- [Properties and fluent methods](./doc/properties.md)
- [How to assign object references](./doc/assign.md)
- [Object containers](./doc/containers.md)
- [Property bindings](./doc/propertybindings.md)
- [Attached properties](./doc/attachedproperties.md)
- [Event handlers](./doc/eventhandlers.md)
- [Grid definition](./doc/griddefinition.md)
- [Absolute layout](./doc/absolutelayout.md)
- [Menu definition](./doc/menudefinition.md)
- [Gradient example](./doc/gradients.md)
- [Gesture recognizers](./doc/gesturerecognizers.md)
- [Application styling](./doc/styledefinition.md)
- [Triggers](./doc/triggers.md)
- [Behaviors](./doc/behaviors.md)
- [App theme, device idiom and platform templates](./doc/deftemplates.md)
- [Application shell](./doc/shellapplication.md)

## Automatic code generation

In `Sharp.UI` bindable properties and their fluent methods are generated automaically.

- [View, View-Model pattern](./doc/viewmodel.md)
- [Create Custom Controls](./doc/customcontentview.md)
- [Control template](./doc/autogenbindableproperties.md)


# License 

[MIT License](License.txt), Copyright 2022 Pawel Krzywdzinski
