﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class PolyLineSegmentGeneratedExtension
    {
        public static T Points<T>(this T obj,
            Microsoft.Maui.Controls.PointCollection points)
            where T : Sharp.UI.IPolyLineSegment
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PolyLineSegment>(obj);
            mauiObject.Points = (Microsoft.Maui.Controls.PointCollection)points;
            return obj;
        }
        
        public static T Points<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.PointCollection>, ValueBuilder<Microsoft.Maui.Controls.PointCollection>> buildValue)
            where T : Sharp.UI.IPolyLineSegment
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PolyLineSegment>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.PointCollection>());
            if (builder.ValueIsSet()) mauiObject.Points = builder.GetValue();
            return obj;
        }
        
        public static T Points<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Controls.PointCollection>, LazyValueBuilder<Microsoft.Maui.Controls.PointCollection>> buildValue)
            where T : Sharp.UI.IPolyLineSegment
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PolyLineSegment>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.PointCollection>());
            if (builder.ValueIsSet()) mauiObject.Points = builder.GetValue();
            return obj;
        }
        
        public static T Points<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.PointCollection>, BindingBuilder<Microsoft.Maui.Controls.PointCollection>> buildBinding)
            where T : Sharp.UI.IPolyLineSegment
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Shapes.PolyLineSegment>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Controls.PointCollection>(mauiObject, Microsoft.Maui.Controls.Shapes.PolyLineSegment.PointsProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669