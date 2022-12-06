namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.View),
        attachedProperties: new[] { "Grid.Column", "Grid.Row" },
        attachedPropertiesTypes: new[] { typeof(int), typeof(int) })]
    public static class IViewExtension
    {
        public static T Span<T>(this T obj, int column = 1, int row = 1) where T : IView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(Grid.ColumnSpanProperty, column);
            mauiObject.SetValue(Grid.RowSpanProperty, row);
            return obj;
        }
    }
}
