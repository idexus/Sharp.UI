namespace Sharp.UI.Example;


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

public class BehaviorTestPage : ContentPage
{
	public BehaviorTestPage()
	{
        Resources = new ResourceDictionary
        {
            new Style<Entry>
            {
                Entry.BehaviorsProperty.Set(new Behavior[] {new NumericValidationBehavior()})
            }
        };

		Content = new VStack
		{
			new Entry("Enter text...", out var entry).Text("")
		}
		.VerticalOptions(LayoutOptions.Center);
	}
}
