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
}

