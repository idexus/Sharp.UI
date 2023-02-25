namespace ExampleApp;

using Sharp.UI;

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
                new MenuFlyoutItem("Red")
                    .OnClicked(e => this.BackgroundColor = Colors.Red),
                new MenuFlyoutItem("Black")
                    .OnClicked(e => this.BackgroundColor = Colors.Black)
            }
        });

        Content = new Grid(out var grid)
        {
            new Label("Menubar test").FontSize(50)
        }
        .AlignCenterVertical()
        .AlignCenterHorizontal();
    }
}
