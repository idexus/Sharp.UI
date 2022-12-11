# Event handlers

`Sharp.UI` matches event handlers `ExampleHandler` with `OnExampleHandler` fluent methods.

### Example

To handle events like `Clicked` yoy can use the `OnClicked` fluent method.

```cs
using Sharp.UI;

public class HelloWorldPage : ContentPage
{
    int count = 0;
    public HelloWorldPage()
    {
        Content = new VStack
        {
            ...
            new Button("Click me")
                .OnClicked(OnCounterClicked)
        };
    }

    private void OnCounterClicked(Button sender)
    {
        count++;
        sender.Text = $"Clicked {count} ";
        sender.Text += count == 1 ? "time" : "times";
    }
}
``` 
another way

```cs
new Button("Click me")
    .OnClicked(button =>
    {
        count++;
        button.Text = $"Clicked {count} ";
        button.Text += count == 1 ? "time" : "times";
    })
``` 