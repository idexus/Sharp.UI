# View, View-Model

### View-Model

By using the `[BindableProperties]` attribute on the interface and the `[SharpObject]` attribute on the class, you can define a bindable viewmodel. All bindable properties declared in the interface will be generated automatically.

```cs
[BindableProperties]
public interface IViewModelProperties
{
    public string Title { get; set; }
    public string Author { get; set; }
}

[SharpObject]
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
public class ViewPage : ContentPage
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
