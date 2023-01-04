namespace Sharp.UI.Example;

using Sharp.UI;

public class DataTriggerPage : ContentPage
{
	public DataTriggerPage()
	{
      
		Content = new VStack
		{
			new Entry("Enter text...", out var entry).Text(""),
			new Button("Save")
                .Triggers(new List<TriggerBase>
                {
                    new DataTrigger<Button>(e => e.Path("Text.Length").Source(entry), 0)
                    {
                        Entry.IsEnabledProperty.Set(false)
                    }                    
                }),

            new Button("Save", out var button)
                .Triggers(new DataTrigger<Button>(e => e.Path("Text.Length").Source(entry), 0)
                    {
                        Entry.IsEnabledProperty.Set(false)
                    })
        }
		.VerticalOptions(LayoutOptions.Center);
	}
}
