namespace ExampleApp;

using Sharp.UI;


public partial class SecondPage : ContentPage
{
    SecondPageViewModel viewModel => BindingContext as SecondPageViewModel;

    public SecondPage(SecondPageViewModel viewModel)
    {
        BindingContext = viewModel;
        this.Title = "View-Model";
        this.Resources = pageResources;

        this.Content = new VStack
        {
            new VStack
            {
                new HStack()
                    .HorizontalOptions(LayoutOptions.Center)
                    .Children(new View[]
                    {
                        new Label("Author : "),
                        new Label()
                            .Text(e => e.Path("Author"))
                            .FontSize(e => e.OnMacCatalyst(60).OniOS(70)),
                    }),

                new HStack
                {
                    new Label("Title : "),
                    new Label()
                        .Text(e => e.Path("Title"))
                }
                .HorizontalOptions(LayoutOptions.Center)
            }
            .Margin(30),

            new Button("Test")
                .OnClicked(viewModel.SetAuthor)
                .FontSize(100)
                .BackgroundColor(Colors.Red)
        };
    }
}
