namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Geometry))] 
    public abstract partial class Geometry { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.EllipseGeometry),
        constructorWithProperties: new[] { "RadiusX", "RadiusY", "Center" })] 
    public partial class EllipseGeometry { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.LineGeometry))] 
    public partial class LineGeometry { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.RectangleGeometry))] 
    public partial class RectangleGeometry
    {
        public RectangleGeometry(double x, double y, double width, double height) : this()
        {
            this.Rect = new Rect(x, y, width, height);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.GeometryGroup))] 
    public partial class GeometryGroup { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.PathGeometry))] 
    public partial class PathGeometry { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.PathFigure))]
    public partial class PathFigure
    {
        public PathFigure(double x, double y) : this()
        {
            this.StartPoint = new Point(x, y);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.ArcSegment))]
    public partial class ArcSegment { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.BezierSegment))]
    public partial class BezierSegment { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.LineSegment))] 
    public partial class LineSegment
    {
        public LineSegment(double x, double y) : this()
        {
            this.Point = new Point(x, y);
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.PolyBezierSegment))]
    public partial class PolyBezierSegment { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.PolyLineSegment))]
    public partial class PolyLineSegment { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.PolyQuadraticBezierSegment))]
    public partial class PolyQuadraticBezierSegment { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.QuadraticBezierSegment))]
    public partial class QuadraticBezierSegment { }
}