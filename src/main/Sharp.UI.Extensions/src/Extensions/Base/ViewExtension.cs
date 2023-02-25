using System.Collections;

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
        [AttachedName("LayoutFlagsProperty")]
        Microsoft.Maui.Layouts.AbsoluteLayoutFlags AbsoluteLayoutFlags { get; set; }

        [AttachedName("LayoutBoundsProperty")]
        Microsoft.Maui.Graphics.Rect AbsoluteLayoutBounds { get; set; }
    }

    [AttachedInterfaces(typeof(Microsoft.Maui.Controls.View), new[] { typeof(IViewGridAttachedProperties), typeof(IViewAbsoluteLayoutProperties) })]
    public static partial class ViewExtension
    {
        public static T GridSpan<T>(this T self, int column = 1, int row = 1) where T : BindableObject, IView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Grid.ColumnSpanProperty, column);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Grid.RowSpanProperty, row);
            return self;
        }

        // Layout

        public static T CenterHorizontally<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Center);
            return self;
        }

        public static T CenterVertically<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Center);
            return self;
        }

        public static T CenterInContainer<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Center);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Center);
            return self;
        }

        public static T AlignTop<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Start);
            return self;
        }

        public static T AlignTopStart<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Start);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Start);
            return self;
        }

        public static T AlignTopEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Start);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.End);
            return self;
        }

        public static T AlignBottom<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.End);
            return self;
        }

        public static T AlignBottomStart<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.End);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Start);
            return self;
        }

        public static T AlignBottomEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.End);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.End);
            return self;
        }

        public static T AlignStart<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Start);
            return self;
        }

        public static T AlignEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.End);
            return self;
        }

        public static T FillHorizontally<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Fill);
            return self;
        }

        public static T FillVertically<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Fill);
            return self;
        }

        public static T FillBothDirections<T>(this T self)
            where T : Microsoft.Maui.Controls.View
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.HorizontalOptionsProperty, LayoutOptions.Fill);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.View.VerticalOptionsProperty, LayoutOptions.Fill);
            return self;
        }
    }
}
