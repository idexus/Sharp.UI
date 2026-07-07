
namespace ExampleApp;

using Sharp.UI;

public class FlyoutMainPage : FlyoutPage
{
    private NavigationPage navigationPage;

    public FlyoutMainPage()
    {
        Detail = new NavigationPage(out navigationPage)
        {
            new TabbedPage
            {
                new HelloWorldPage().Title("Hello world"),
                new GridPage().Title("Grid"),                
                new NavigationMainPage().Title("Navigation"),
                new CardViewPage().Title("Card View"),
            }
        };

        Flyout = new ContentPage()
        {
            new Button("Open test page")                
                .FontSize(20)
                .Margin(20)                
                .CenterHorizontally()
                .OnClicked(async e =>
                {
                    await navigationPage.PushAsync<TestPage>();
                    this.IsPresented = false;
                })
        };

        this.FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
        this.IsPresented = false;
    }
}