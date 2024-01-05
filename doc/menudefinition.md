# Menus in Sharp.UI

### Context menu

Here is an example of creating a context menu for an image. The context menu has options for copying and pasting, and also for changing the background color of a grid.

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

### Menu bar

Here is an example of creating a menu bar for a `ContentPage`. The menu bar has three options: My Menu, Edit, and Theme.

```cs
public class MenuPage : ContentPage
{
    public MenuPage()
    {
        this.MenuBarItems(new MenuBarItem[]
        {
            new MenuBarItem("My Menu")
            {
                new MenuFlyoutItem("Exit")
                    .OnClicked(e => Application.Current.Quit()),
            },
            new MenuBarItem("Edit")
            {
                new MenuFlyoutItem("Copy")
                    .OnClicked(e => Console.WriteLine("Copy")),
                new MenuFlyoutItem("Paste")
                    .OnClicked(e => Console.WriteLine("Paste")),
            },
            new MenuBarItem("Theme")
            {
                new MenuFlyoutItem("Blue")
                    .OnClicked(e => this.BackgroundColor = Colors.Blue),
                ...
            }
        });

        ...
    }
}
```