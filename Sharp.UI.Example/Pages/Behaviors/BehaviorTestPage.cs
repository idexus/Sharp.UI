namespace Sharp.UI.Example;

using Sharp.UI;

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
        Content = new VStack
        {
            new Entry("Enter text...", out var entry).Text("")
                .Behaviors(new NumericValidationBehavior())
        }
        .VerticalOptions(LayoutOptions.Center);
    }
}
