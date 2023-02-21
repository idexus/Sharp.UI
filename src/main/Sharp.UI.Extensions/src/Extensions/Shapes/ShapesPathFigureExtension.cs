namespace Sharp.UI
{
    public static partial class ShapesPathFigureExtension
    {
        public static Microsoft.Maui.Controls.Shapes.PathFigure StartPoint(this Microsoft.Maui.Controls.Shapes.PathFigure obj,
            double x, double y)
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.PathFigure.StartPointProperty, new Point(x, y));
            return obj;
        }
    }
}
