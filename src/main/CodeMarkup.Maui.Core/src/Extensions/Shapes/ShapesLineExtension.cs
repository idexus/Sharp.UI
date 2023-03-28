namespace CodeMarkup.Maui
{
    public static partial class ShapesLineExtension
    {
        public static Microsoft.Maui.Controls.Shapes.Line Points(this Microsoft.Maui.Controls.Shapes.Line self, double X1, double Y1, double X2, double Y2)
        {
            self.SetValue(Microsoft.Maui.Controls.Shapes.Line.X1Property, X1);
            self.SetValue(Microsoft.Maui.Controls.Shapes.Line.X2Property, X2);
            self.SetValue(Microsoft.Maui.Controls.Shapes.Line.Y1Property, Y1);
            self.SetValue(Microsoft.Maui.Controls.Shapes.Line.Y2Property, Y2);
            return self;
        }
    }
}

