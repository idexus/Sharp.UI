
namespace ExampleApp
{
    using Sharp.UI;

    public partial class StyleTestPage
	{
        ResourceDictionary localResources => new ResourceDictionary
        {
            new Style<RadioButton>(applyToDerivedTypes: true, e => e
                .ControlTemplate(new ControlTemplate(typeof(RadioButtonTemplate)))),
                
            new Style<VStack>(e => e
                .AlignCenterVertical()
                .AlignCenterHorizontal()),
            
            new Style<HStack>(e => e
                .AlignCenterVertical()
                .AlignCenterHorizontal())
        };
    }
}

