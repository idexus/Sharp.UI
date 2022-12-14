namespace Sharp.UI.Example;

using Sharp.UI;

public class ContextMenuPage : ContentPage
{
	public ContextMenuPage()
	{
        Content = new Grid(out var grid)
        {
            new Image("dotnet_bot.png")
                .FlyoutBaseContextFlyout(new MenuFlyout
                {
                    new MenuFlyoutItem("Go to Grid Page")
                        .OnClicked(async e => await Shell.Current.GoToAsync("//top/main/grid")),

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
                    },
                    new MenuFlyoutSubItem("Player")
                    {
                        new MenuFlyoutItem("Pause")
                            .IconImageSource(new FontImageSource("&#x23F8;", "Arial"))
                            .OnClicked(e => Console.WriteLine("Pause")),
                        new MenuFlyoutItem("Stop")
                            .IconImageSource(new FontImageSource("&#x23F9;", "Arial"))
                            .OnClicked(e => Console.WriteLine("Stop")),
                    }
                })
        };
    }
}
