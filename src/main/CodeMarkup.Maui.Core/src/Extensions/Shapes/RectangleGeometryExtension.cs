namespace CodeMarkup.Maui
{
    using CodeMarkup.Maui;
    using CodeMarkup.Maui.Internal;

    public static partial class RectangleGeometryExtension
    {
        public static T Rect<T>(this T self, double x, double y, double width, double height)
            where T : Microsoft.Maui.Controls.Shapes.RectangleGeometry
        {
            self.SetValue(Microsoft.Maui.Controls.Shapes.RectangleGeometry.RectProperty, new Rect(x, y, width, height));
            return self;
        }
    }
}