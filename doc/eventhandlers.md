# Event handlers

`Sharp.UI` matches event handlers (e.g. `ExampleHandler`) with event handler fluid methods (e.g. `OnExampleHandler`)

### Example

To handle event like `Clicked` yoy can use the `OnClicked` fluent method.

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
