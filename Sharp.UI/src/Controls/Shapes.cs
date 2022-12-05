namespace Sharp.UI
{
    //------ shapes (sealed) -------

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Ellipse), 
        constructorWithProperties: new[] { "WidthRequest", "HeightRequest" })]
    public partial class Ellipse { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Polyline), 
        containerPopertyName: "Points")]
    public partial class Polyline { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Line), 
        constructorWithProperties: new[] { "X1", "Y1", "X2", "Y2" })]
    public partial class Line { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Path), 
        containerPopertyName: "Data")]
    public partial class Path { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Polygon), 
        containerPopertyName: "Points")]
    public partial class Polygon { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Rectangle), 
        constructorWithProperties: new[] { "WidthRequest", "HeightRequest" })]
    public partial class Rectangle { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.RoundRectangle),
        constructorWithProperties: new[] { "WidthRequest", "HeightRequest", "CornerRadius" })] 
    public partial class RoundRectangle { }
}

