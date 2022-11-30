using Sharp.UI;

namespace Sharp.UI.Example;

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
                    new ShellContent<HelloWorldPage>().Title("Hello Page"),
                    new ShellContent<ExamplePage>().Title("ExamplePage"),
                },

                new Tab("Lists")
                {
                    new ShellContent<TableViewPage>().Title("TableView"),
                    new ShellContent<ListViewPage>().Title("ListView"),
                    new ShellContent<CollectionPage>().Title("Collection"),
                },

                new ShellContent<GridPage>().Title("Grid"),
                new ShellContent<StyleTestPage>().Title("Style"),

                new Tab("Bindings")
                {
                    new ShellContent<ViewModelPage>().Title("View Model"),
                    new ShellContent<TestBindingsPage>().Title("Bindings"),
                },

                new Tab("Other")
                {
                    new ShellContent<TestPage>().Title("Test Page"),
                    new ShellContent<PathPage>().Title("Path"),
                    new ShellContent<SwipeViewPage>().Title("Swipe"),
                    new ShellContent<DefExamplePage>().Title("Platform Def")
                }
            }
        }
        .Resources(AppResources.Default)
        .FlyoutBackgroundColor(AppColors.Gray950);
    }
}
