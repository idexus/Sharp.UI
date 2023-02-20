using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp
{
    using Sharp.UI;

    public class RadioButtonTemplate : ContentView
    {
        public RadioButtonTemplate()
        {
            Content = new Frame
            {
                new Grid {
                    new Grid()
                    {
                        new Ellipse()
                            .Stroke(Colors.Blue)
                            .Fill(Colors.Wheat)
                            .SizeRequest(16,16)
                            .HorizontalOptions(LayoutOptions.Center)
                            .VerticalOptions(LayoutOptions.Center),

                        new Ellipse()
                            .RegisterName("Check", scopedElement: this)
                            .Fill(Colors.Yellow)
                            .SizeRequest(12,12)
                            .HorizontalOptions(LayoutOptions.Center)
                            .VerticalOptions(LayoutOptions.Center)
                    }
                    .WidthRequest(18)
                    .HeightRequest(10)
                    .HorizontalOptions(LayoutOptions.End)
                    .VerticalOptions(LayoutOptions.Start),

                    new ContentPresenter()
                        .SizeRequest(80,80)
                }
                .Margin(4)
                .WidthRequest(100)
            }
            .BorderColor(AppColors.Gray900)
            .BackgroundColor(AppColors.Gray900)
            .HasShadow(false)
            .SizeRequest(100, 100)
            .VerticalOptions(LayoutOptions.Start)
            .HorizontalOptions(LayoutOptions.Start)
            .Padding(0)
            .Margin(5);

            this.VisualStateGroups(new VisualStateGroupList
            {
                new VisualStateGroup(VisualStateGroup.CommonStates)
                {
                    new VisualState(VisualState.RadioButton.Checked)
                    {
                        VisualElement.BackgroundColorProperty.Set(Colors.Red),
                        Ellipse.FillProperty.Set(Colors.Red).TargetName("Check")
                    },
                    new VisualState(VisualState.RadioButton.Unchecked)
                    {
                        VisualElement.BackgroundColorProperty.Set(Colors.Blue),
                        Ellipse.FillProperty.Set(Colors.Yellow).TargetName("Check")
                    }
                }
            });
        }
    }
}
