namespace Sharp.UI
{
    public static class BorderExtension
    {
#nullable enable
        public static T StrokeShape<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.Shape? strokeShape)
            where T : IBorder
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Border>(obj);
            if (strokeShape != null) mauiObject.StrokeShape = (Microsoft.Maui.Controls.Shapes.Shape?)strokeShape;
            return obj;
        }

        public static T StrokeShape<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.Shape? strokeShape,
            Func<BindableDef<Microsoft.Maui.Controls.Shapes.Shape?>, BindableDef<Microsoft.Maui.Graphics.IShape?>> definition)
            where T : IBorder
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Border>(obj);
            if (strokeShape != null) mauiObject.StrokeShape = (Microsoft.Maui.Graphics.IShape?)strokeShape;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Shapes.Shape?>(mauiObject, Microsoft.Maui.Controls.Border.StrokeShapeProperty));
            if (def.ValueIsSet()) mauiObject.StrokeShape = def.GetValue();
            def.BindProperty();
            return obj;
        }

        public static T StrokeShape<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.Shapes.Shape?>, BindableDef<Microsoft.Maui.Graphics.IShape?>> definition)
            where T : IBorder
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Border>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.Shapes.Shape?>(mauiObject, Microsoft.Maui.Controls.Border.StrokeShapeProperty));
            if (def.ValueIsSet()) mauiObject.StrokeShape = def.GetValue();
            def.BindProperty();
            return obj;
        }
#nullable restore
    }
}