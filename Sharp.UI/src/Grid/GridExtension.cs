using System.Collections;

namespace Sharp.UI
{

    public static class GridExtension
    {
        public static T Column<T>(this T obj, int column) where T : IView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(Grid.ColumnProperty, column);
            return obj;
        }

        public static T Row<T>(this T obj, int row) where T : IView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(Grid.RowProperty, row);
            return obj;
        }

        public static T Span<T>(this T obj, int column = 1, int row = 1) where T : IView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(Grid.ColumnSpanProperty, column);
            mauiObject.SetValue(Grid.RowSpanProperty, row);
            return obj;
        }

        public static T RowDefinitions<T>(this T obj, RowDefinitions rowDefs) where T : IGrid
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Grid>(obj);
            foreach (var rowDef in rowDefs) mauiObject.RowDefinitions.Add(rowDef);
            return obj;
        }

        public static T RowDefinitions<T>(this T obj, Func<RowDefinitions, RowDefinitions> definitionBuilder) where T : IGrid
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Grid>(obj);
            var rowDefs = definitionBuilder(new RowDefinitions());
            foreach (var rowDef in rowDefs) mauiObject.RowDefinitions.Add(rowDef);
            return obj;
        }

        public static T ColumnDefinitions<T>(this T obj, ColumnDefinitions colDefs) where T : Grid
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Grid>(obj);
            foreach (var colDef in colDefs) mauiObject.ColumnDefinitions.Add(colDef);
            return obj;
        }

        public static T ColumnDefinitions<T>(this T obj, Func<ColumnDefinitions, ColumnDefinitions> definitionBuilder) where T : IGrid
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Grid>(obj);
            var colDefs = definitionBuilder(new ColumnDefinitions());
            foreach (var colDef in colDefs) mauiObject.ColumnDefinitions.Add(colDef);
            return obj;
        }
    }
}
