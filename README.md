# Overview
Sharp.UI allows you to build a .NET Multi-platform App User Interface (.NET MAUI) declaratively in code using fluent methods. It is a wrapper library, mostly auto-generated.

## Hello, World!

```cs
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
                .OnClicked(OnCounterClicked)
        }
        .Spacing(25)
        .Padding(new Thickness(30, 0))
        .VerticalOptions(LayoutOptions.Center);
    }

    private void OnCounterClicked(Button sender)
    {
        count++;

        if (count == 1)
            sender.Text = $"Clicked {count} time";
        else
            sender.Text = $"Clicked {count} times";
    }
}
```

## Before you start
If you want to use this library, you must copy the `GlobalUsings.cs` file, which replaces the standard MAUI classes, into your project.

```cs
...
global using Label = Sharp.UI.Label;
global using ListView = Sharp.UI.ListView;
....
....
global using ScrollView = Sharp.UI.ScrollView;
global using SearchBar = Sharp.UI.SearchBar;
global using Slider = Sharp.UI.Slider;
...
```
# Examples
Here are some simple examples showing how to use the Sharp.UI library

## Properties
The properties of the MAUI classes are matched with their fluent helper methods

```cs
new Label()
    .Text("This is a test")
    .Padding(20)
    .FontSize(30)
    .HorizontalOptions(LayoutOptions.Center)
    .VerticalOptions(LayoutOptions.Center)
```

To speed up defining the interface, some common properties are placed directly as constructor arguments

```cs
new Label("This is a test")
```

### Property value
You can set the property value depending on the device idiom, platform, or app theme

```cs
new Label("Hello")
    .FontSize(e => e.Default(50).OnDesktop(80).OnPhone(30))
    .TextColor(e => e.Light(Colors.Black).Dark(Colors.Teal))
```

## Assign
There are two ways to assign objects. Using the `Assign` method 

```cs
new Label()
    .Assign(out label1)
```

or using a constructor parameter

```cs
new Label(out label1)
```

## Containers
Sharp.UI allows you to create single and multi-element containers using braces.

#### Single item containers
Objects such as `ScrollView`, `Border`, `ContentView` etc. can contain only one element.

```cs
new Scrollview
{
    new VStack
    {
        ...
    }
}
```

#### Multi item containers
Objects such as `VStack`, `HStack`, `Grid` etc. can contain many elements.

```cs
new VStack
{
    new Label("Hello,")
        .FontSize(40),
    new Label("World!"),
    new Ellipse()
        .WidthRequest(100)
        .HeightRequest(40)
},
```

## Bindings
Sharp.UI allows you to create bindings using a property method parameter and fluent methods.

```cs
new Label()
    .Text(e => e.Path("Author"))
    .TextColor(e => e.Path("TextColor").Source(myColors))
``` 
Example of bindings between objects

```cs
using Sharp.UI;

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
                .Text(e => e
                    .Path("Value")
                    .Source(slider)
                    .StringFormat("Slider value: {0}")
                )
                .FontSize(28)
                .TextColor(Colors.Blue)
        }
        .VerticalOptions(LayoutOptions.Center);
    }
}
```

## Event handlers
To handle events like `OnClicked`, you can write a method handler

```cs
using Sharp.UI;

public class HelloWorldPage : ContentPage
{
    int count = 0;
    public HelloWorldPage()
    {
        Content = new VStack
        {
            ...
            new Button("Click me")
                .OnClicked(OnCounterClicked)
        };
    }

    private void OnCounterClicked(Button sender)
    {
        count++;
        ...
    }
}
``` 
or do it inline

```cs
new Button("Click me")
    .OnClicked(button =>
    {
        count++;
        if (count == 1)
            button.Text = $"Clicked {count} time";
        else
            button.Text = $"Clicked {count} times";
    })
``` 

## Grid

#### Rows, columns
Using the `Row()`, `Column()` and `Span()` methods, you can set the row, column and span within the grid definition.

```cs
new Label("Column 0, Row 2, Span 2 columns")
    .Column(0)
    .Row(2)
    .Span(column: 2)
```

#### Row and column definition
Using folowing fluent methods you can define the number and sizes of rows and columns.

```cs
new Grid(out grid)
{
    ...
}
.RowDefinitions(e => e.Star(2).Star())
.ColumnDefinitions(e => e.Absolute(100).Star());
``` 


#### Example grid definition

```cs
new Grid(out grid)
{
    new BoxView().Color(Colors.Green),
    new Label("Column 0, Row 0"),

    new BoxView().Color(Colors.Blue).Column(1).Row(0),
    new Label("Column 1, Row 0").Column(1).Row(0),

    new BoxView().Color(Colors.Teal).Column(0).Row(1),
    new Label("Column 0, Row 1").Column(0).Row(1),

    new BoxView().Color(Colors.Purple).Column(1).Row(1),
    new Label("Column 1, Row 1").Column(1).Row(1),
}
.RowDefinitions(e => e.Star(2).Star())
.ColumnDefinitions(e => e.Absolute(200).Star());
```

## Menus

### Context menu

```cs
new Grid(out var grid)
{
    new Image("dotnet_bot.png")
        .ContextFlyout(new MenuFlyout
        {
            new MenuFlyoutItem("Copy")
                .OnClicked(e => Console.WriteLine("Copy")),
            new MenuFlyoutItem("Paste")
                .OnClicked(e => Console.WriteLine("Paste")),
            new MenuFlyoutSubItem("Background color")
            {
                new MenuFlyoutItem("Blue")
                    .OnClicked(e => grid.BackgroundColor = Colors.Blue),
                new MenuFlyoutItem("Red")
                    .OnClicked(e => grid.BackgroundColor = Colors.Red),
                new MenuFlyoutItem("Black")
                    .OnClicked(e => grid.BackgroundColor = Colors.Black)
            }
        })
}
```

## Gesture recognizers

Simple usage of the tap gesture recognizer

```cs
new VStack
{
    new Label("Tap 2 times on the image", out var label),
    new Image("dotnet_bot.png", out var image)
        .SizeRequest(100,100)
        .GestureRecognizers(new GestureRecognizer[]
        {
            new TapGestureRecognizer().NumberOfTapsRequired(2).OnTapped((e, args) =>
            {
                label.Text = "You tapped 2 times";
            })
        })
}
```

This is an example of the pan gesture recognizer

```cs
public class PanGesturePage : ContentPage
{
    double x, y;

    public PanGesturePage()
    {
        Content = new Grid
        {
            new Image("dotnet_bot.png", out var image)
                .SizeRequest(100,100)
                .GestureRecognizers(new GestureRecognizer[]
                {
                    new PanGestureRecognizer().OnPanUpdated((e, args) =>
                    {
                        switch (args.StatusType)
                        {
                            case GestureStatus.Running:
                                image.TranslationX = x + args.TotalX;
                                image.TranslationY = y + args.TotalY;
                                break;

                            case GestureStatus.Completed:
                                x = image.TranslationX;
                                y = image.TranslationY;
                                break;
                        }
                    })
                })
        };
    }
}
```

Pointer gesture recognizer test page

```cs
public class PointerGesturePage : ContentPage
{
    public PointerGesturePage()
    {
        Content = new VStack
        {
            new Label(out var label).FontSize(20),
            new Label(out var enterExitLabel).FontSize(20).TextColor(Colors.Blue),
            new Image("dotnet_bot.png", out var image)
                .SizeRequest(300,300)
                .GestureRecognizers(new GestureRecognizer[]
                {
                    new PointerGestureRecognizer()
                        .OnPointerEntered((e, args) =>
                        {
                            enterExitLabel.Text = "Entered";
                        })
                        .OnPointerExited((e, args) =>
                        {
                            enterExitLabel.Text = "Exited";
                        })
                        .OnPointerMoved((e, args) =>
                        {
                            var pos = args.GetPosition(relativeTo: image).Value;
                            label.Text = $"point: {pos.X}, {pos.Y}";
                        })
                })
        }
        .HorizontalOptions(LayoutOptions.Center)
        .VerticalOptions(LayoutOptions.Center);
    }
}
```

## Style
Using the `Style<T>` class and the `Set()` extension method of the `BindableProperty` you can define the style of the elements

```cs
new Style<Button>
{
    Button.FontSizeProperty.Set(14),
    Button.CornerRadiusProperty.Set(8)
    ...
}
```

If you want to use different values depending on your app theme, device idiom, or platform, you can combine following methods.

```cs
new Style<Button>
{
    Button.TextColorProperty.Set().Light(Colors.White).Dark(AppColors.Primary),
    Button.BackgroundColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
    Button.FontSizeProperty.Set(14).OnDesktop(20),
    Button.CornerRadiusProperty.Set(8).OniOS(15),
    ...
}
```

you can also define visual states of objects

```cs
new Style<Button>
{
    ...
    new VisualState(VisualState.VisualElement.Normal)
    {
        Button.TextColorProperty.Set().Light(Colors.White).Dark(AppColors.Primary),
        Button.BackgroundColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
    },
    new VisualState(VisualState.VisualElement.Disabled)
    {
        Button.TextColorProperty.Set().Light(AppColors.Gray950).Dark(AppColors.Gray200),
        Button.BackgroundColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray600),
    },
    ...
},
```
All defined styles can be placed in `ResourceDictionary`

```cs
new ResourceDictionary
{
    new Style<VStack>
    {
        VStack.VerticalOptionsProperty.Set(LayoutOptions.Center),
        VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center)
        ...
    },
    new Style<Label>
    {
        Label.TextColorProperty.Set(Colors.Red),
        Label.FontSizeProperty.Set(30.0),
        Label.MarginProperty.Set(new Thickness(10,10)),
        Label.HorizontalOptionsProperty.Set(LayoutOptions.Center),
        ...
    },
    ...
};
```

## Triggers

### Property triggers

```cs
using Sharp.UI;

public class PropertyTriggerPage : ContentPage
{
    public PropertyTriggerPage()
    {
        Resources = new ResourceDictionary
        {
            new Style<Entry>
            {
                Entry.BackgroundColorProperty.Set(Colors.Black),
                Entry.TextColorProperty.Set(Colors.White),

                new Trigger(Entry.IsFocusedProperty, true)
                {
                    Entry.BackgroundColorProperty.Set(Colors.Yellow),
                    Entry.TextColorProperty.Set(Colors.Black)
                },
            }
        };

        Content = new VStack
        {
            new Entry("Enter name"),
            new Entry("Enter password"),
            new Entry("Enter address")
        }
        .WidthRequest(300)
        .VerticalOptions(LayoutOptions.Center);
    }
}
```

### Data triggers

```cs
new VStack
{
    new Entry("Enter text...", out var entry).Text(""),
    new Button("Save")
        .Triggers(new List<TriggerBase>
        {
            new DataTrigger<Button>(e => e.Path("Text.Length").Source(entry), 0)
            {
                Entry.IsEnabledProperty.Set(false)
            }
        })
}
```

### Event triggers

```cs
new Entry("Enter text...", out var entry).Text("")
    .Triggers(new List<TriggerBase>
    {
        new EventTrigger("TextChanged")
        {
            new NumericValidationTriggerAction()
        }
    })
```

Action

```cs
public class NumericValidationTriggerAction : TriggerAction<Entry>
{
    protected override void Invoke(Entry entry)
    {
        double result;
        bool isValid = Double.TryParse(entry.Text, out result);
        entry.TextColor = isValid ? Colors.Black : Colors.Red;
    }
}
```

## Behaviours
You can add functionality to user interface controls without having to subclass them with behaviours.

```cs
public class BehaviorTestPage : ContentPage
{
    public BehaviorTestPage()
    {
        Content = new VStack
        {
            new Entry("Enter text...", out var entry).Text("")
                .Behaviors(new NumericValidationBehavior())
        }
        .VerticalOptions(LayoutOptions.Center);
    }
}
```

## Definition templates
With `Def<T>` you can create templates depending on device idiom, platform, or app theme

```cs
new Def<VStack>(e => e
        .BackgroundColor(Colors.Red)
        .Padding(20)
    )
    .OnDesktop(() =>
        new VStack
        {
            new Label("Desktop version"),
            new Image("dotnet_bot.png"),
        })
    .OnPhone(() =>
        new VStack
        {
            new Label("This is a phone version"),
            new Label("No images...")
        }),
```

## Shell
Defining your application's shell

```cs
using Sharp.UI;

public partial class App : Application
{
    public App()
    {
        MainPage = new Shell
        {
            new FlyoutItem(FlyoutDisplayOptions.AsMultipleItems)
            {
                new Tab("Main")
                {
                    new ShellContent<HelloWorldPage>("Hello Page"),
                    new ShellContent<ExamplePage>("ExamplePage"),
                },

                new ShellContent<GridPage>("Grid"),
                ...
            }
        }
        .Resources(AppResources.Default);
    }
}
```

# License 

MIT License, Copyright 2022 Pawel Krzywdzinski
