using System.Collections;

namespace Sharp.UI
{
    public static partial class GridExtension
    {
        public static T RowDefinitions<T>(this T obj, RowDefinitionBuilder builder)
            where T : Microsoft.Maui.Controls.Grid
        {
            foreach (var rowDef in builder)
                obj.RowDefinitions.Add(rowDef);
            return obj;
        }

        public static T RowDefinitions<T>(this T obj, System.Func<RowDefinitionBuilder, RowDefinitionBuilder> build)
            where T : Microsoft.Maui.Controls.Grid
        {
            var rowDefs = build(new RowDefinitionBuilder());
            foreach (var rowDef in rowDefs)
                obj.RowDefinitions.Add(rowDef);
            return obj;
        }

        public static T ColumnDefinitions<T>(this T obj, ColumnDefinitionBuilder builder)
            where T : Microsoft.Maui.Controls.Grid
        {
            foreach (var colDef in builder)
                obj.ColumnDefinitions.Add(colDef);
            return obj;
        }

        public static T ColumnDefinitions<T>(this T obj, System.Func<ColumnDefinitionBuilder, ColumnDefinitionBuilder> build)
            where T : Microsoft.Maui.Controls.Grid
        {
            var colDefs = build(new ColumnDefinitionBuilder());
            foreach (var colDef in colDefs)
                obj.ColumnDefinitions.Add(colDef);
            return obj;
        }
    }
}
