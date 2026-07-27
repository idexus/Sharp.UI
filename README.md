# Sharp.UI

> Declarative C# UI for .NET MAUI — native controls, fluent APIs, and no XAML required.

**Sharp.UI** is a fluent API library for .NET MAUI that lets you describe user interfaces declaratively in C#.

You stay in one language and one toolchain, with IntelliSense, refactoring, and static type checking while building the interface. Sharp.UI does not replace .NET MAUI — it replaces the need to write XAML. You still use native MAUI controls, layouts, Shell, resources, bindings, styles, behaviors, triggers, and the rest of the MAUI ecosystem.

<img src="https://github.com/idexus/Sharp.UI/blob/main/doc/assets/screen.jpg?raw=true" width="800" border="0" alt="Sharp.UI gallery" />

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

## Example

The example uses standard MAUI controls such as Image, Label, and Button. Sharp.UI adds constructors, fluent configuration methods, and the declarative `Build()` workflow around them, replacing XAML with plain C#.

An error page receives `message` and `route` as Shell navigation parameters via `[QueryProperty]` — MAUI's built-in mechanism for injecting query parameters into page properties. These properties are generated as full `BindableProperty`s by Sharp.UI's `[BindableProperties]` attribute, so the page can bind to them declaratively. The UI itself (an icon, an error label, and a close button) is composed entirely in C#: the label binds its text directly to the `Message` property, and clicking the close button navigates back to whatever route was passed in via `BackRoute`.

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
    protected override void Build()
    {
        this.BindingContext = this;
        this.Title = "Error";

        Content = new VStack(e => e
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
                    await Shell.Current.GoToAsync(BackRoute);
                }),
        };
    }
}
```

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

    protected override void Build()
    {
        Content = new Label("Edit me and use Hot Reload");
    }
}
```

Otherwise, your class must be declared as `sealed partial`, since the source generator adds this call for you automatically.

```cs
namespace ExampleApp;

using Sharp.UI;

public sealed partial class HelloWorldPage : ContentPage
{
    protected override void Build()
    {
        Content = new Label("Edit me and use Hot Reload");
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

## Property Bindings

### Bindings

Bind a bindable property to a source by calling its fluent setter (e.g. `Text()`, `FontSize()`) with a lambda, then use `Path()` inside that lambda to point to the source property. Add `Source()` to bind to a specific object instead of the current `BindingContext`, and `StringFormat()` to format the displayed value.

```cs
new Label()
    .FontSize(e => e.Path("MyFontSize"))

new Label()
    .Text(e => e
        .Path("Value")
        .Source(slider)
        .StringFormat("Value: {0:F1}"))
```

The first example binds `FontSize` to the `MyFontSize` property of the page's `BindingContext`. The second binds `Text` directly to the `Value` property of a specific `slider` element, formatted as `"Value: {0:F1}"`.

## Multi-Bindings

Sometimes a target property needs to combine values from more than one source. Call `.Path()` more than once inside the same builder — each call opens a new sub-binding, and `Source()` / `StringFormat()` / `BindingMode()` / `Map()` apply to whichever `Path()` was opened last. Each sub-binding can also have its own `Map()`, which transforms that source's raw value before it reaches the final combining step — as with `slider1` below, whose raw `double` is mapped to a `bool` first. A trailing typed `Convert()` combines all collected values into the final result; its parameter types and count must match the values produced by each `Path()`, in order — either the source's raw type, or the output type of that `Path()`'s own `Map()` if one was set. Its return type is the type of the target property.

```cs
new VStack
{
    new Slider(out var slider1)
        .Minimum(1).Maximum(30),

    new Slider(out var slider2)
        .Minimum(1).Maximum(30),

    new Slider(out var slider3)
        .Minimum(1).Maximum(30),

    new Slider(out var slider4)
        .Minimum(1).Maximum(30),

    new Label()
        .Text(e => e
            .Path(nameof(Slider.Value)).Source(slider1).Map((double v) => v > 10)
            .Path(nameof(Slider.Value)).Source(slider2)
            .Path(nameof(Slider.Value)).Source(slider3)
            .Path(nameof(Slider.Value)).Source(slider4)
            .Convert((bool v1, double v2, double v3, double v4) =>
            {
                return $"{v1}, {v2:F2}, {v3:F2}, {v4:F2}";
            }))
}
```

Here, the `Label`'s text is recomputed automatically whenever any of the four sliders changes, since each `Path()` creates its own binding to that slider's `Value` property. `slider1`'s value is first mapped to a `bool` via its own `Map()`, so the final `Convert()` receives it as `v1: bool` while `v2`–`v4` arrive as the raw `double` values from their sliders.

For two-way scenarios, use `ConvertBack()` with a matching arity, returning a tuple in the same order as the `Path()` calls. If a `Path()` uses `Map()`, add a `MapBack()` on that same path so the value written back can be turned into the source type again. For a variable number of bindings (unknown arity), use `ConvertRaw()` instead of `Convert()`.
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

Sharp.UI provides generated asynchronous methods following the `Animate{PropertyName}ToAsync` naming convention for supported `double` and `Color` bindable properties (besides standard Maui animation methods like `RotateToAsync`).

```cs
await border.AnimateBackgroundColorToAsync(Colors.Red, 500);
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
        await button.AnimateBackgroundColorToAsync(Colors.Red, 500);
    });
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

    protected override void Build()
    {
        BindingContext = viewModel;
        Content = new VStack
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
