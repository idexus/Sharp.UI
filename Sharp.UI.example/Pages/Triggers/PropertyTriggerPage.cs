namespace Sharp.UI.Example;

using Sharp.UI;

public class TriggersPage : ContentPage
{
    public TriggersPage()
	{
		Resources = new ResourceDictionary
		{
			new Style<Entry>
			{
				Entry.BackgroundColorProperty.Set(Colors.Black),
				Entry.TextColorProperty.Set(Colors.White),

				new Trigger(Entry.IsFocusedProperty, true)
				{
					Entry.BackgroundColorProperty.Set(Colors.Yellow),
					Entry.TextColorProperty.Set(Colors.Black)
				},
			}
		};

		Content = new VStack
		{
			new Entry("Enter name"),
			new Entry("Enter password"),
			new Entry("Enter address")
		}
		.WidthRequest(300)
        .VerticalOptions(LayoutOptions.Center);
	}
}
