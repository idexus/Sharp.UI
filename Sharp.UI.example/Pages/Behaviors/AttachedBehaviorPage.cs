namespace Sharp.UI.Example;


public class NumericValidationStyleBehavior : Behavior<Entry>
{
    public static readonly BindableProperty AttachBehaviorProperty =
    BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(NumericValidationStyleBehavior), false, propertyChanged: OnAttachBehaviorChanged);

    static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
    {
        Entry entry = view as Entry;
        if (entry == null)
        {
            return;
        }

        bool attachBehavior = (bool)newValue;
        if (attachBehavior)
        {
            entry.Behaviors.Add(new NumericValidationStyleBehavior());
        }
        else
        {
            Behavior toRemove = entry.Behaviors.FirstOrDefault(b => b is NumericValidationStyleBehavior);
            if (toRemove != null)
            {
                entry.Behaviors.Remove(toRemove);
            }
        }
    }

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
                NumericValidationStyleBehavior.AttachBehaviorProperty.Set(true)
            }
        };

		Content = new VStack
		{
			new Entry("Enter text...", out var entry).Text("")
		}
		.VerticalOptions(LayoutOptions.Center);
	}
}
