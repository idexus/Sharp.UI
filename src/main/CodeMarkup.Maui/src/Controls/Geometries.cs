namespace CodeMarkup.Maui
{
    [CodeMarkup] 
    public partial class EllipseGeometry : Microsoft.Maui.Controls.Shapes.EllipseGeometry
    {
        public EllipseGeometry(double radiusX, double radiusY, Point center)
        {
            this.RadiusX = radiusX; this.RadiusY = radiusY; this.Center = center;
        }
    }

    [CodeMarkup] 
    public partial class LineGeometry : Microsoft.Maui.Controls.Shapes.LineGeometry { }

    [CodeMarkup] 
    public partial class RectangleGeometry : Microsoft.Maui.Controls.Shapes.RectangleGeometry
    {
        public RectangleGeometry(double x, double y, double width, double height)
        {
            this.Rect = new Rect(x, y, width, height);
        }
    }

    [CodeMarkup] 
    public partial class GeometryGroup : Microsoft.Maui.Controls.Shapes.GeometryGroup { }

    [CodeMarkup]
    public partial class ArcSegment : Microsoft.Maui.Controls.Shapes.ArcSegment { }

    [CodeMarkup]
    public partial class BezierSegment : Microsoft.Maui.Controls.Shapes.BezierSegment { }

    [CodeMarkup] 
    public partial class LineSegment : Microsoft.Maui.Controls.Shapes.LineSegment
    {
        public LineSegment(double x, double y)
        {
            this.Point = new Point(x, y);
        }
    }

    [CodeMarkup]
    public partial class PolyLineSegment : Microsoft.Maui.Controls.Shapes.PolyLineSegment { }

    [CodeMarkup]
    public partial class PolyQuadraticBezierSegment : Microsoft.Maui.Controls.Shapes.PolyQuadraticBezierSegment { }

    [CodeMarkup]
    public partial class QuadraticBezierSegment : Microsoft.Maui.Controls.Shapes.QuadraticBezierSegment { }
}
