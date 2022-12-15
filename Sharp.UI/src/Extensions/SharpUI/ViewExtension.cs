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

    [SharpObject(typeof(Microsoft.Maui.Controls.View))]
    [AttachedInterfaces(new[] {typeof(IViewGridAttachedProperties) })]
    public static class ViewExtension
    {
        public static T GridSpan<T>(this T obj, int column = 1, int row = 1) where T : IView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(Grid.ColumnSpanProperty, column);
            mauiObject.SetValue(Grid.RowSpanProperty, row);
            return obj;
        }
    }
}
