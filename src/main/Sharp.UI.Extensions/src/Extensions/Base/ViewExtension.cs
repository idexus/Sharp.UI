using System.Collections;

namespace Sharp.UI
{
    public static partial class ViewExtension
    {
        public static T Column<T>(this T obj, int column) where T : BindableObject, IView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Grid.ColumnProperty, column);
            return obj;
        }

        public static T Row<T>(this T obj, int row) where T : BindableObject, IView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Grid.RowProperty, row);
            return obj;
        }

        public static T ColumnSpan<T>(this T obj, int columnSpan) where T : BindableObject, IView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Grid.ColumnSpanProperty, columnSpan);
            return obj;
        }

        public static T RowSpan<T>(this T obj, int rowSpan) where T : BindableObject, IView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Grid.RowSpanProperty, rowSpan);
            return obj;
        }

        public static T GridSpan<T>(this T obj, int column = 1, int row = 1) where T : BindableObject, IView
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Grid.ColumnSpanProperty, column);
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Grid.RowSpanProperty, row);
            return obj;
        }

        // Layout

        public static T CenterHorizontally<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Center);
            return obj;
        }

        public static T CenterVertically<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Center);
            return obj;
        }

        public static T CenterInParent<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Center);
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Center);
            return obj;
        }

        public static T AlignTop<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Start);
            return obj;
        }

        public static T AlignTopStart<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Start);
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Start);
            return obj;
        }

        public static T AlignTopEnd<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.End);
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Start);
            return obj;
        }

        public static T AlignBottom<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.End);
            return obj;
        }

        public static T AlignBottomStart<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Start);
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.End);
            return obj;
        }

        public static T AlignBottomEnd<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.End);
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.End);
            return obj;
        }

        public static T AlignStart<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Start);
            return obj;
        }

        public static T AlignEnd<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.End);
            return obj;
        }

        public static T FillHorizontally<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Fill);
            return obj;
        }

        public static T FillVertically<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Fill);
            return obj;
        }

        public static T FillBothDirections<T>(this T obj)
            where T : Microsoft.Maui.Controls.View
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Fill);
            obj.SetValueOrSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Fill);
            return obj;
        }
    }
}
