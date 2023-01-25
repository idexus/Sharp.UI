
namespace ExampleApp
{
    using Sharp.UI;

    public partial class StyleTestPage
	{
        ResourceDictionary localResources => new ResourceDictionary
        {
            new Style<RadioButton>(applyToDerivedTypes: true)
            {
                RadioButton.ControlTemplateProperty.Set(new ControlTemplate(typeof(RadioButtonTemplate)))
            },
            new Style<VStack>
            {
                VStack.VerticalOptionsProperty.Set(LayoutOptions.Center),
                VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center)
            },
            new Style<HStack>
            {
                HStack.VerticalOptionsProperty.Set(LayoutOptions.Center),
                HStack.HorizontalOptionsProperty.Set(LayoutOptions.Center)
            },
            new Style<Label>
            {
                Label.TextColorProperty.Set(Colors.Red),
                Label.FontSizeProperty.Set(30.0),
                Label.MarginProperty.Set(new Thickness(10,10)),
                Label.HorizontalOptionsProperty.Set(LayoutOptions.Center)
            },
        };
    }
}

