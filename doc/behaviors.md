## Behaviors
You can add functionality to user interface controls without having to subclass them with behaviours.

```cs
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
```