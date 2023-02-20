namespace Sharp.UI
{
    public static partial class ShapesLineExtension
    {
        public static Microsoft.Maui.Controls.Shapes.Line Points(this Microsoft.Maui.Controls.Shapes.Line line, double X1, double Y1, double X2, double Y2)
        {
            line.X1 = X1; line.Y1 = Y1; line.X2 = X2; line.Y2 = Y2;
            return line;
        }
    }

    // TODO: all shapes (sealed)

    /*
     
    [SharpObject]
    public partial class Ellipse : Microsoft.Maui.Controls.Shapes.Ellipse
    {
        public Ellipse(double widthRequest, double heightRequest) : this()
        {
            this.WidthRequest = widthRequest; this.HeightRequest = heightRequest;
        }
    }

    [SharpObject]
    [ContentProperty("Points")]
    public partial class Polyline : Microsoft.Maui.Controls.Shapes.Polyline { }

    [SharpObject]
    public partial class Line : Microsoft.Maui.Controls.Shapes.Line
    {
        public Line(double X1, double Y1, double X2, double Y2) : this()
        {
            this.X1 = X1; this.Y1 = Y1; this.X2 = X2; this.Y2 = Y2;
        }
    }

    [SharpObject]
    [ContentProperty("Data")]
    public partial class Path : Microsoft.Maui.Controls.Shapes.Path { }

    [SharpObject]
    [ContentProperty("Points")]
    public partial class Polygon : Microsoft.Maui.Controls.Shapes.Polygon { }

    [SharpObject]
    public partial class Rectangle : Microsoft.Maui.Controls.Shapes.Rectangle
    {
        public Rectangle(double widthRequest, double heightRequest) : this()
        {
            this.WidthRequest = widthRequest; this.HeightRequest = heightRequest;
        }
    }

    [SharpObject] 
    public partial class RoundRectangle : Microsoft.Maui.Controls.Shapes.RoundRectangle
    {
        public RoundRectangle(double widthRequest, double heightRequest, double cornerRadius) : this()
        {
            this.WidthRequest = widthRequest; this.HeightRequest = heightRequest; this.CornerRadius = cornerRadius;
        }
    }

    */
}

