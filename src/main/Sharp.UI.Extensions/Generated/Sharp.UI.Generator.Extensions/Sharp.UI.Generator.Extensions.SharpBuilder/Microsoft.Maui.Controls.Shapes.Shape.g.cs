﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class ShapeExtension
    {
        public static T Fill<T>(this T obj,
            Microsoft.Maui.Controls.Brush fill)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.FillProperty, fill);
            return obj;
        }
        
        public static T Fill<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.Brush>, ValueBuilder<Microsoft.Maui.Controls.Brush>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.Brush>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.FillProperty, builder.GetValue());
            return obj;
        }
        
        public static T Fill<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.Brush>, BindingBuilder<Microsoft.Maui.Controls.Brush>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.Brush>(obj, Microsoft.Maui.Controls.Shapes.Shape.FillProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Stroke<T>(this T obj,
            Microsoft.Maui.Controls.Brush stroke)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeProperty, stroke);
            return obj;
        }
        
        public static T Stroke<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.Brush>, ValueBuilder<Microsoft.Maui.Controls.Brush>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.Brush>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeProperty, builder.GetValue());
            return obj;
        }
        
        public static T Stroke<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.Brush>, BindingBuilder<Microsoft.Maui.Controls.Brush>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.Brush>(obj, Microsoft.Maui.Controls.Shapes.Shape.StrokeProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T StrokeThickness<T>(this T obj,
            double strokeThickness)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeThicknessProperty, strokeThickness);
            return obj;
        }
        
        public static T StrokeThickness<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeThicknessProperty, builder.GetValue());
            return obj;
        }
        
        public static T StrokeThickness<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidBinding(new BindingBuilder<double>(obj, Microsoft.Maui.Controls.Shapes.Shape.StrokeThicknessProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T StrokeDashArray<T>(this T obj,
            IList<double> strokeDashArray)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            foreach (var item in strokeDashArray)
                obj.StrokeDashArray.Add(item);
            return obj;
        }

        public static T StrokeDashArray<T>(this T obj,
            params double[] strokeDashArray)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            foreach (var item in strokeDashArray)
                obj.StrokeDashArray.Add(item);
            return obj;
        }
        
        public static T StrokeDashArray<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.DoubleCollection>, BindingBuilder<Microsoft.Maui.Controls.DoubleCollection>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.DoubleCollection>(obj, Microsoft.Maui.Controls.Shapes.Shape.StrokeDashArrayProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T StrokeDashOffset<T>(this T obj,
            double strokeDashOffset)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeDashOffsetProperty, strokeDashOffset);
            return obj;
        }
        
        public static T StrokeDashOffset<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeDashOffsetProperty, builder.GetValue());
            return obj;
        }
        
        public static T StrokeDashOffset<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidBinding(new BindingBuilder<double>(obj, Microsoft.Maui.Controls.Shapes.Shape.StrokeDashOffsetProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T StrokeLineCap<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.PenLineCap strokeLineCap)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeLineCapProperty, strokeLineCap);
            return obj;
        }
        
        public static T StrokeLineCap<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.Shapes.PenLineCap>, ValueBuilder<Microsoft.Maui.Controls.Shapes.PenLineCap>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.Shapes.PenLineCap>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeLineCapProperty, builder.GetValue());
            return obj;
        }
        
        public static T StrokeLineCap<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.Shapes.PenLineCap>, BindingBuilder<Microsoft.Maui.Controls.Shapes.PenLineCap>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.Shapes.PenLineCap>(obj, Microsoft.Maui.Controls.Shapes.Shape.StrokeLineCapProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T StrokeLineJoin<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.PenLineJoin strokeLineJoin)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeLineJoinProperty, strokeLineJoin);
            return obj;
        }
        
        public static T StrokeLineJoin<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.Shapes.PenLineJoin>, ValueBuilder<Microsoft.Maui.Controls.Shapes.PenLineJoin>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.Shapes.PenLineJoin>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeLineJoinProperty, builder.GetValue());
            return obj;
        }
        
        public static T StrokeLineJoin<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.Shapes.PenLineJoin>, BindingBuilder<Microsoft.Maui.Controls.Shapes.PenLineJoin>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.Shapes.PenLineJoin>(obj, Microsoft.Maui.Controls.Shapes.Shape.StrokeLineJoinProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T StrokeMiterLimit<T>(this T obj,
            double strokeMiterLimit)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeMiterLimitProperty, strokeMiterLimit);
            return obj;
        }
        
        public static T StrokeMiterLimit<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.StrokeMiterLimitProperty, builder.GetValue());
            return obj;
        }
        
        public static T StrokeMiterLimit<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidBinding(new BindingBuilder<double>(obj, Microsoft.Maui.Controls.Shapes.Shape.StrokeMiterLimitProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Aspect<T>(this T obj,
            Microsoft.Maui.Controls.Stretch aspect)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.AspectProperty, aspect);
            return obj;
        }
        
        public static T Aspect<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.Stretch>, ValueBuilder<Microsoft.Maui.Controls.Stretch>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.Stretch>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.Shape.AspectProperty, builder.GetValue());
            return obj;
        }
        
        public static T Aspect<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.Stretch>, BindingBuilder<Microsoft.Maui.Controls.Stretch>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.Shape
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.Stretch>(obj, Microsoft.Maui.Controls.Shapes.Shape.AspectProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore