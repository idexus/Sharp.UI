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
                new HStack
                {
                    new Label("Author : "),
                    new Label().Text(e => e.Path("Author"))
                },

                new HStack
                {
                    new Label("Title : "),
                    new Label().Text(e => e.Path("Title"))
                }
            }
            .Margin(30),

            new Button("Test")
                .OnClicked(viewModel.SetAuthor)
        };
    }
}
