namespace ExampleApp;

using Sharp.UI;

public partial class PropertyTriggerPage : ContentPage
{
    protected override View Build()
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

		return new VStack
		{
			new Entry("Enter name"),
			new Entry("Enter password"),
			new Entry("Enter address")
		}
		.WidthRequest(300)
        .CenterVertically();
	}
}
