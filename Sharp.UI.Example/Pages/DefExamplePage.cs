namespace Sharp.UI.Example;

using Sharp.UI;

public class DefExamplePage : ContentPage
{
    class Names
    {
        public static readonly string smallbot = "smallbot";
        public static readonly string title = "title";
    }

    ResourceDictionary pageResources => new ResourceDictionary
    {
        new Style<Label>
        {
            Label.TextColorProperty.Set().Light(Colors.Red).Dark(Colors.Blue),
            Label.FontSizeProperty.Set(50.0),
            Label.HorizontalOptionsProperty.Set(LayoutOptions.Center),
            Label.VerticalOptionsProperty.Set(LayoutOptions.Center),
            Label.MarginProperty.Set(new Thickness(10,0)),
            Label.TextColorProperty.Set(Colors.Yellow).TargetName(Names.title)
        },
        new Style<Button>
        {
            Button.TextColorProperty.Set(Colors.Blue),
            Button.WidthRequestProperty.Set(400)
        },
        new Style<Image>
        {
            Image.HorizontalOptionsProperty.Set(LayoutOptions.Center),
            Image.HeightRequestProperty.Set(60),
        },
        new Style<VStack>
        {
            VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center),
            VStack.MarginProperty.Set(new Thickness(0,30,0,0))
        }
    };

    public DefExamplePage()
	{        
        Content = new ContentView(out var contentView)
        {
            new VStack
            {
                new Def<VStack>(e => e
                    .BackgroundColor(Colors.Red)
                    .Padding(20)
                )
                .OnDesktop(() =>
                    new VStack
                    {
                        new Label("Desktop version").RegisterName(Names.title, contentView),
                        new Image("dotnet_bot.png"),
                    })
                .OnTablet(() =>
                    new VStack
                    {
                        new Label("Tablet version").RegisterName(Names.title, contentView),
                        new Label("This is a tablet version"),
                        new Label("No images...")
                })
                .Default(() =>
                    new VStack
                    {
                        new Label("Default version").RegisterName(Names.title, contentView),
                    }),

                new HStack()
                    .HorizontalOptions(LayoutOptions.Center)
                    .Children(e => e
                        .OnDesktop(() => new View[]
                        {
                            new Label("ellipse:"),
                            new Ellipse(100,30).Fill(Colors.Pink)
                        })
                        .Default(() => new View[]
                        {
                            new Label("No content")
                        })
                    ),
            }
        }
        .Resources(pageResources);
	}
}
