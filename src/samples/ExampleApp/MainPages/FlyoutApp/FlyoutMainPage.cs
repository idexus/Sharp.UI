
namespace ExampleApp;

using Sharp.UI;
using System.Runtime.CompilerServices;

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
                new TableViewPage().Title("Table"),
                new CardViewPage().Title("Card View"),
            }
        };

        Flyout = new ContentPage("Menu")
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