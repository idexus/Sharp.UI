# Triggers

Triggers allow you to set properties in response to certain conditions or events.

### Property Triggers

A property trigger sets a property in response to a change in the value of another property.

Here is an example of using a property trigger to change the background color and text color of an `Entry` element when it gets focused:

```cs
using Sharp.UI;

public class PropertyTriggerPage : ContentPage
{
    public PropertyTriggerPage()
    {
        Resources = new ResourceDictionary
        {
            new Style<Entry>
            {
                Entry.BackgroundColorProperty.Set(Colors.Black),
                Entry.TextColorProperty.Set(Colors.White),

                new Trigger(typeof(Entry))
                    .Property(Entry.IsFocusedProperty)
                    .Value(true)
                    .Setters(
                        new Setters<Entry>(e => e
                            .BackgroundColor(Colors.Yellow)
                            .TextColor(Colors.Black))
                    ),
            }
        };

        Content = new VStack
        {
            new Entry("Enter name"),
            new Entry("Enter password"),
            new Entry("Enter address")
        };
    }
}
```

### Data Triggers

A data trigger sets a property in response to a change in the value of a data source.

Here is an example of using a data trigger to disable a button if the text length of an `Entry` element is zero:

```cs
Content = new VStack
{
    new Entry("Enter text...", out var entry).Text(""),
    new Button("Save")
        .Triggers(
            new DataTrigger(typeof(Button))
                .Binding(e => e.Path("Text.Length").Source(entry))
                .Value(0)
                .Setters(new Setters<Entry>(e => e.IsEnabled(false)))
            ),
}
```

### Event Triggers

An event trigger sets a property in response to an event.

Here is an example of using an event trigger to validate the input of an `Entry` element as a number:

```cs
Content = new VStack
{
    new Entry("Enter text...", out var entry).Text("")
        .Triggers(
            new EventTrigger()
                .Event("TextChanged")
                .Actions(new NumericValidationTriggerAction()))
}
```

And here is the definition of the `NumericValidationTriggerAction` class:

```cs
public class NumericValidationTriggerAction : TriggerAction<Entry>
{
    protected override void Invoke(Entry entry)
    {
        double result;
        bool isValid = Double.TryParse(entry.Text, out result);
        entry.TextColor = isValid ? Colors.Black : Colors.Red;
    }
}
```