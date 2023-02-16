namespace Sharp.UI
{
    public static class BorderExtension
    {
#nullable enable
        public static T StrokeShape<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.Shape? strokeShape)
            where T : Sharp.UI.IBorder
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Border>(obj);
            mauiObject.StrokeShape = (Microsoft.Maui.Controls.Shapes.Shape?)strokeShape;
            return obj;
        }

        public static T StrokeShape<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.Shapes.Shape?>, ValueBuilder<Microsoft.Maui.Controls.Shapes.Shape?>> buildValue)
            where T : Sharp.UI.IBorder
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Border>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.Shapes.Shape?>());
            if (builder.ValueIsSet()) mauiObject.StrokeShape = builder.GetValue();
            return obj;
        }

        //public static T StrokeShape<T>(this T obj,
        //    System.Func<LazyValueBuilder<Microsoft.Maui.Controls.Shapes.Shape?>, LazyValueBuilder<Microsoft.Maui.Controls.Shapes.Shape?>> buildValue)
        //    where T : Sharp.UI.IBorder
        //{
        //    var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Border>(obj);
        //    var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.Shapes.Shape?>());
        //    if (builder.ValueIsSet()) mauiObject.StrokeShape = builder.GetValue();
        //    return obj;
        //}

        public static T StrokeShape<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.Shapes.Shape?>, BindingBuilder<Microsoft.Maui.Controls.Shapes.Shape?>> buildBinding)
            where T : Sharp.UI.IBorder
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Border>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Controls.Shapes.Shape?>(mauiObject, Microsoft.Maui.Controls.Border.StrokeShapeProperty));
            builder.BindProperty();
            return obj;
        }
#nullable restore
    }
}