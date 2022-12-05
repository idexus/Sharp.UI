namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.Geometry))] 
    public abstract partial class Geometry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.EllipseGeometry))] 
    public partial class EllipseGeometry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.LineGeometry))] 
    public partial class LineGeometry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.RectangleGeometry))] 
    public partial class RectangleGeometry
    {
        public RectangleGeometry(double x, double y, double width, double height) : this()
        {
            this.Rect = new Rect(x, y, width, height);
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.GeometryGroup))] 
    public partial class GeometryGroup { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.PathGeometry))] 
    public partial class PathGeometry { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.PathFigure))]
    public partial class PathFigure
    {
        public PathFigure(double x, double y) : this()
        {
            this.StartPoint = new Point(x, y);
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.ArcSegment))]
    public partial class ArcSegment { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.BezierSegment))]
    public partial class BezierSegment { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Shapes.LineSegment))] 
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