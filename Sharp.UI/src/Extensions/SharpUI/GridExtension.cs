using System.Collections;

namespace Sharp.UI
{

    public static class GridExtension
    {
        public static T RowDefinitions<T>(this T obj, RowDefinitions rowDefs) where T : IGrid
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Grid>(obj);
            foreach (var rowDef in rowDefs) mauiObject.RowDefinitions.Add(rowDef);
            return obj;
        }

        public static T RowDefinitions<T>(this T obj, Func<RowDefinitions, RowDefinitions> definitionBuilder) where T : IGrid
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Grid>(obj);
            var rowDefs = definitionBuilder(new RowDefinitions());
            foreach (var rowDef in rowDefs) mauiObject.RowDefinitions.Add(rowDef);
            return obj;
        }

        public static T ColumnDefinitions<T>(this T obj, ColumnDefinitions colDefs) where T : IGrid
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Grid>(obj);
            foreach (var colDef in colDefs) mauiObject.ColumnDefinitions.Add(colDef);
            return obj;
        }

        public static T ColumnDefinitions<T>(this T obj, Func<ColumnDefinitions, ColumnDefinitions> definitionBuilder) where T : IGrid
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Grid>(obj);
            var colDefs = definitionBuilder(new ColumnDefinitions());
            foreach (var colDef in colDefs) mauiObject.ColumnDefinitions.Add(colDef);
            return obj;
        }
    }
}
