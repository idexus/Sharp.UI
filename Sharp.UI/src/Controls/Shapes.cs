namespace Sharp.UI
{
    //------ shapes (sealed) -------

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Ellipse), 
        constructorWithProperties: new[] { "WidthRequest", "HeightRequest" })]
    public partial class Ellipse { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Polyline), 
        containerPopertyName: "Points")]
    public partial class Polyline { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Line), 
        constructorWithProperties: new[] { "X1", "Y1", "X2", "Y2" })]
    public partial class Line { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Path), 
        containerPopertyName: "Data")]
    public partial class Path { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Polygon), 
        containerPopertyName: "Points")]
    public partial class Polygon { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Rectangle), 
        constructorWithProperties: new[] { "WidthRequest", "HeightRequest" })]
    public partial class Rectangle { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.RoundRectangle),
        constructorWithProperties: new[] { "WidthRequest", "HeightRequest", "CornerRadius" })] 
    public partial class RoundRectangle { }
}

