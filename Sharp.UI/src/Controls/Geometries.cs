using System;
using System.Collections;
namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Geometry))] //OK
    public abstract partial class Geometry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.EllipseGeometry))] //OK
    public partial class EllipseGeometry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.LineGeometry))] //OK
    public partial class LineGeometry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.RectangleGeometry))] //OK
    public partial class RectangleGeometry
    {
        public RectangleGeometry(double x, double y, double width, double height) : this()
        {
            this.Rect = new Rect(x, y, width, height);
        }
    }

    // geometry group

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.GeometryGroup), //OK
        containerOfType: typeof(Microsoft.Maui.Controls.Shapes.Geometry),
        singleItemContainer: false)] 
    public partial class GeometryGroup { }

    // path geometry

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.PathGeometry), //OK
        containerOfType: typeof(Microsoft.Maui.Controls.Shapes.PathFigure),
        singleItemContainer: false)]
    public partial class PathGeometry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.PathFigure), //OK
        containerOfType: typeof(Microsoft.Maui.Controls.Shapes.PathSegment),
        singleItemContainer: false)]
    public partial class PathFigure
    {
        public PathFigure(double x, double y) : this()
        {
            this.StartPoint = new Point(x, y);
        }
    }

    // path segments

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.ArcSegment))]
    public partial class ArcSegment { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.BezierSegment))]
    public partial class BezierSegment { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.LineSegment))] //OK
    public partial class LineSegment
    {
        public LineSegment(double x, double y) : this()
        {
            this.Point = new Point(x, y);
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.PolyBezierSegment))]
    public partial class PolyBezierSegment { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.PolyLineSegment))]
    public partial class PolyLineSegment { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.PolyQuadraticBezierSegment))]
    public partial class PolyQuadraticBezierSegment { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.QuadraticBezierSegment))]
    public partial class QuadraticBezierSegment { }
}