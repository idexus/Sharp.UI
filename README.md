# Overview
__Sharp.UI__ allows you to build a .NET Multi-platform App User Interface (.NET MAUI) 

- declaratively in C# code using fluent methods
- without the need for XAML
- with Hot Reload Support (VS2022 Win/Mac)

It is a wrapper library, mostly auto-generated.

<a href="http://www.youtube.com/watch?feature=player_embedded&v=r3Ri4VHYo7I" target="_blank">
 <img src="./doc/assets/output.gif" alt="Watch the video" width="640" height="360" border="0" />
</a>

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


# Using this repository

This project uses submodules. You have to init them.

```
git submodule update --init --recursive
```

# How to start

If you want to use this library in your projects, you need to include the `using Sharp.UI` inside your app namespace, which replaces the standard MAUI classes.

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

# Nuget Package

```
dotnet add package Sharp.UI --version 0.3.0-alpha.1
```

#### Project reference

- [Adding the library by VS project reference](./doc/howtostart.md)

# Hot Reload

You can use hot reload for content pages using [HotReloadKit](https://github.com/idexus/HotReloadKit.git)

- [mpack package for VS for Mac](https://github.com/idexus/HotReloadKit/releases)
- [vsix package for VS for Windows](https://github.com/idexus/HotReloadKit/releases)

#### Nuget package

```
dotnet add package HotReloadKit --version 0.4.0-beta.1
```

This is a proof of concept. There is no official support. Use at your own risk.

# Basic Examples

Here are some examples showing how to use the Sharp.UI library

- [Properties and fluent methods](./doc/properties.md)
- [How to assign object references](./doc/assign.md)
- [Object containers](./doc/containers.md)
- [Property bindings](./doc/propertybindings.md)
- [Binding converters](./doc/bindingconverters.md)
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

# Auto-generated bindable properties

In __Sharp.UI__ bindable properties and their float helper methods are automatically generated. You just need to define the interface.

### View-model

```cs
[BindableProperties]
public interface IViewModelProperties
{
    string Title { get; set; }
    string Author { get; set; }
}

[SharpObject]
public partial class ViewModel : BindableObject, IViewModelProperties
{
    public void SetAuthor(Button button)
    {
        this.Title = "Tosca";
        this.Author = "Puccini";
    }
}
```
### View

```cs
public class ViewPage : ContentPage
{
    ViewModel viewModel => BindingContext as ViewModel;

    public ViewPage(ViewModel viewModel)
    {
        BindingContext = viewModel;
       
        Content = new VStack
        {
            new HStack
            {
                new Label("author:"),
                new Label().Text(e => e.Path("Author"))
            },

            new HStack
            {
                new Label("title:"),
                new Label().Text(e => e.Path("Title"))
            },

            new Button("Test
                .FontSize(100)
                .OnClicked(viewModel.SetAuthor)
        };
    }
}
```
### Advanced scenarios

- [Callbacks, default values](./doc/advbindablepoperties.md)
- [Attached properties generation](./doc/attachedpropertiesgeneration.md)

# Custom controls

You can create custom controls using auto-generated properties and event handler helper methods.

- [Create custom controls](./doc/customcontentview.md)
- [Control template](./doc/autogenbindableproperties.md)

# Disclaimer

__Sharp.UI__ is a proof of concept. There is no official support. Use at your own risk.

# License 

[The MIT License](License.txt), Copyright (c) 2022 Pawel Krzywdzinski
