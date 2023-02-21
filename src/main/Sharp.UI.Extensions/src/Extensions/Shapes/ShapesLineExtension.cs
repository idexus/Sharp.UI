namespace Sharp.UI
{
    public static partial class ShapesLineExtension
    {
        public static Microsoft.Maui.Controls.Shapes.Line Points(this Microsoft.Maui.Controls.Shapes.Line line, double X1, double Y1, double X2, double Y2)
        {
            line.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Line.X1Property, X1);
            line.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Line.X2Property, X2);
            line.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Line.Y1Property, Y1);
            line.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Line.Y2Property, Y2);
            return line;
        }
    }
}

