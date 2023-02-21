﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class LineSegmentExtension
    {
        public static T Point<T>(this T obj,
            Microsoft.Maui.Graphics.Point point)
            where T : Microsoft.Maui.Controls.Shapes.LineSegment
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.LineSegment.PointProperty, point);
            return obj;
        }
        
        public static T Point<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Point>, ValueBuilder<Microsoft.Maui.Graphics.Point>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.LineSegment
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Point>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.LineSegment.PointProperty, builder.GetValue());
            return obj;
        }
        
        public static T Point<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Point>, BindingBuilder<Microsoft.Maui.Graphics.Point>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.LineSegment
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Graphics.Point>(obj, Microsoft.Maui.Controls.Shapes.LineSegment.PointProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
