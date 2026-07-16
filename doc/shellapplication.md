#  Application Shell

Here's an example of a simple shell-based application:

```cs

public sealed partial class AppShell : Shell
{
    protected override void Build()
    {
        this
            .ItemTemplate(() => new ShellItemTemplate())
            .FlyoutHeaderTemplate(() => new FlyoutHeaderTemplate())
            .Resources(AppResources.Default)
            .FlyoutBackgroundColor(AppColors.Gray950);

        SetItems(
            new FlyoutItem(FlyoutDisplayOptions.AsMultipleItems)
            {
                new Tab("Main")
                {
                    new ShellContent<HelloWorldPage>("Hello Page"),
                    new ShellContent<ExamplePage>("ExamplePage"),
                },
                ...
            },
            ...
        );
    }
}

public partial class App : Application
{
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = new Window(new AppShell())
        {
            Title = "Moja Aplikacja",
            Width = 1200,
            Height = 800,
            MinimumWidth = 600,
            MinimumHeight = 400,
            X = 100,  // pozycja od lewej
            Y = 100   // pozycja od góry
        };

        return window;
    }
}
```

You can customize the appearance of the `FlyoutItem` by defining a custom content view and setting the `ItemTemplate` property on the `Shell` element.

Here's an example of defining the appearance of a `FlyoutItem`:

```cs
public sealed partial class ShellItemTemplate : ContentView
{
    public ShellItemTemplate()
    {
        Content = new Grid
		{
			new Image()
				.Source(e => e.Path("FlyoutIcon"))
				.Margin(5)
				.HeightRequest(45),

			new Label()
                .RegisterName("TitleLabel", scopedElement: this)
                .Column(1)
				.Text(e => e.Path("Title"))
				.Padding(new Thickness(50,0,0,0))
				.FontSize(20)
				.VerticalTextAlignment(TextAlignment.Center)
		}
		.ColumnDefinitions(e => e.Absolute(30).Auto());

        this.VisualStateGroups(new VisualStateGroupList
        {
            new VisualState()
                .Name(VisualStates.VisualElement.Normal)
                .Setters(
                    new Setters<ContentView>(e => e.BackgroundColor(Colors.Transparent)),
                    new Setters<Label>(e => e
                        .TextColor(e => e.OnLight(AppColors.Gray900).OnDark(Colors.White))
                        .FontAttributes(FontAttributes.None)
                    ).TargetName("TitleLabel")
                ),

            new VisualState()
                .Name(VisualStates.CollectionView.Selected)
                .Setters(
                    new Setters<ContentView>(e => e.BackgroundColor(e => e.OnPhone(AppColors.Primary).Default(Colors.Transparent))),
                    new Setters<Label>(e => e
                        .TextColor(Colors.White)
                        .FontAttributes(FontAttributes.Bold)
                    ).TargetName("TitleLabel")
                )
        });
    }
}
```