namespace ExampleApp;

using CodeMarkup.Maui;

public class NumericValidationTriggerAction : TriggerAction<Entry>
{
    protected override void Invoke(Entry entry)
    {
        double result;
        bool isValid = Double.TryParse(entry.Text, out result);
        entry.TextColor = isValid ? Colors.Green : Colors.Red;
    }
}

public class EventTriggerPage : ContentPage
{
	public EventTriggerPage()
	{
		Content = new VStack
		{
			new Entry("Enter text...", out var entry).Text("")
                .Triggers(
                    new EventTrigger()
                        .Event("TextChanged")
                        .Actions(new NumericValidationTriggerAction()))
        }
		.CenterVertically();
	}
}
