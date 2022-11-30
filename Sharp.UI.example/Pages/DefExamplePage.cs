namespace Sharp.UI.Example;

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
            Image.HeightRequestProperty.Set(100),
            Image.HeightRequestProperty.Set(40).TargetName(Names.smallbot),
        },
        new Style<VStack>
        {
            VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center)
        }
    };

    public DefExamplePage()
	{
        Resources = pageResources;
		Content = new VStack
		{
            new Def<VStack>(e => e
                    .BackgroundColor(Colors.Red)
                    .Padding(20)
                )
                .OnDesktop(() =>
                    new VStack
                    {
                        new Label("Desktop version").RegisterName(Names.title, this),
                        new Image("dotnet_bot.png").RegisterName(Names.smallbot, this),
                        new Image("dotnet_bot.png"),
                    })
                .OnPhone(() =>
                    new VStack
                    {
                        new Label("This is a phone version"),
                        new Label("No images...")
                    }),

                new HStack()
                    .HorizontalOptions(LayoutOptions.Center)
                    .Children(e => e
                        .OnDesktop(() => new View[]
                        {
                            new Label("ellipse:"),                            
                            new Ellipse(100,30).Fill(Colors.Pink)
                        })
                        .OniOS(() => new View[]
                        {
                            new Label("No content")
                        })
                    ),
        };
	}
}
