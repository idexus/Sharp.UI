# Overview
Sharp.UI allows you to build a .NET Multi-platform App User Interface (.NET MAUI) declaratively in C# code using fluent methods, without the need for XAML. It is a wrapper library, mostly auto-generated.

## Hello, World!

With Sharp.UI you can do this

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

Instead of that

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="TestApp.HelloWorldPage">

    <ScrollView>
        <VerticalStackLayout
            Spacing="25"
            Padding="30,0"
            VerticalOptions="Center">

            <Image
                Source="dotnet_bot.png"
                SemanticProperties.Description="Cute dot net bot waving hi to you!"
                HeightRequest="200"
                HorizontalOptions="Center" />

            <Label
                Text="Hello, World!"
                SemanticProperties.HeadingLevel="Level1"
                FontSize="32"
                HorizontalOptions="Center" />

            <Label
                Text="Welcome to .NET Multi-platform App UI"
                SemanticProperties.HeadingLevel="Level2"
                SemanticProperties.Description="Welcome to dot net Multi platform App U I"
                FontSize="18"
                HorizontalOptions="Center" />

            <Button
                x:Name="CounterBtn"
                Text="Click me"
                SemanticProperties.Hint="Counts the number of times you click"
                Clicked="OnCounterClicked"
                HorizontalOptions="Center" />

        </VerticalStackLayout>
    </ScrollView>
</ContentPage>
```

```cs
public partial class HelloWorldPage : ContentPage
{
    int count = 0;

    public HelloWorldPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";
    }
}
```

## How to start

- [How to start](./doc/howtostart.md)

# Examples
Here are some simple examples showing how to use the Sharp.UI library

- [Properties and fluent methods](./doc/properties.md)
- [How to assign object references](./doc/assign.md)
- [Object containers](./doc/containers.md)
- [Property bindings](./doc/propertybindings)
- [Attached properties](./doc/attachedproperties.md)
- [Event handlers](./doc/eventhandlers.md)
- [Grid definition](./doc/griddefinition.md)
- [Menu definition](./doc/menudefinition.md)
- [Gradient example](./doc/gradients.md)
- [Gesture recognizers](./doc/gesturerecognizers.md)
- [Style definition](./doc/styledefinition.md)
- [Triggers](./doc/triggers.md)
- [Behaviors](./doc/behaviors.md)
- [`Def<T>` Templates](./doc/deftemplates.md)
- [Shell application](./doc/shellapplication.md)
- [Auto-generated Bindable Properties](./doc/autogenbindableproperties.md)
- [Custom ContentView](./doc/customcontentview.md)


# License 

[MIT License](License.txt), Copyright 2022 Pawel Krzywdzinski
