 
namespace ExampleApp;

using Microsoft.Maui;
using Sharp.UI;

public partial class App : Application
{
    public App()
    {
        MainPage =  ActivatorUtilities.GetServiceOrCreateInstance<HotReloadTestPage>(Application.Services);
        
        /*MainPage = new Shell
        {
            new FlyoutItem(FlyoutDisplayOptions.AsMultipleItems, e => e.Route("top"))
            {
                new Tab("Main", e => e.Route("main"))
                {
                    new ShellContent<HelloWorldPage>("Hello Page"),
                    new ShellContent<GridPage>("Grid").Route("grid"),
                    new ShellContent<AbsoluteLayoutPage>("Absolute layout"),
                    new ShellContent<ExamplePage>("Scroll View"),
                    new ShellContent<ShapesPage>("Shapes"),
                },

                new Tab("Table/List")
                {
                    new ShellContent<TableViewPage>("TableView"),
                    new ShellContent<ListViewPage>("ListView"),
                    new ShellContent<CollectionPage>("Collection"),
                    new ShellContent<AlternateCollectionPage>("Alternate"),
                    new ShellContent<AlternativeBackroundPage>("Background"),
                },
                new Tab("Triggers")
                {
                    new ShellContent<PropertyTriggerPage>("Property trigger"),
                    new ShellContent<EventTriggerPage>("Event trigger"),
                    new ShellContent<DataTriggerPage>("Data trigger"),
                    new ShellContent<MultiTriggerPage>("Multi trigger"),
                    new ShellContent<EnterExitActionsPage>("Enter/exit"),
                    new ShellContent<StateTriggerPage>("State trigger"),
                    new ShellContent<OrientationTriggerPage>("Orientation")
                },
                new Tab("Menus")
                {
                    new ShellContent<MenuPage>("Menubar"),
                    new ShellContent<ContextMenuPage>("Context menu"),
                },

                new Tab("Gestures")
                {
                    new ShellContent<PanGesturePage>("Pan"),
                    new ShellContent<TapGesturePage>("Tap"),
                    new ShellContent<PointerGesturePage>("Pointer"),
                    new ShellContent<SwipeGesturePage>("Swipe"),
                },

                new Tab("Bindings")
                {
                    new ShellContent<SecondPage>("View Model"),
                    new ShellContent<AngleViewModelPage>("Angle View"),
                    new ShellContent<TestBindingsPage>("Bindings"),
                    new ShellContent<SimpleBindings>("Simple bindings"),
                    new ShellContent<TemplatedParentPage>("Templated CardView"),
                    new ShellContent<CardViewPage>("CardView")
                },

                new Tab("Other")
                {
                    new ShellContent<StyleTestPage>("Style"),
                    new ShellContent<BehaviorTestPage>("Behaviours"),
                    new ShellContent<AttachedBehaviorPage>("Attached behaviours"),
                    new ShellContent<TestPage>("Test Page"),
                    new ShellContent<PathPage>("Path"),
                    new ShellContent<SwipeViewPage>("Swipe"),
                    new ShellContent<DefExamplePage>("Platform Def")
                }
            }
        }
        .ItemTemplate(() => new ShellItemTemplate())
        .FlyoutHeaderTemplate(() => new FlyoutHeaderTemplate())
        .Resources(AppResources.Default)
        .FlyoutBackgroundColor(AppColors.Gray950);
        */
    }
}