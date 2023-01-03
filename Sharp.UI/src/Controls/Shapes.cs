namespace Sharp.UI
{
    //------ shapes (sealed) -------

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Ellipse))]
    public partial class Ellipse
    {
        public Ellipse(double widthRequest, double heightRequest) : this()
        {
            this.WidthRequest = widthRequest; this.HeightRequest = heightRequest;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Polyline))]
    [ContentProperty("Points")]
    public partial class Polyline { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Line))]
    public partial class Line
    {
        public Line(double X1, double Y1, double X2, double Y2) : this()
        {
            this.X1 = X1; this.Y1 = Y1; this.X2 = X2; this.Y2 = Y2;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Path))]
    [ContentProperty("Data")]
    public partial class Path { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Polygon))]
    [ContentProperty("Points")]
    public partial class Polygon { }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.Rectangle))]
    public partial class Rectangle
    {
        public Rectangle(double widthRequest, double heightRequest) : this()
        {
            this.WidthRequest = widthRequest; this.HeightRequest = heightRequest;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.Shapes.RoundRectangle))] 
    public partial class RoundRectangle
    {
        public RoundRectangle(double widthRequest, double heightRequest, double cornerRadius) : this()
        {
            this.WidthRequest = widthRequest; this.HeightRequest = heightRequest; this.CornerRadius = cornerRadius;
        }
    }
}

