namespace Sharp.UI.Example;

using Sharp.UI;

public class MultiTriggerPage : ContentPage
{
	public MultiTriggerPage()
	{
        Content = new VStack
        {
            new Entry("email", out var email).Text(""),
            new Entry("phone", out var phone).Text(""),
            new Button("Save")
                .Triggers(
                    new MultiTrigger<Button>()
                    {
                        Entry.IsEnabledProperty.Set(false)
                    }
                    .Conditions(
                        new BindingCondition(e => e.Path("Text.Length").Source(email), 0),
                        new BindingCondition(e => e.Path("Text.Length").Source(phone), 0))
                )
        }
        .WidthRequest(400)
        .VerticalOptions(LayoutOptions.Center);
    }
}
