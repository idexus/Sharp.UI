﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class LineGeometryExtension
    {
        public static T StartPoint<T>(this T self,
            Microsoft.Maui.Graphics.Point startPoint)
            where T : Microsoft.Maui.Controls.Shapes.LineGeometry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Shapes.LineGeometry.StartPointProperty, startPoint);
            return self;
        }
        
        public static T StartPoint<T>(this T self, Func<PropertyContext<Microsoft.Maui.Graphics.Point>, IPropertyBuilder<Microsoft.Maui.Graphics.Point>> configure)
            where T : Microsoft.Maui.Controls.Shapes.LineGeometry
        {
            var context = new PropertyContext<Microsoft.Maui.Graphics.Point>(self, Microsoft.Maui.Controls.Shapes.LineGeometry.StartPointProperty);
            configure(context).Build();
            return self;
        }
        
        public static T EndPoint<T>(this T self,
            Microsoft.Maui.Graphics.Point endPoint)
            where T : Microsoft.Maui.Controls.Shapes.LineGeometry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Shapes.LineGeometry.EndPointProperty, endPoint);
            return self;
        }
        
        public static T EndPoint<T>(this T self, Func<PropertyContext<Microsoft.Maui.Graphics.Point>, IPropertyBuilder<Microsoft.Maui.Graphics.Point>> configure)
            where T : Microsoft.Maui.Controls.Shapes.LineGeometry
        {
            var context = new PropertyContext<Microsoft.Maui.Graphics.Point>(self, Microsoft.Maui.Controls.Shapes.LineGeometry.EndPointProperty);
            configure(context).Build();
            return self;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore