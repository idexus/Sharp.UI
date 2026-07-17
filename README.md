# Sharp.UI

> Declarative C# UI for .NET MAUI — native controls, fluent APIs, and no XAML required.

**Sharp.UI** is a fluent API library for .NET MAUI that lets you describe user interfaces declaratively in C#.

You stay in one language and one toolchain, with IntelliSense, refactoring, and static type checking while building the interface. Sharp.UI does not replace .NET MAUI — it replaces the need to write XAML. You still use native MAUI controls, layouts, Shell, resources, bindings, styles, behaviors, triggers, and the rest of the MAUI ecosystem.

<img src="https://github.com/idexus/Sharp.UI/blob/net10/doc/assets/screen.jpg?raw=true" width="800" border="0" alt="Sharp.UI gallery" />

## Why Sharp.UI?

- Write the entire interface in C#
- Keep native .NET MAUI controls and APIs
- Use fluent, discoverable APIs with IntelliSense
- Refactor UI code with standard C# tooling
- Configure bindings, resources, themes, platforms, and device idioms inline
- Use Hot Reload without rebuilding the entire application
- Generate bindable properties and fluent helpers with source generators
- Avoid switching between XAML and C#

Everything you already know about .NET MAUI still applies. Sharp.UI changes how the interface is expressed, not how MAUI renders or runs it.

## Project status

Sharp.UI has been actively used in production deployments since 2023. It powers applications maintained by the author and continues to evolve alongside .NET MAUI.

The project is open source and maintained independently. Test it in your own environment before a large-scale rollout, as you would with any third-party framework. No commercial support or SLA is provided.

## Installation

### NuGet

```bash
dotnet add package Sharp.UI
```

Package page:

- [Sharp.UI on NuGet](https://www.nuget.org/packages/Sharp.UI)

### Starter template

A minimal sample project using the NuGet package:

- [Sharp.UI Template](https://github.com/idexus/Sharp.UI-Template)

### Project reference

You can also reference the Sharp.UI source project directly.

See [Adding the library by Visual Studio project reference](./doc/projectref.md).

## Hello, World!

```cs
namespace ExampleApp;

using Sharp.UI;

public sealed partial class HelloWorldPage : ContentPage
{
    private int count;

    protected override View Build()
    {
        return new VStack(e => e
            .Spacing(25)
            .Padding(30)
            .CenterVertically())
        {
            new Image("dotnet_bot.png")
                .HeightRequest(280)
                .CenterHorizontally(),

            new Label("Welcome to Sharp.UI for .NET MAUI")
                .FontSize(e => e
                    .OnPhone(16)
                    .Default(30))
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

The example uses regular MAUI controls such as `Image`, `Label`, and `Button`. Sharp.UI adds constructors, fluent methods, declarative configuration, and the `Build()` workflow around them.

## Sharp.UI and XAML

| XAML-based MAUI | Sharp.UI |
|---|---|
| UI in XML, behavior in C# | UI and behavior in C# |
| Frequent switching between files and languages | One language and one toolchain |
| Markup extensions and XML syntax | Fluent methods and C# lambdas |
| XAML-specific tooling | Standard C# IntelliSense and refactoring |
| Native MAUI controls | Native MAUI controls |
| MAUI resources, bindings, styles, Shell | The same MAUI concepts expressed in C# |

Sharp.UI is intended for developers who prefer C# as the primary language for both interface definition and application logic.

## Using Sharp.UI

Include the namespace in your project:

```cs
namespace ExampleApp;

using Sharp.UI;
```

Or use a block-scoped namespace:

```cs
namespace ExampleApp
{
    using Sharp.UI;

    // ...
}
```

## Hot Reload

Override `Build()` in a `ContentPage`. If you create a custom constructor, you must call `InitializeSharpUI()` yourself to initialize Sharp.UI content page.

```cs
namespace ExampleApp;

using Sharp.UI;

public class HelloWorldPage : ContentPage
{
    public HelloWorldPage()
    {
        InitializeSharpUI();
    }

    protected override View Build()
    {
        return new Label("Edit me and use Hot Reload");
    }
}
```

Otherwise, your class must be declared as `sealed partial`, since the source generator adds this call for you automatically.

```cs
namespace ExampleApp;

using Sharp.UI;

public sealed partial class HelloWorldPage : ContentPage
{
    protected override View Build()
    {
        return new Label("Edit me and use Hot Reload");
    }
}
```

Changes to the UI can be applied without rebuilding the entire application.

# Feature overview

## Properties and fluent methods

Sharp.UI matches MAUI properties with fluent helper methods:

```cs
new Label()
    .Text("This is a test")
    .Padding(20)
    .FontSize(30)
```

Common properties can also be passed directly to constructors:

```cs
new Label("This is a test")
```

Classes implementing `ITextAlignment` receive additional alignment helpers:

```cs
new Label().TextCenter()
new Entry().TextBottomStart()
```

See [text alignment helpers](./doc/itextalignment.md).

Views can be positioned inside their containers with layout helpers:

```cs
new VStack
{
    new Label("Hello, World!")
        .CenterHorizontally()
}
```

See [layout option helpers](./doc/layoutoptions.md).

## Inline bindable-property configuration

Bindable properties can be configured inline through a consistent C# API.

### Bindings

```cs
new Label()
    .FontSize(e => e.Path("MyFontSize"))

new Label()
    .Text(e => e
        .Path("Value")
        .Source(slider)
        .StringFormat("Value: {0:F1}"))
```

### Device idiom, platform, and theme

```cs
new Label()
    .FontSize(e => e
        .OnPhone(30)
        .OnTablet(50)
        .Default(40))

new Label()
    .FontSize(e => e
        .OnWinUI(30)
        .OniOS(50)
        .Default(40))

new Label()
    .TextColor(e => e
        .OnLight(Colors.Black)
        .OnDark(Colors.White))
```

These options can be combined:

```cs
new Label()
    .TextColor(e => e
        .OnLight(e => e
            .OnWinUI(Colors.Aqua)
            .Default(Colors.LightCoral))
        .OnDark(Colors.Black))
```

### Dynamic resources

```cs
Resources = new ResourceDictionary
{
    { "myColor", Colors.Yellow }
};
```

```cs
new Label()
    .TextColor(e => e.DynamicResource("myColor"))
```

## Object references

Sharp.UI provides two ways to capture object references:

```cs
new Label(out label)
```

Or:

```cs
new Label()
    .Assign(out label)
```

## Styles and visual states

Styles are defined with `Style<T>` and the same fluent methods used by views:

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
        new VisualState<Button>(
            VisualStates.Button.Normal,
            e => e
                .FontSize(33)
                .TextColor(AppColors.Gray200)
                .SizeRequest(270, 110)),

        new VisualState<Button>(
            VisualStates.Button.Disabled,
            e => e
                .FontSize(20)
                .TextColor(AppColors.Gray600)
                .SizeRequest(180, 80))
    }
};
```

## Animations

Sharp.UI provides generated asynchronous methods following the `Animate{PropertyName}To` naming convention for supported `double` and `Color` bindable properties.

```cs
await border.AnimateBackgroundColorTo(Colors.Red, 500);
```

Animations can be used directly inside event handlers:

```cs
new Button("Click me")
    .OnClicked(async button =>
    {
        count++;
        button.Text = $"Clicked {count} ";
        button.Text += count == 1 ? "time" : "times";

        await button.RotateToAsync(360 * (count % 2), 300);
    })
```

Visual states can also define animations. See [styles and visual states](./doc/styledefinition.md).

## Source-generated bindable properties

Sharp.UI can generate bindable properties and their fluent helper methods.

Define the property contract:

```cs
[BindableProperties]
public interface IViewModelProperties
{
    string Title { get; set; }
    string Author { get; set; }
}
```

Implement it in a partial `BindableObject`:

```cs
[SharpObject]
public partial class ViewModel : BindableObject, IViewModelProperties
{
    public void SetAuthor(Button button)
    {
        Title = "Tosca";
        Author = "Puccini";
    }
}
```

Use the generated properties from a view:

```cs
public class ViewPage : ContentPage
{
    private readonly ViewModel viewModel = new();

    protected override View Build()
    {
        BindingContext = viewModel;

        return new VStack
        {
            new Label()
                .Text(e => e.Path("Author")),

            new Label()
                .Text(e => e.Path("Title")),

            new Button("Click me")
                .FontSize(100)
                .OnClicked(viewModel.SetAuthor)
        };
    }
}
```

## BindableProperties with QueryProperties usage

An error page that receives message and route as Shell navigation parameters (via [QueryProperty]), automatically mapped to bindable properties thanks to Sharp.UI's generators, with the entire UI (icon + error text + close button) built purely in C# instead of XAML, and the text label bound directly to the Message property.

```cs
namespace Example;

using Sharp.UI;

[BindableProperties]
interface IErrorMessagePage
{
    string Message { get; set; }
    string BackRoute { get; set; }
}

[SharpObject]
[QueryProperty(nameof(Message), "message")]
[QueryProperty(nameof(BackRoute), "route")]
public sealed partial class ErrorMessagePage : ContentPage, IErrorMessagePage
{
    protected override View Build()
    {
        this.BindingContext = this;
        this.Title = "Error";

        return new VStack(e => e
            .Spacing(40)
            .Margin(bottom: 30)
            .CenterVertically())
        {
            new VStack(e => e.Spacing(5))
            {
                new Image("attention.png")
                    .CenterHorizontally()
                    .SizeRequest(100,100),

                new Label()
                    
                    .Text(e => e.Path(nameof(Message)))
                    .CenterHorizontally(),
            },

            new Button("Close")
                .SizeRequest(100,50)
                .CenterHorizontally()
                .OnClicked(async e =>
                {
                    await AppShell.Current.GoToAsync(BackRoute);
                }),
        };
    }
}
```

# Documentation

## Getting started

- [Properties and fluent methods](./doc/properties.md)
- [Property bindings](./doc/propertybindings.md)
- [Object reference assignment](./doc/assign.md)
- [Object containers](./doc/containers.md)
- [Layout option extension methods](./doc/layoutoptions.md)
- [Text alignment extension methods](./doc/itextalignment.md)
- [Binding converters](./doc/bindingconverters.md)
- [Event handlers](./doc/eventhandlers.md)
- [Grid definition](./doc/griddefinition.md)
- [Absolute layout](./doc/absolutelayout.md)

## UI composition and application features

- [Attached properties](./doc/attachedproperties.md)
- [Menu definition](./doc/menudefinition.md)
- [Gradients](./doc/gradients.md)
- [Gesture recognizers](./doc/gesturerecognizers.md)
- [Application styling and visual states](./doc/styledefinition.md)
- [Triggers](./doc/triggers.md)
- [Behaviors](./doc/behaviors.md)
- [Application Shell](./doc/shellapplication.md)

## Advanced

- [Callbacks and default values](./doc/advbindablepoperties.md)
- [User-defined extension methods](./doc/userdefinedmethods.md)
- [Creating custom controls](./doc/customcontentview.md)
- [Control templates and generated bindable properties](./doc/autogenbindableproperties.md)

# Support

Sharp.UI is maintained as an open-source project by its author. Community feedback is welcome, but this project comes with no commercial support or service-level agreement (SLA).

# License

[MIT License](License.txt) — Copyright © 2022 Pawel Krzywdzinski
