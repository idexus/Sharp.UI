
# Overview

__Sharp.UI__ is a fluent API library for .NET MAUI that lets you describe your UI declaratively, directly in C# code. Instead of writing XML markup and switching between two languages, you stay in a single environment — with full IntelliSense support, refactoring, and static type checking at every stage of building your interface. __Sharp.UI__ doesn't try to replace MAUI, it just changes how you use it. This means you still use native controls, the layout mechanism, Shell, and the entire MAUI ecosystem, but you get a much more consistent and ergonomic API. With __Sharp.UI__, you can create interfaces without needing to use XAML. Additionally, the library includes hot reload support to make the development process faster and more efficient.

<img src="https://github.com/idexus/Sharp.UI/blob/net10/doc/assets/gallery.jpg?raw=true" width="800" border="0" />

## Project status

__Sharp.UI__ has been actively used in real production deployments since 2023. As with any open source project, it's worth testing in your own environment before a large-scale rollout — but this isn't an experiment looking for its first user. It's a library that keeps running systems operational every day.
What matters to me most is convincing the MAUI community to build UI purely in C# instead of XML — that's exactly why I made this library available to the community, one that I use in my own projects every day.

# Hello, World! Example

Here is an example of how you could create a simple "Hello, World!" page in __Sharp.UI__:

```cs
namespace ExampleApp;
using Sharp.UI;

public partial class HelloWorldPage : ContentPage 
{
    int count = 0; 

    protected override View Build()
    {
        return new VStack(e => e
            .Spacing(25)
            .Padding(30)
            .CenterVertically())
        {
            new Image("dotnet_bot.png", out var image)        
                .HeightRequest(280) 
                .CenterHorizontally(),

            new Label("Welcome to Sharp.UI fo .NET MAUI")
                .FontSize(e => e.OnPhone(16).Default(30))
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
# Using __Sharp.UI__

## Nuget Package

To add __Sharp.UI__ to your project, along with all its functionality, you can use:

- [https://www.nuget.org/packages/Sharp.UI](https://www.nuget.org/packages/Sharp.UI)

## Sharp.UI Template Project

A vanilla sample project using nuget package

[https://github.com/idexus/Sharp.UI-Template](https://github.com/idexus/Sharp.UI-Template)

## Project Reference

You can add the library to your project by adding a project reference to the Sharp.UI library. For more information, see the [Adding the Library by VS Project Reference](./doc/projectref.md) document.

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

The hot reload feature allows you to see changes to your UI in real-time without having to rebuild the entire application.

```cs
namespace ExampleApp;
using Sharp.UI;

public partial class HelloWorldPage : ContentPage 
{
    int count = 0; 

    protected override View Build()
    {
        // Your hot reloaded UI code here
    }
}
```

# Examples

Here are some examples showing how to use the __Sharp.UI__ library

## Properties and Fluent Methods

__Sharp.UI__ provides a convenient way to set properties for UI elements by matching properties with fluent helper methods. This makes it easier and more readable to define the interface of your application.

Here is an example of using fluent methods to set properties on a `Label`:

```cs
new Label()
    .Text("This is a test")
    .Padding(20)
    .FontSize(30)
```

#### Additionally

- Some common properties can be set directly as constructor arguments for even faster definition of the interface. Here is an example using a constructor argument to set the text property on a `Label`:

```cs
new Label("This is a test")
```

- All classes that implement the `ITextAlignment` interface get [additional methods](./doc/itextalignment.md), so you can write e.g.:

```cs
new Label().TextCenter()
new Entry().TextBottomStart()
```

- You can layout every view in their container using the [helper extension methods](./doc/layoutoptions.md)

```cs
new VStack
{
    new Label("Hello, World!").CenterHorizontally()
}
```

## Inline bindable property configuration

In C# user interfaces, it's often useful to configure the properties of UI elements inline, instead of setting them directly in XAML or code-behind.

#### Property binding

One way to configure a bindable property inline is to use the `Path` method and additional extension methods to bind the property to a data source. For example:

```cs
new Label().FontSize(e => e.Path("MyFontSize"))
new Label().Text(e => e.Path("Value").Source(slider).StringFormat("Value : {0:F1}"))
```

#### Idiom, Platform, and Theme

Another way to configure bindable properties inline is to set different values for different device idiom (phone, tablet, etc.), platform (WinUI, iOS, etc.), or theme (light or dark). For example:

```cs
new Label().FontSize(e => e.OnPhone(30).OnTablet(50).Default(40))
new Label().FontSize(e => e.OnWinUI(30).OniOS(50).Default(40))
new Label().TextColor(e => e.OnLight(Colors.Black).OnDark(Colors.White))
```

#### Dynamic resources

Another way to configure bindable properties inline is to use dynamic resources. Dynamic resources are resources whose values can change at runtime. For example:

```cs
Resources = new ResourceDictionary
{
    { "myColor", Colors.Yellow },
    ...
}
```
```cs 
Label().TextColor(e => e.DynamicResource("myColor"))
```

#### Mixing

Finally, it's also possible to mix these various configuration options to achieve more complex property configurations. For example:

```cs
new Label()
    .TextColor(e => e
        .OnLight(e => e.OnWinUI(Colors.Aqua).Default(Colors.LightCoral))
        .OnDark(Colors.Black)
    )
```

## How to assign object references

There are two main ways to assign objects in __Sharp.UI__: 

```cs
new Label(out label)
```
Or:
```cs
new Label().Assign(out label)
```

## Using fluent methods for styling

__Sharp.UI__ provides a way to define the styles of elements using the `Style<T>` class and extension methods. Here's an example of how you can define the styles for a `Label` and a `Button`:

```cs
Resources = new ResourceDictionary
{
    new Style<Label>(e => e
        .FontSize(35)
        .TextColor(AppColors.Gray200)
        .CenterInContainer()),                

    new Style<Button>(e => e
        .BackgroundColor(AppColors.Gray950)
        .Padding(20)
        .CornerRadius(10))
    {
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

        await button.RotateToAsync(360 * (count % 2), 300);
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
    ViewModel viewModel = new ViewModel();

    protected override View Build()
    { 
        BindingContext = viewModel;
        return new VStack
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
- [Property Bindings](./doc/propertybindings.md)
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

## Advanced

- [User defined extension methods](./doc/userdefinedmethods.md)
- [Creating custom controls](./doc/customcontentview.md)
- [Control template](./doc/autogenbindableproperties.md)

# Disclaimer

There is no official support. Use at your own risk.

# License 

[The MIT License](License.txt), Copyright (c) 2022 Pawel Krzywdzinski
