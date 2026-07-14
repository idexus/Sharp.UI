
namespace ExampleApp;

using Microsoft.Maui.Controls.Shapes;
using Sharp.UI;

public sealed partial class TestPage : ContentPage
{
    readonly ResourceDictionary localResources = new()  {

        { "myColor", AppColors.Gray200 },

        new Style<Label>(e => e
            .TextColor(AppColors.Gray200)
            .CenterHorizontally()),

        new Style<Border>(e => e
            .BackgroundColor(AppColors.Gray950)
            .StrokeShape(new RoundRectangle().CornerRadius(40))),
                    
        new Style<Slider>(e => e
            .WidthRequest(300)
            .Margin(50, 0)
            .MaximumTrackColor(Colors.White)
            .MinimumTrackColor(Colors.Gray)),

        new Style<Button>(e => e
            .BackgroundColor(AppColors.Gray950)
            .Padding(20)
            .CornerRadius(10)
            .WidthRequest(270)
            .WidthRequest(250)
            .FontSize(16)) {

            new VisualState<Button>(VisualStates.Button.Normal, e => e
                .TextColor(AppColors.Gray200))
            {            
                async button => {
                    await button.RotateToAsync(0);   // create animations inside VisualState
                }
            },

            new VisualState<Button>(VisualStates.Button.Disabled, e => e
                .TextColor(AppColors.Gray600))
            {            
                async button => {
                    await button.RotateToAsync(180);
                }
            },
        }
    };
}
