namespace Sharp.UI
{
    public static partial class ViewExtension
    {
        public static T Column<T>(this T obj, int column) where T : BindableObject, IView
        {
            obj.SetValue(Microsoft.Maui.Controls.Grid.ColumnProperty, column);
            return obj;
        }

        public static T Row<T>(this T obj, int row) where T : BindableObject, IView
        {
            obj.SetValue(Microsoft.Maui.Controls.Grid.RowProperty, row);
            return obj;
        }

        public static T ColumnSpan<T>(this T obj, int columnSpan) where T : BindableObject, IView
        {
            obj.SetValue(Microsoft.Maui.Controls.Grid.ColumnSpanProperty, columnSpan);
            return obj;
        }

        public static T RowSpan<T>(this T obj, int rowSpan) where T : BindableObject, IView
        {
            obj.SetValue(Microsoft.Maui.Controls.Grid.RowSpanProperty, rowSpan);
            return obj;
        }

        public static T GridSpan<T>(this T obj, int column = 1, int row = 1) where T : BindableObject, IView
        {
            obj.SetValue(Microsoft.Maui.Controls.Grid.ColumnSpanProperty, column);
            obj.SetValue(Microsoft.Maui.Controls.Grid.RowSpanProperty, row);
            return obj;
        }
    }
}
