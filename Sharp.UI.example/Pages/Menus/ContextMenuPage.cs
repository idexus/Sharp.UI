namespace Sharp.UI.Example;

public class ContextMenuPage : ContentPage
{
	public ContextMenuPage()
	{
        Content = new Grid
        {
            new Label("Context menu"),
            new Image("dotnet_bot.png")
                .SizeRequest(300, 300)
                .ContextFlyout(new MenuFlyout
                {
                    new MenuFlyoutItem("Copy")
                        .OnClicked(e => Console.WriteLine("Copy")),
                    new MenuFlyoutItem("Paste")
                        .OnClicked(e => Console.WriteLine("Paste"))
                })
        };
    }
}
