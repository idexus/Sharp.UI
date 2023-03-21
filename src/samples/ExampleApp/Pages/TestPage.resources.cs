
namespace ExampleApp;

using Microsoft.Maui.Controls.Shapes;
using CodeMarkup.Maui;

public partial class TestPage : ContentPage
{
    readonly ResourceDictionary localResources = new()  {

        { "myColor", AppColors.Gray200 },

        new Style<Label>(e => e
            .TextColor(AppColors.Gray200)
            .Center()),

        new Style<Button>(e => e
            .BackgroundColor(AppColors.Gray950)
            .Padding(20)
            .CornerRadius(10)
            .WidthRequest(270)) {

            new VisualState<Button>(VisualStates.Button.Normal, e => e
                .FontSize(33)
                .TextColor(AppColors.Gray200))
            {            
                async button => {
                    await button.RotateTo(0);   // create animations inside VisualState
                }
            },

            new VisualState<Button>(VisualStates.Button.Disabled, e => e
                .FontSize(20)
                .TextColor(AppColors.Gray600))
            {            
                async button => {
                    await button.RotateTo(180);
                }
            },
        }
    };
}
