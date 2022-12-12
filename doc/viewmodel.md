# View, View-Model

### View-Model

Using `[Bindable]` and `[MauiWrapper]` attributes you can define a bindable viewmodel. All bindable properties declared in the interface will be generated automatically.

```cs
[Bindable]
public interface IViewModelProperties
{
    public string Title { get; set; }
    public string Author { get; set; }
}

[MauiWrapper]
public partial class ViewModel : BindableObject, IViewModelProperties
{
    public void SetAuthor(Button button)
    {
        this.Title = "Tosca";
        this.Author = "Puccini";
    }
}
```

### View

```cs
public class ViewModelPage : ContentPage
{
    ViewModel viewModel = new ViewModel();

    public ViewModelPage()
    {
        this.BindingContext = viewModel;

        this.Content = new VStack
        {
            new HStack
            {
                new Label("author:"),
                new Label().Text(e => e.Path("Author"))
            },

            new HStack
            {
                new Label("title:"),
                new Label().Text(e => e.Path("Title"))
            },

            new Button("Test")
                .OnClicked(viewModel.SetAuthor)
        };
    }
}
```