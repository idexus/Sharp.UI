﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class ShapeGeneratedExtension
    {
        public static T Fill<T>(this T obj,
            Microsoft.Maui.Controls.Brush? fill)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (fill != null) mauiObject.Fill = (Microsoft.Maui.Controls.Brush)fill;
            return obj;
        }
        
        public static T Fill<T>(this T obj,
            Microsoft.Maui.Controls.Brush? fill,
            Func<BindableDef<Microsoft.Maui.Controls.Brush>, BindableDef<Microsoft.Maui.Controls.Brush>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (fill != null) mauiObject.Fill = (Microsoft.Maui.Controls.Brush)fill;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Brush>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.FillProperty));
            if (def.ValueIsSet()) mauiObject.Fill = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Fill<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.Brush>, BindableDef<Microsoft.Maui.Controls.Brush>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Brush>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.FillProperty));
            if (def.ValueIsSet()) mauiObject.Fill = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Stroke<T>(this T obj,
            Microsoft.Maui.Controls.Brush? stroke)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (stroke != null) mauiObject.Stroke = (Microsoft.Maui.Controls.Brush)stroke;
            return obj;
        }
        
        public static T Stroke<T>(this T obj,
            Microsoft.Maui.Controls.Brush? stroke,
            Func<BindableDef<Microsoft.Maui.Controls.Brush>, BindableDef<Microsoft.Maui.Controls.Brush>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (stroke != null) mauiObject.Stroke = (Microsoft.Maui.Controls.Brush)stroke;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Brush>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeProperty));
            if (def.ValueIsSet()) mauiObject.Stroke = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Stroke<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.Brush>, BindableDef<Microsoft.Maui.Controls.Brush>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Brush>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeProperty));
            if (def.ValueIsSet()) mauiObject.Stroke = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeThickness<T>(this T obj,
            double? strokeThickness)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeThickness != null) mauiObject.StrokeThickness = (double)strokeThickness;
            return obj;
        }
        
        public static T StrokeThickness<T>(this T obj,
            double? strokeThickness,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeThickness != null) mauiObject.StrokeThickness = (double)strokeThickness;
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeThicknessProperty));
            if (def.ValueIsSet()) mauiObject.StrokeThickness = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeThickness<T>(this T obj,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeThicknessProperty));
            if (def.ValueIsSet()) mauiObject.StrokeThickness = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeDashArray<T>(this T obj,
            Microsoft.Maui.Controls.DoubleCollection? strokeDashArray)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeDashArray != null) mauiObject.StrokeDashArray = (Microsoft.Maui.Controls.DoubleCollection)strokeDashArray;
            return obj;
        }
        
        public static T StrokeDashArray<T>(this T obj,
            Microsoft.Maui.Controls.DoubleCollection? strokeDashArray,
            Func<BindableDef<Microsoft.Maui.Controls.DoubleCollection>, BindableDef<Microsoft.Maui.Controls.DoubleCollection>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeDashArray != null) mauiObject.StrokeDashArray = (Microsoft.Maui.Controls.DoubleCollection)strokeDashArray;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.DoubleCollection>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeDashArrayProperty));
            if (def.ValueIsSet()) mauiObject.StrokeDashArray = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeDashArray<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.DoubleCollection>, BindableDef<Microsoft.Maui.Controls.DoubleCollection>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.DoubleCollection>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeDashArrayProperty));
            if (def.ValueIsSet()) mauiObject.StrokeDashArray = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeDashOffset<T>(this T obj,
            double? strokeDashOffset)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeDashOffset != null) mauiObject.StrokeDashOffset = (double)strokeDashOffset;
            return obj;
        }
        
        public static T StrokeDashOffset<T>(this T obj,
            double? strokeDashOffset,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeDashOffset != null) mauiObject.StrokeDashOffset = (double)strokeDashOffset;
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeDashOffsetProperty));
            if (def.ValueIsSet()) mauiObject.StrokeDashOffset = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeDashOffset<T>(this T obj,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeDashOffsetProperty));
            if (def.ValueIsSet()) mauiObject.StrokeDashOffset = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeLineCap<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.PenLineCap? strokeLineCap)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeLineCap != null) mauiObject.StrokeLineCap = (Microsoft.Maui.Controls.Shapes.PenLineCap)strokeLineCap;
            return obj;
        }
        
        public static T StrokeLineCap<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.PenLineCap? strokeLineCap,
            Func<BindableDef<Microsoft.Maui.Controls.Shapes.PenLineCap>, BindableDef<Microsoft.Maui.Controls.Shapes.PenLineCap>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeLineCap != null) mauiObject.StrokeLineCap = (Microsoft.Maui.Controls.Shapes.PenLineCap)strokeLineCap;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Shapes.PenLineCap>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeLineCapProperty));
            if (def.ValueIsSet()) mauiObject.StrokeLineCap = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeLineCap<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.Shapes.PenLineCap>, BindableDef<Microsoft.Maui.Controls.Shapes.PenLineCap>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Shapes.PenLineCap>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeLineCapProperty));
            if (def.ValueIsSet()) mauiObject.StrokeLineCap = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeLineJoin<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.PenLineJoin? strokeLineJoin)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeLineJoin != null) mauiObject.StrokeLineJoin = (Microsoft.Maui.Controls.Shapes.PenLineJoin)strokeLineJoin;
            return obj;
        }
        
        public static T StrokeLineJoin<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.PenLineJoin? strokeLineJoin,
            Func<BindableDef<Microsoft.Maui.Controls.Shapes.PenLineJoin>, BindableDef<Microsoft.Maui.Controls.Shapes.PenLineJoin>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeLineJoin != null) mauiObject.StrokeLineJoin = (Microsoft.Maui.Controls.Shapes.PenLineJoin)strokeLineJoin;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Shapes.PenLineJoin>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeLineJoinProperty));
            if (def.ValueIsSet()) mauiObject.StrokeLineJoin = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeLineJoin<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.Shapes.PenLineJoin>, BindableDef<Microsoft.Maui.Controls.Shapes.PenLineJoin>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Shapes.PenLineJoin>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeLineJoinProperty));
            if (def.ValueIsSet()) mauiObject.StrokeLineJoin = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeMiterLimit<T>(this T obj,
            double? strokeMiterLimit)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeMiterLimit != null) mauiObject.StrokeMiterLimit = (double)strokeMiterLimit;
            return obj;
        }
        
        public static T StrokeMiterLimit<T>(this T obj,
            double? strokeMiterLimit,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (strokeMiterLimit != null) mauiObject.StrokeMiterLimit = (double)strokeMiterLimit;
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeMiterLimitProperty));
            if (def.ValueIsSet()) mauiObject.StrokeMiterLimit = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T StrokeMiterLimit<T>(this T obj,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.StrokeMiterLimitProperty));
            if (def.ValueIsSet()) mauiObject.StrokeMiterLimit = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Aspect<T>(this T obj,
            Microsoft.Maui.Controls.Stretch? aspect)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (aspect != null) mauiObject.Aspect = (Microsoft.Maui.Controls.Stretch)aspect;
            return obj;
        }
        
        public static T Aspect<T>(this T obj,
            Microsoft.Maui.Controls.Stretch? aspect,
            Func<BindableDef<Microsoft.Maui.Controls.Stretch>, BindableDef<Microsoft.Maui.Controls.Stretch>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            if (aspect != null) mauiObject.Aspect = (Microsoft.Maui.Controls.Stretch)aspect;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Stretch>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.AspectProperty));
            if (def.ValueIsSet()) mauiObject.Aspect = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Aspect<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.Stretch>, BindableDef<Microsoft.Maui.Controls.Stretch>> definition)
            where T : Sharp.UI.IShape
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Stretch>(mauiObject, Microsoft.Maui.Controls.Shapes.Shape.AspectProperty));
            if (def.ValueIsSet()) mauiObject.Aspect = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669