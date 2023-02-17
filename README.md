# Overview

Sharp.UI is a .NET Multi-platform App User Interface (MAUI) library that allows you to build user interfaces declaratively in C# code using fluent methods. You do not need to use XAML to create your interfaces. The library comes with Hot Reload Support, which means you can make changes to your UI in real-time and see the results without having to rebuild the entire application. The hot reload feature is supported in Visual Studio 2022 for both Windows and Mac using the [HotReloadKit library](https://github.com/idexus/HotReloadKit.git).

Sharp.UI is a wrapper library, mostly auto-generated, and it replaces the standard MAUI classes.

<a href="https://youtu.be/w5863t1E5tg" target="_blank">
 <img src="https://github.com/idexus/Sharp.UI/raw/main/doc/assets/ytscreen.jpg" alt="Hot Reload Support" width="640" border="0" />
</a>

# Hello, World! Example

Here is an example of how you could create a simple "Hello, World!" page in Sharp.UI:

```cs
namespace ExampleApp;
using Sharp.UI;

public class HelloWorldPage : ContentPage
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
        };
    }
}
```

# Using Sharp.UI

To use Sharp.UI in your projects, you need to include the `using Sharp.UI` statement inside your app namespace.

```cs
namespace ExampleApp;
using Sharp.UI;
```

Or:

```cs
namespace ExampleApp
{
    using Sharp.UI;
    ...
}
```

### Nuget Package

To add the Sharp.UI library to your project, run the following command:

```
dotnet add package Sharp.UI --version 0.3.1-alpha.1
```

You can also add the library to your project by adding a project reference to the Sharp.UI library. For more information, see the [Adding the Library by VS Project Reference](./doc/howtostart.md) document.

# Hot Reload

The hot reload feature allows you to see changes to your UI in real-time without having to rebuild the entire application. To use hot reload in Sharp.UI, you will need to use the [HotReloadKit](https://github.com/idexus/HotReloadKit.git) library. Visual Studio 2022 extensions for both Windows and Mac are available for download from the [HotReloadKit releases page](https://github.com/idexus/HotReloadKit/releases). Please note that this is a proof of concept and there is no official support. Use it at your own risk.

# Basic Examples

Here are some examples showing how to use the Sharp.UI library

- [Properties and fluent methods](./doc/properties.md)
- [Object references assignment](./doc/assign.md)
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
- [Application shell](./doc/shellapplication.md)

# Auto-generated code

__Sharp.UI__ library has a feature of automatically generating bindable properties and their fluent helper methods. To use this feature, you need to define the __view-model__ as follows:
 
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

And, in the __view__, the code will be:

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
There are also advanced scenarios that you can explore

- [Callbacks and default values](./doc/advbindablepoperties.md)
- [Attached properties generation](./doc/attachedpropertiesgeneration.md)

Custom controls can also be created using the auto-generated properties and event handler helper methods. The following links provide more information:

- [Creating custom controls](./doc/customcontentview.md)
- [Control template](./doc/autogenbindableproperties.md)

# Using this repository

This project uses submodules. You have to init them.

```
git submodule update --init --recursive
```

# Disclaimer

__Sharp.UI__ is a proof of concept. There is no official support. Use at your own risk.

# License 

[The MIT License](License.txt), Copyright (c) 2022 Pawel Krzywdzinski
