# Event handlers

In Maui, you can add functionality to user interface controls by handling events. For each `EventHandler` in a `CodeMarkup.Maui` class, a fluent helper method is generated to make it easier to attach an event handler to the control.

For example, in the case of the `Clicked` event handler in the `Button` class, two fluent methods are generated:

- `OnClicked(Button sender)`
- `OnClicked(object sender, EventArgs e)`

Here's an example of how you can use the fluent helper method `OnClicked` to handle the `Clicked` event on a `Button` control:

```cs
using CodeMarkup.Maui;

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
Or, you can use an inline function to handle the event:

```cs
new Button("Click me")
    .OnClicked(button =>
    {
        count++;
        button.Text = $"Clicked {count} ";
        button.Text += count == 1 ? "time" : "times";
    })
``` 

This makes it easy to attach event handlers to controls in a concise and readable way.