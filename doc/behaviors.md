# Behaviors
You can add functionality to user interface controls without having to subclass them with behaviours.

```cs
public class BehaviorTestPage : ContentPage
{
    public BehaviorTestPage()
    {
        Content = new VStack
        {
            new Entry("Enter text...", out var entry).Text("")
                .Behaviors(new NumericValidationBehavior())
        }
        .VerticalOptions(LayoutOptions.Center);
    }
}
```

Validation implementation 

```cs
public class NumericValidationBehavior : Behavior<Entry>
{
    protected override void OnAttachedTo(Entry entry)
    {
        entry.TextChanged += OnEntryTextChanged;
        base.OnAttachedTo(entry);
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        entry.TextChanged -= OnEntryTextChanged;
        base.OnDetachingFrom(entry);
    }

    void OnEntryTextChanged(object sender, TextChangedEventArgs args)
    {
        double result;
        bool isValid = double.TryParse(args.NewTextValue, out result);
        ((Entry)sender).TextColor = isValid ? Colors.Green : Colors.Red;
    }
}
```

## Using Attached Properties

If you want to define behavior using style you have to use attached properties

```cs
public class AttachedBehaviorPage : ContentPage
{
	public AttachedBehaviorPage()
	{
        Resources = new ResourceDictionary
        {
            new Style<Entry>
            {
                NumericValidationStyleBehavior.AttachedProperty.Set(true)
            }
        };

		Content = new VStack
		{
			new Entry("Enter text...", out var entry).Text("")
		}
		.VerticalOptions(LayoutOptions.Center);
	}
}
```

#### Validation implementation

In `Sharp.UI` you can create attached behaviors using `AttachedBehavior<TView, TBehavior>` class

```cs
public class NumericValidationStyleBehavior : AttachedBehavior<Entry, NumericValidationStyleBehavior>
{
    protected override void OnAttachedTo(Entry entry)
    {
        entry.TextChanged += OnEntryTextChanged;
        base.OnAttachedTo(entry);
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        entry.TextChanged -= OnEntryTextChanged;
        base.OnDetachingFrom(entry);
    }

    void OnEntryTextChanged(object sender, TextChangedEventArgs args)
    {
        double result;
        bool isValid = double.TryParse(args.NewTextValue, out result);
        ((Entry)sender).TextColor = isValid ? Colors.Green : Colors.Red;
    }
}
```