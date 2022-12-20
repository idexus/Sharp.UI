namespace Sharp.UI.Example;

public class FlyoutMainPage : FlyoutPage
{
    private NavigationPage navigationPage;

    public FlyoutMainPage()
	{
        Detail = new NavigationPage(out navigationPage)
        {
            new TabbedPage
            {
                new HelloWorldPage(),
                new GridPage(),
                new CollectionPage(),
                new ExamplePage(),
                new TableViewPage(),
                new ViewPage(),
                new StyleTestPage(),
                new SwipeViewPage(),
                new PathPage(),
            }
        };

        Flyout = new ContentPage("Menu")
        {
            new Button("Open test page")
                .FontSize(50)
                .OnClicked(async e =>
                {
                    this.IsPresented = false;
                    await navigationPage.PushAsync(new TestPage());
                })
        };
    }
}
