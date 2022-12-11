# Shell Application

An example of the application shell

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
        .ItemTemplate(() => new ShellItemTemplate())
        .Resources(AppResources.Default);
    }
}
```

### FlyoutItem appearance

An example of defining `FlyoutItem` appearance

```cs
public class ShellItemTemplate : ContentView
{
    public ShellItemTemplate()
    {
        Content = new Grid
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
                .VerticalTextAlignment(TextAlignment.Center)
        }
        .ColumnDefinitions(e => e.Star(0.2).Star(0.8));
    }
}
```