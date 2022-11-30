using System;
using System.ComponentModel;

namespace Sharp.UI
{
    //------ shapes (sealed) -------

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Ellipse), //OK
        constructorWithProperties: new[] { "WidthRequest", "HeightRequest" })]
    public partial class Ellipse { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Polyline), //OK
        containerOfType: typeof(Microsoft.Maui.Graphics.Point),
        containerPopertyName: "Points")]
    public partial class Polyline { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Line), //OK
        constructorWithProperties: new[] { "X1", "Y1", "X2", "Y2" })]
    public partial class Line { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Path), //OK
        containerOfType: typeof(Microsoft.Maui.Controls.Shapes.Geometry),
        containerPopertyName: "Data",
        singleItemContainer: true)]
    public partial class Path { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Polygon), //OK
        containerOfType: typeof(Microsoft.Maui.Graphics.Point),
        containerPopertyName: "Points")]
    public partial class Polygon { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Rectangle), //OK
        constructorWithProperties: new[] { "WidthRequest", "HeightRequest" })]
    public partial class Rectangle { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.RoundRectangle),
        constructorWithProperties: new[] { "WidthRequest", "HeightRequest", "CornerRadius" })] //OK
    public partial class RoundRectangle { }
}

