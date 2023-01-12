namespace ExampleApp;

using Sharp.UI;

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
