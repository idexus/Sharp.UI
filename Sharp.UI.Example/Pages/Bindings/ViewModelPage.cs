namespace Sharp.UI.Example;

using Sharp.UI;

[BindableProperties]
public interface ISecondPageViewModelProperties
{
    [DefaultValue("no title")]
    public string Title { get; set; }
    public string Author { get; set; }
}


[SharpObject]
public partial class SecondPageViewModel : BindableObject, ISecondPageViewModelProperties
{
    public void SetAuthor(Button button)
    {
        this.Title = "Tosca";
        this.Author = "Puccini";
    }
}

public class ViewPage : ContentPage
{
    SecondPageViewModel viewModel = new SecondPageViewModel();
    ResourceDictionary pageResources => new ResourceDictionary
    {
        new Style<Label>
        {
            Label.TextColorProperty.Set().OnLight(Colors.Red).OnDark(Colors.Blue),
            Label.FontSizeProperty.Set(50.0),
            Label.HorizontalOptionsProperty.Set(LayoutOptions.Center),
            Label.VerticalOptionsProperty.Set(LayoutOptions.Center),
            Label.MarginProperty.Set(new Thickness(10,0)),
        },
        new Style<Button>
        {
            Button.TextColorProperty.Set(Colors.Blue),
            Button.WidthRequestProperty.Set(400)
        },
        new Style<VStack>
        {
            VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center),
            VStack.VerticalOptionsProperty.Set(LayoutOptions.Center)
        },
    };

    public ViewPage()
    {
        this.Title = "View-Model";
        
        this.BindingContext = viewModel;
        this.Resources = pageResources;

        this.Content = new VStack
        {
            new HStack()
                .HorizontalOptions(LayoutOptions.Center)
                .Children(new View[]
                {
                    new Label("author:"),
                    new Label()
                        .Text(e => e.Path("Author"))
                        .FontSize(e => e.OnMacCatalyst(60).OniOS(70)),
                }),

            new HStack
            {
                new Label("title:"),
                new Label()
                    .Text(e => e.Path("Title"))
            }
            .HorizontalOptions(LayoutOptions.Center),

            new Button("Test")
                .OnClicked(viewModel.SetAuthor)
                .FontSize(100)
                .BackgroundColor(Colors.Red)
        };
    }
}
