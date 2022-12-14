namespace Sharp.UI.Example;

using Sharp.UI;

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
                .Triggers(new List<TriggerBase>
                {
                    new EventTrigger("TextChanged")
                    {
                        new NumericValidationTriggerAction()
                    }
                })
        }
		.VerticalOptions(LayoutOptions.Center);
	}
}
