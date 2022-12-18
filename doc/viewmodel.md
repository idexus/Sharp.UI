# View, View-Model

### View-Model

To auto-generate properties you have to set the [BindableProperties] attribute on the interface declaration and the [SharpObject] attribute on the class declaration.

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
