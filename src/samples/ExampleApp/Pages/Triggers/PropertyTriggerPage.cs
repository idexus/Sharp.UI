namespace ExampleApp;

using Sharp.UI;

public class PropertyTriggerPage : ContentPage
{
    public PropertyTriggerPage()
	{
		Resources = new ResourceDictionary
		{
			new Style<Entry>(e => e
				.BackgroundColor(Colors.Black)
				.TextColor(Colors.White))
			{
				new Trigger(typeof(Entry))
					.Property(Entry.IsFocusedProperty)
					.Value(true)
					.Setters(
						new Setters<Entry>(e => e
							.BackgroundColor(Colors.Yellow)
							.TextColor(Colors.Black))
					),
			}
		};

		Content = new VStack
		{
			new Entry("Enter name"),
			new Entry("Enter password"),
			new Entry("Enter address")
		}
		.WidthRequest(300)
        .AlignCenterVertical();
	}
}
