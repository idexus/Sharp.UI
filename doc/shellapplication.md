#  Application Shell

Here's an example of a simple shell-based application:

```cs

public partial class App : Application
{
    protected override Window CreateWindow(IActivationState activationState)
    {
        var shell = new Shell
        {
            e => e
                .ItemTemplate(() => new ShellItemTemplate())
                .Resources(AppResources.Default),

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
        };

        var window = new Window(shell)
        {
            Title = "Moja Aplikacja",
            Width = 1200,
            Height = 800,
            MinimumWidth = 600,
            MinimumHeight = 400,
            X = 100,  // pozycja od lewej
            Y = 100   // pozycja od góry
        };

        return window;
    }
}
```

You can customize the appearance of the `FlyoutItem` by defining a custom content view and setting the `ItemTemplate` property on the `Shell` element.

Here's an example of defining the appearance of a `FlyoutItem`:

```cs
public class ShellItemTemplate : ContentView
{
    public ShellItemTemplate()
    {
        Content = new Grid(e => e.ColumnDefinitions(e => e.Star(0.2).Star(0.8)))
        {
            new Image()
                .Source(e => e.Path("FlyoutIcon"))
                .Margin(5)
                .HeightRequest(45),

            new Label()
                .GridColumn(1)
                .Text(e => e.Path("Title"))
                .FontSize(20)
                .FontAttributes(FontAttributes.Italic)
                .CenterVertically()
        };
    }
}
```