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
                ...

                new Trigger(Entry.IsFocusedProperty, true)
                {
                    Entry.BackgroundColorProperty.Set(Colors.Yellow),
                    Entry.TextColorProperty.Set(Colors.Black)
                },
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
new VStack
{
    new Entry("Enter text...", out var entry).Text(""),
    new Button("Save")
        .Triggers(new List<TriggerBase>
        {
            new DataTrigger<Button>(e => e.Path("Text.Length").Source(entry), 0)
            {
                Entry.IsEnabledProperty.Set(false)
            }
        })
}
```

### Event Triggers

An event trigger sets a property in response to an event.

Here is an example of using an event trigger to validate the input of an `Entry` element as a number:

```cs
new Entry("Enter text...", out var entry).Text("")
    .Triggers(new List<TriggerBase>
    {
        new EventTrigger("TextChanged")
        {
            new NumericValidationTriggerAction()
        }
    })
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