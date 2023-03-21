using System;
namespace CodeMarkup.Maui
{
    [CodeMarkup]
    public partial class LinearGradientBrush : Microsoft.Maui.Controls.LinearGradientBrush
    {
        public LinearGradientBrush(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint; EndPoint = endPoint;
        }
    }

    [CodeMarkup]
    public partial class RadialGradientBrush : Microsoft.Maui.Controls.RadialGradientBrush
    {
        public RadialGradientBrush(Point center)
        {
            Center = center;
        }
    }

    [CodeMarkup]
    public partial class GradientStop : Microsoft.Maui.Controls.GradientStop
    {
        public GradientStop(Color color, double offset)
            : base(color, (float)offset) { }
    }
}

