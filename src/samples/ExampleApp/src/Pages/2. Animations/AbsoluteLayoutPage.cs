using Microsoft.Maui.Controls.Shapes;

namespace ExampleApp;

using Sharp.UI;

public sealed partial class AbsoluteLayoutPage : ContentPage
{
    string mySourceCode = """
new AbsoluteLayout
{
    new Grid(out grid)
    {
        e => e
            .BackgroundColor(Colors.Red)
            .AbsoluteLayoutBounds(30,0,300,100)
            .Background(new LinearGradientBrush(new Point(0, 0), new Point(1, 1))
            {
                new GradientStop(Colors.Yellow, 0.0),
                new GradientStop(Colors.Red, 0.25),
                new GradientStop(Colors.Blue, 0.75),
                new GradientStop(Colors.LimeGreen, 1.0)
            }),

        new Label("Absolute Layout")
            .FontSize(30)
            .Center()
    },

    new Border(out border, e => e
        .AbsoluteLayoutBounds(100,150,300,100)
        .Stroke(Colors.Red)
        .StrokeThickness(4)
        .StrokeShape(new RoundRectangle().CornerRadius(40)))
    {
        new Label("This is a test", out var label)
            .Padding(20)
            .FontSize(40)
            .Center()
    }
}
.Margin(0,20,0,20)

// Animations

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
                await border.TranslateToAsync(-border.X, 0, 1000);
                await border.TranslateToAsync(this.Width - border.Width - border.X, 0, 1000);
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
                await grid.TranslateToAsync(-grid.X, 0, 700);
                await grid.TranslateToAsync(this.Width - grid.Width - grid.X, 0, 700);
            }
        });
    }
}
""";

    bool animate = false;
    private Border border;
    private Grid grid;

    protected override void Build()
    {
        Content = new ScrollView(e => e.Orientation(ScrollOrientation.Vertical))
        {
            new Example
            {
                new AbsoluteLayout
                {
                    new Grid(out grid)
                    {
                        e => e
                            .BackgroundColor(Colors.Red)
                            .AbsoluteLayoutBounds(30,0,300,100)
                            .Background(new LinearGradientBrush(new Point(0, 0), new Point(1, 1))
                            {
                                new GradientStop(Colors.Yellow, 0.0),
                                new GradientStop(Colors.Red, 0.25),
                                new GradientStop(Colors.Blue, 0.75),
                                new GradientStop(Colors.LimeGreen, 1.0)
                            }),

                        new Label("Absolute Layout")
                            .FontSize(30)
                            .Center()
                    },

                    new Border(out border, e => e
                        .AbsoluteLayoutBounds(100,150,300,100)
                        .Stroke(Colors.Red)
                        .StrokeThickness(4)
                        .StrokeShape(new RoundRectangle().CornerRadius(40)))
                    {
                        new Label("This is a test", out var label)
                            .Padding(20)
                            .FontSize(40)
                            .Center()
                    }
                }
                .Margin(0,20,0,20)
            }
            .ContentPadding(0)
            .IsExpanded(true)
            .Title("Absolute layout animation example")
            .SourceText(mySourceCode)
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
                    await border.TranslateToAsync(-border.X, 0, 1000);
                    await border.TranslateToAsync(this.Width - border.Width - border.X, 0, 1000);
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
                    await grid.TranslateToAsync(-grid.X, 0, 700);
                    await grid.TranslateToAsync(this.Width - grid.Width - grid.X, 0, 700);
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
