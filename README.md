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

public partial class HelloWorldPage : ContentPage 
{
    int count = 0; 

    public HelloWorldPage()
    {
        Content =

        new VStack(e => e
            .Spacing(25)
            .Padding(30, 0)
            .CenterVertically())
        {
            new Image("dotnet_bot.png", out var image)        
                .HeightRequest(280) 
                .CenterHorizontally(),

            new Label("Welcome to .NET Multi-platform App UI")
                .FontSize(e => e.Default(30).OnPhone(16))
                .CenterHorizontally(),

            new Button("Click me")
                .FontSize(20)
                .CenterHorizontally()
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
dotnet add package Sharp.UI --version 0.4.3-alpha
```

__Sharp.UI__ replaces some standard MAUI classes by subclassing them and adding new constructors, which e.g. enables hot reload functionality. However, if you prefer not to use subclassed controls, it's possible to add the core generated fluent methods for the .Net MAUI framework to your project instead.

```
dotnet add package Sharp.UI.Extensions --version 0.4.3-alpha
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

## Properties and Fluent Methods

`Sharp.UI` provides a convenient way to set properties for UI elements by matching properties with fluent helper methods. This makes it easier and more readable to define the interface of your application.

Here is an example of using fluent methods to set properties on a `Label`:

```cs
new Label()
    .Text("This is a test")
    .Padding(20)
    .FontSize(30)
```

Additionally, some common properties can be set directly as constructor arguments for even faster definition of the interface. Here is an example using a constructor argument to set the text property on a `Label`:

```cs
new Label("This is a test")
```

## Inline bindable property configuration

#### Property binding

One way to configure a bindable property inline is to use the `Path` method and additional extension methods to bind the property to a data source. For example:

```cs
new Label().FontSize(e => e.Path("MyFontSize"))
new Label().Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F1}"))
```

#### Idiom, Platform, and Theme

Another way to configure bindable properties inline is to set different values for different device idiom (phone or tablet), platform (WinUI or iOS), or theme (light or dark). For example:

```cs
new Label().FontSize(e => e.OnPhone(30).OnTablet(50).Default(40))
new Label().FontSize(e => e.OnWinUI(30).OniOS(50).Default(40))
new Label().TextColor(e => e.OnLight(Colors.Black).OnDark(Colors.White))
```

#### Dynamic resources

Another way to configure bindable properties inline is to use dynamic resources. Dynamic resources are resources whose values can change at runtime. For example:

```cs
Label().TextColor(e => e.DynamicResource("myColor"))
```

#### Mixing

Finally, it's also possible to mix these various configuration options to achieve more complex property configurations. For example:

```
new Label()
    .TextColor(e => e
        .OnLight(e => e.OnWinUI(Colors.Aqua).Default(Colors.LightCoral))
        .OnDark(Colors.White)
    )
```

## How to assign object references

There are two main ways to assign objects in `Sharp.UI`: 

```cs
new Label(out label)
```
Or:
```cs
new Label().Assign(out label)
```

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
        .CenterInContainer()),                

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

## Animations

In __Sharp.UI__, you can use async methods with the naming convention `Animate{PropertyName}To` to animate any `double` or `Color` bindable property.

For example, to animate the `BackgroundColor` property, you can use the `AnimateBackgroundColorTo` async method.

```cs
await border.AnimateBackgroundColorTo(Colors.Red, 500);  // 500ms
```

#### Example Usage

You can use animations inside event handlers. For example, to animate a `Button` when it's clicked:

```cs
new Button()
    .Text("Click me")
    .OnClicked(async (Button button) =>
    {
        count++;
        button.Text = $"Clicked {count} ";
        button.Text += count == 1 ? "time" : "times";

        _ = button.AnimateBackgroundColorTo(count % 1 == 0 ? Colors.Red : Colors.Blue, 500);
        await button.AnimateFontSizeTo(count % 1 == 0 ? Colors.Red : Colors.Blue);
        await button.RotateTo(360 * (count % 2), 300);
    })
```

You can also use visual states inside Style<T> to define animations. See the [documentation on Style\<T\>](./doc/styledefinition.md) for more information.

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
            new Label().Text(e => e.Path("Author"))
            new Label().Text(e => e.Path("Title"))
            new Button("Click Me")
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
- [Layout options extension methods](./doc/layoutoptions.md)
- [ITextAlignment interface extension methods](./doc/itextalignment.md)
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

# User defined extension methods

In __Sharp.UI__, you can create your own extension methods by defining a static method within a static class.

Here's an example of extension methods that set a label font size:

```cs
public static T FontSize<T>(this T self,
    double fontSize)
    where T : Microsoft.Maui.Controls.Label
{
    self.SetValueOrAddSetter(Microsoft.Maui.Controls.Label.FontSizeProperty, fontSize);
    return self;
}
        
public static T FontSize<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
    where T : Microsoft.Maui.Controls.Label
{
    var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.Label.FontSizeProperty);
    configure(context).Build();
    return self;
}
```

the first extension method allows you the following usage:

```cs
new Label().FontSize(28)
```

the second:

```cs
new Label().FontSize(e => e.Path("MyFontSize").Source(myModel))
new Label().FontSize(e => e.OnPhone(30).OnTablet(50).Default(40))
```

In the extension methods, it's important to use the `SetValueOrAddSetter` method instead of setting the properties directly. `SetValueOrAddSetter` sets the value of the property if the property is used in a standard context, such as in object creation, or add a new `Setter` when you use the method to create a setter for a style definition.

# Disclaimer

__Sharp.UI__ is a proof of concept. There is no official support. Use at your own risk.

# License 

[The MIT License](License.txt), Copyright (c) 2022 Pawel Krzywdzinski
