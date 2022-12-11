## Triggers

### Property triggers

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
        }
        .WidthRequest(300)
        .VerticalOptions(LayoutOptions.Center);
    }
}
```

### Data triggers

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

### Event triggers

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

Action

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