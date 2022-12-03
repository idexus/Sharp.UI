namespace Sharp.UI.Example;

public class ContextMenuPage : ContentPage
{
	public ContextMenuPage()
	{
        Content = new Grid(out var grid)
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
        };
    }
}
