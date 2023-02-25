using System.Collections;

namespace Sharp.UI
{
    public static partial class GridExtension
    {
        public static T RowDefinitions<T>(this T self, RowDefinitionBuilder builder)
            where T : Microsoft.Maui.Controls.Grid
        {
            foreach (var rowDef in builder)
                self.RowDefinitions.Add(rowDef);
            return self;
        }

        public static T RowDefinitions<T>(this T self, System.Func<RowDefinitionBuilder, RowDefinitionBuilder> build)
            where T : Microsoft.Maui.Controls.Grid
        {
            var rowDefs = build(new RowDefinitionBuilder());
            foreach (var rowDef in rowDefs)
                self.RowDefinitions.Add(rowDef);
            return self;
        }

        public static T ColumnDefinitions<T>(this T self, ColumnDefinitionBuilder builder)
            where T : Microsoft.Maui.Controls.Grid
        {
            foreach (var colDef in builder)
                self.ColumnDefinitions.Add(colDef);
            return self;
        }

        public static T ColumnDefinitions<T>(this T self, System.Func<ColumnDefinitionBuilder, ColumnDefinitionBuilder> build)
            where T : Microsoft.Maui.Controls.Grid
        {
            var colDefs = build(new ColumnDefinitionBuilder());
            foreach (var colDef in colDefs)
                self.ColumnDefinitions.Add(colDef);
            return self;
        }
    }
}
