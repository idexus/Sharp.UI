using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp;

using Sharp.UI;

public class AbsoluteLayoutPage : ContentPage
{
    bool animate = false;
    private Border border;
    private Grid grid;

    public AbsoluteLayoutPage()
	{
		Content = new AbsoluteLayout
		{
            new Grid(out grid)
            {
                e => e
                    .BackgroundColor(Colors.Red)
                    .AbsoluteLayoutBounds(30,170,300,100)
                    .Background(new LinearGradientBrush(new Point(0, 0), new Point(1, 1))
                    {
                        new GradientStop(Colors.Yellow, 0.0),
                        new GradientStop(Colors.Red, 0.25),
                        new GradientStop(Colors.Blue, 0.75),
                        new GradientStop(Colors.LimeGreen, 1.0)
                    }),

                new Label("Absolute Layout")
                    .FontSize(30)
                    .CenterInContainer()
            },

            new Border(out border, e => e
                .AbsoluteLayoutBounds(100,400,300,200)
                .Stroke(Colors.Blue)
                .StrokeThickness(4)
                .StrokeShape(new RoundRectangle().CornerRadius(40)))
            {
                new Label("This is a test", out var label)
                    .Padding(20)
                    .FontSize(40)
                    .CenterInContainer()
            }
        };
    }

    Task borderTask = null;
    Task gridTask = null;
    protected override void OnAppearing()
    {
        base.OnAppearing();
        animate = true;

        if (borderTask == null || borderTask.IsCompleted)
        {
            borderTask = Task.Run(async () =>
            {
                await Task.Delay(300);
                while (animate)
                {
                    await border.TranslateTo(-border.X, 0, 1000);
                    await border.TranslateTo(this.Width - border.Width - border.X, 0, 1000);
                }
            });
        }

        if (gridTask == null || gridTask.IsCompleted)
        {
            gridTask = Task.Run(async () =>
            {
                await Task.Delay(300);
                while (animate)
                {
                    await grid.TranslateTo(-grid.X, 0, 700);
                    await grid.TranslateTo(this.Width - grid.Width - grid.X, 0, 700);
                }
            });
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        animate = false;
    }
}
