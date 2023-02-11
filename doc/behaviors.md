# Behaviors
In `Sharp.UI`, you can add functionality to user interface controls using behaviors. Behaviors allow you to add functionality to controls without having to subclass them.

You can add a behavior to a control by using the `Behaviors` method and passing in an instance of the behavior class. For example:

```cs
new Entry("Enter text...", out var entry).Text("")
  .Behaviors(new NumericValidationBehavior());
```

The behavior class, `NumericValidationBehavior`, implements the `OnAttachedTo` and `OnDetachingFrom` methods to subscribe and unsubscribe to the `TextChanged` event of the `Entry` control. The behavior also defines the `OnEntryTextChanged` method, which is triggered when the text in the `Entry` control changes. This method validates if the text is a valid number, and sets the text color accordingly.

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

# Attached Behaviors

If you want to define a behavior using a style, you can use attached properties. You can create attached behaviors using the `AttachedBehavior<TView, TBehavior>` class. 

For example:

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

You can then apply the attached behavior using a style in your `ContentPage`:

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
