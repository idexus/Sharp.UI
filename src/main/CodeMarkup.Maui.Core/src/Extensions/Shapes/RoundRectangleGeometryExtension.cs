namespace CodeMarkup.Maui
{
    public static partial class RoundRectangleGeometryExtension
    {
        public static T Rect<T>(this T self, double x, double y, double width, double height)
            where T : Microsoft.Maui.Controls.Shapes.RectangleGeometry
        {
            self.SetValue(Microsoft.Maui.Controls.Shapes.RoundRectangleGeometry.RectProperty, new Rect(x, y, width, height));
            return self;
        }
    }
}