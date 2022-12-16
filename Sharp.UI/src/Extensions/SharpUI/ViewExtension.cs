namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.Grid))]
    public interface IViewGridAttachedProperties
    {
        int Column { get; set; }
        int Row { get; set; }
        int ColumnSpan { get; set; }
        int RowSpan { get; set; }
    }

    [AttachedProperties(typeof(Microsoft.Maui.Controls.AbsoluteLayout))]
    public interface IViewAbsoluteLayoutProperties
    {
        [AttachedName("LayoutFlags")]
        Microsoft.Maui.Layouts.AbsoluteLayoutFlags AbsoluteLayoutFlags { get; set; }

        [AttachedName("LayoutBounds")]
        Microsoft.Maui.Graphics.Rect AbsoluteLayoutBounds { get; set; }
    }
    
    [SharpObject(typeof(Microsoft.Maui.Controls.View))]
    [AttachedInterfaces(new[] {typeof(IViewGridAttachedProperties), typeof(IViewAbsoluteLayoutProperties) })]
    public static class ViewExtension
    {
        public static T GridSpan<T>(this T obj, int column = 1, int row = 1) where T : IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(Grid.ColumnSpanProperty, column);
            mauiObject.SetValue(Grid.RowSpanProperty, row);
            return obj;
        }

        public static T GestureRecognizers<T, TItem>(this T obj,
            TItem item)
            where T : Sharp.UI.IView
            where TItem : Sharp.UI.IGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            var mauiItem = MauiWrapper.Value<Microsoft.Maui.Controls.IGestureRecognizer>(item);
            mauiObject.GestureRecognizers.Add(mauiItem);
            return obj;
        }
    }
}
