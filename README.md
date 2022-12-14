# Overview
__Sharp.UI__ allows you to build a .NET Multi-platform App User Interface (.NET MAUI) declaratively in C# code __using fluent methods__, without the need for XAML. It is a wrapper library, mostly auto-generated.

<a href="http://www.youtube.com/watch?feature=player_embedded&v=Bu7CDc8_hqw" target="_blank">
 <img src="http://img.youtube.com/vi/Bu7CDc8_hqw/mqdefault.jpg" alt="Watch the video" width="640" height="360" border="10" />
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

# Before you start

- [Before you start](./doc/howtostart.md)

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

# Hot Reload

[HotReloadTest](https://github.com/idexus/HotReloadTest) is a test project of working with the __Sharp.UI__ library using Visual Studio Code and [Reloadify3000](https://github.com/Clancey/Reloadify3000) library with [vscode-comet](https://github.com/Clancey/vscode-comet) plugin.

This is an alpha version.

Known limitations:

- Does not work for classes with automatically generated code, e.g. for classes with automatically generated bindable properties
- Does not work if you want to use the Sharp.UI library by project reference. Use nuget package.

# Auto-generated bindable properties

In __Sharp.UI__ bindable properties and their float helper methods are automatically generated. You just need to define the interface.

### View-model

```cs
[BindableProperties]
public interface IViewModelProperties
{
    public string Title { get; set; }
    public string Author { get; set; }
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
    ViewModel viewModel = new ViewModel();

    public ViewPage()
    {
        this.BindingContext = viewModel;

        this.Content = new VStack
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
