# Overview

__Sharp.UI__ is a library for the .NET Multi-platform App User Interface (MAUI) framework that enables you to build user interfaces declaratively in C# code using fluent methods. With __Sharp.UI__, you can create interfaces without needing to use XAML. Additionally, the library includes hot reload support to make the development process faster and more efficient. The hot reload feature is supported in Visual Studio 2022 for both Windows and Mac using the [HotReloadKit library](https://github.com/idexus/HotReloadKit.git).

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
        Content = new VStack(e => e
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

## Repository

This project uses submodules, which means that it depends on other external projects to function properly. To ensure that these dependencies are properly included, you'll need to initialize the submodules when you first clone the repository.

To do this, use the following command:

```
git submodule update --init --recursive
```

If you ever update your clone of the repository, you may need to update the submodules as well to ensure that you have the latest version of all dependencies. To do this, you can use the following command:

```
git submodule update --recursive
```

## Nuget Package

To add __Sharp.UI__ to your project, along with all its functionality, you can use the following command:

```
dotnet add package Sharp.UI --version 0.4.1-alpha
```

__Sharp.UI__ replaces some standard MAUI classes by subclassing them and adding new constructors, which e.g. enables hot reload functionality. However, if you prefer not to use subclassed controls, it's possible to add the core generated fluent methods for the .Net MAUI framework to your project instead.

```
dotnet add package Sharp.UI.Extensions --version 0.4.1-alpha
```
## Project Reference

You can also add the library to your project by adding a project reference to the Sharp.UI library. For more information, see the [Adding the Library by VS Project Reference](./doc/projectref.md) document.

## In Your Project

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

# Hot Reload

The hot reload feature allows you to see changes to your UI in real-time without having to rebuild the entire application. To use hot reload in __Sharp.UI__, you will need to use the [HotReloadKit](https://github.com/idexus/HotReloadKit.git) library and add `SharpUIApplication<App>(HotReloadSupport.IdeIPs)` extension method in your `MauiApp` builder.

```cs
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .SharpUIApplication<App>(HotReloadSupport.IdeIPs)   // to enable Hot Reload
        .UseMauiApp<App>()
        ...

    return builder.Build();
}
```

Visual Studio 2022 extensions for both Windows and Mac are available for download from the [HotReloadKit releases page](https://github.com/idexus/HotReloadKit/releases). Please note that this is a proof of concept and there is no official support. Use it at your own risk.

# Examples

Here are some examples showing how to use the __Sharp.UI__ library

## Property Bindings

__Sharp.UI__ provides a simple way to bind properties of an element to a source, so that when the source changes, the property changes as well. You can bind a property by using the fluent method e.g. `Text()`, `TextColor()` etc. and then using lambda call the method `Path()` to specify the property you want to bind to.


```cs
public class SimpleBindings : ContentPage
{
    public SimpleBindings()
    {
        this.Content = new VStack
        {
            new Slider(out var slider)
                .Minimum(1)
                .Maximum(20),

            new Label()
                .Text(e => e.Path("Value").Source(slider).StringFormat("Slider value: {0}"))
                .FontSize(28)
        };
    }
}
``` 

In this example, the text property of the label is bound to the `Value` property of a `Slider` element named `slider`. When the value of the slider changes, the text of the label will automatically update to reflect the new value.

You can also bind a property to an object that is not part of the visual tree. This is useful when you have a separate data source, such as a model or a view model, that you want to bind to a visual element.

## Using fluent methods for styling

__Sharp.UI__ provides a way to define the styles of elements using the `Style<T>` class and extension methods. Here's an example of how you can define the styles for a `Label` and a `Button`:

```cs
Resources = new ResourceDictionary
{
    new Style<Label>(e => e
        .FontSize(35)
        .TextColor(AppColors.Gray200)
        .HorizontalOptions(LayoutOptions.Center)
        .VerticalOptions(LayoutOptions.Center)),                

    new Style<Button>
    {
        e => e
            .BackgroundColor(AppColors.Gray950)
            .Padding(20)
            .CornerRadius(10),

        new VisualState<Button>(VisualStates.Button.Normal, e => e
            .FontSize(33)
            .TextColor(AppColors.Gray200)
            .SizeRequest(270,110)),

        new VisualState<Button>(VisualStates.Button.Disabled, e => e
            .FontSize(20)
            .TextColor(AppColors.Gray600)
            .SizeRequest(180,80))
    }
};
```

## Auto-generated code

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

            new Button("Test")
                .FontSize(100)
                .OnClicked(viewModel.SetAuthor)
        };
    }
}
```

## Other Examples

- [Properties and fluent methods](./doc/properties.md)
- [Object references assignment](./doc/assign.md)
- [Object containers](./doc/containers.md)
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
- [Callbacks and default values](./doc/advbindablepoperties.md)
- [Creating custom controls](./doc/customcontentview.md)
- [Control template](./doc/autogenbindableproperties.md)


# Disclaimer

__Sharp.UI__ is a proof of concept. There is no official support. Use at your own risk.

# License 

[The MIT License](License.txt), Copyright (c) 2022 Pawel Krzywdzinski
