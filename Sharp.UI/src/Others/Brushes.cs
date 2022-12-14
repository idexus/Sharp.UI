using System;
namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.LinearGradientBrush))]
    public partial class LinearGradientBrush
    {
        public LinearGradientBrush(Point startPoint, Point endPoint) : this()
        {
            StartPoint = startPoint; EndPoint = endPoint;
        }
    }


    [SharpObject(typeof(Microsoft.Maui.Controls.RadialGradientBrush))]
    public partial class RadialGradientBrush
    {
        public RadialGradientBrush(Point center) : this()
        {
            Center = center;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.GradientStop))]
    public partial class GradientStop
    {
        public GradientStop(Color color, double offset)
            : base(color, (float)offset) { }
    }
}

