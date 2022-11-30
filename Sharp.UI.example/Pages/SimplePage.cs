using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sharp.UI;

public partial class SimpleViewModel : ObservableObject
{
    [ObservableProperty] string _title = "No title";
    [ObservableProperty] string _author = "No author";

    [RelayCommand]
    void SetAuhor()
    {
        this.Title = "Tosca";
        this.Author = "Puccini";
    }
}

public class SimpleBindings : ContentPage
{
    SimpleViewModel viewModel = new SimpleViewModel();

    public SimpleBindings()
    {
        this.BindingContext = viewModel;

        this.Content = new VStack
        {
            new HStack
            {
                new Label("author:"),
                new Label()
                    .Text(e => e.BindTo("Author"))
                    .TextColor(e => e.BindTo("TextColor"))
                    .FontSize(e => e.OnMacCatalyst(60).OniOS(70))
            },

            new Button("Test")
                .Command(viewModel.SetAuhorCommand)
                .FontSize(100)
                .BackgroundColor(Colors.Red)
        };
    }
}