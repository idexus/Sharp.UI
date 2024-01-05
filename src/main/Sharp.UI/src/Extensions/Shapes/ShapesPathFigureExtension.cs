namespace Sharp.UI
{
    public static partial class ShapesPathFigureExtension
    {
        public static Microsoft.Maui.Controls.Shapes.PathFigure StartPoint(this Microsoft.Maui.Controls.Shapes.PathFigure self,
            double x, double y)
        {
            self.SetValue(Microsoft.Maui.Controls.Shapes.PathFigure.StartPointProperty, new Point(x, y));
            return self;
        }
    }
}
