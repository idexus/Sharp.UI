﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class PathGeometryGeneratedExtension
    {
        public static T Figures<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.PathFigureCollection figures)
            where T : Sharp.UI.IPathGeometry
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PathGeometry>(obj);
            mauiObject.Figures = (Microsoft.Maui.Controls.Shapes.PathFigureCollection)figures;
            return obj;
        }
        
        public static T Figures<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.Shapes.PathFigureCollection>, ValueBuilder<Microsoft.Maui.Controls.Shapes.PathFigureCollection>> buildValue)
            where T : Sharp.UI.IPathGeometry
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PathGeometry>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.Shapes.PathFigureCollection>());
            if (builder.ValueIsSet()) mauiObject.Figures = builder.GetValue();
            return obj;
        }
        
        public static T Figures<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Controls.Shapes.PathFigureCollection>, LazyValueBuilder<Microsoft.Maui.Controls.Shapes.PathFigureCollection>> buildValue)
            where T : Sharp.UI.IPathGeometry
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PathGeometry>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.Shapes.PathFigureCollection>());
            if (builder.ValueIsSet()) mauiObject.Figures = builder.GetValue();
            return obj;
        }
        
        public static T Figures<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.Shapes.PathFigureCollection>, BindingBuilder<Microsoft.Maui.Controls.Shapes.PathFigureCollection>> buildBinding)
            where T : Sharp.UI.IPathGeometry
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PathGeometry>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Controls.Shapes.PathFigureCollection>(mauiObject, Microsoft.Maui.Controls.Shapes.PathGeometry.FiguresProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T FillRule<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.FillRule fillRule)
            where T : Sharp.UI.IPathGeometry
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PathGeometry>(obj);
            mauiObject.FillRule = (Microsoft.Maui.Controls.Shapes.FillRule)fillRule;
            return obj;
        }
        
        public static T FillRule<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.Shapes.FillRule>, ValueBuilder<Microsoft.Maui.Controls.Shapes.FillRule>> buildValue)
            where T : Sharp.UI.IPathGeometry
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PathGeometry>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.Shapes.FillRule>());
            if (builder.ValueIsSet()) mauiObject.FillRule = builder.GetValue();
            return obj;
        }
        
        public static T FillRule<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Controls.Shapes.FillRule>, LazyValueBuilder<Microsoft.Maui.Controls.Shapes.FillRule>> buildValue)
            where T : Sharp.UI.IPathGeometry
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PathGeometry>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.Shapes.FillRule>());
            if (builder.ValueIsSet()) mauiObject.FillRule = builder.GetValue();
            return obj;
        }
        
        public static T FillRule<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.Shapes.FillRule>, BindingBuilder<Microsoft.Maui.Controls.Shapes.FillRule>> buildBinding)
            where T : Sharp.UI.IPathGeometry
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PathGeometry>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Controls.Shapes.FillRule>(mauiObject, Microsoft.Maui.Controls.Shapes.PathGeometry.FillRuleProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669