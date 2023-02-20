namespace ExampleApp;

using Sharp.UI;

public class DataTriggerPage : ContentPage
{
	public DataTriggerPage()
	{
      
		Content = new VStack
		{
			new Entry("Enter text...", out var entry).Text(""),
			new Button("Save")
                .Triggers(
					new DataTrigger(typeof(Button))
						.Binding(e => e.Path("Text.Length").Source(entry))
						.Value(0)
						.Setters(Entry.IsEnabledProperty.Set(false))
                    ),
        }
		.VerticalOptions(LayoutOptions.Center);
	}
}
