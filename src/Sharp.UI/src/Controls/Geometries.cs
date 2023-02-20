namespace Sharp.UI
{
    [SharpObject] 
    public partial class EllipseGeometry : Microsoft.Maui.Controls.Shapes.EllipseGeometry
    {
        public EllipseGeometry(double radiusX, double radiusY, Point center)
        {
            this.RadiusX = radiusX; this.RadiusY = radiusY; this.Center = center;
        }
    }

    [SharpObject] 
    public partial class LineGeometry : Microsoft.Maui.Controls.Shapes.LineGeometry { }

    [SharpObject] 
    public partial class RectangleGeometry : Microsoft.Maui.Controls.Shapes.RectangleGeometry
    {
        public RectangleGeometry(double x, double y, double width, double height)
        {
            this.Rect = new Rect(x, y, width, height);
        }
    }

    [SharpObject] 
    public partial class GeometryGroup : Microsoft.Maui.Controls.Shapes.GeometryGroup { }


    [SharpObject]
    public partial class ArcSegment : Microsoft.Maui.Controls.Shapes.ArcSegment { }

    [SharpObject]
    public partial class BezierSegment : Microsoft.Maui.Controls.Shapes.BezierSegment { }

    [SharpObject] 
    public partial class LineSegment : Microsoft.Maui.Controls.Shapes.LineSegment
    {
        public LineSegment(double x, double y)
        {
            this.Point = new Point(x, y);
        }
    }

    [SharpObject]
    public partial class PolyLineSegment : Microsoft.Maui.Controls.Shapes.PolyLineSegment { }

    [SharpObject]
    public partial class PolyQuadraticBezierSegment : Microsoft.Maui.Controls.Shapes.PolyQuadraticBezierSegment { }

    [SharpObject]
    public partial class QuadraticBezierSegment : Microsoft.Maui.Controls.Shapes.QuadraticBezierSegment { }
}