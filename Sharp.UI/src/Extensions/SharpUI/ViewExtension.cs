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
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.View>(obj);
            mauiObject.SetValue(Grid.ColumnSpanProperty, column);
            mauiObject.SetValue(Grid.RowSpanProperty, row);
            return obj;
        }

        public static T GestureRecognizers<T>(this T obj,
                    System.Collections.Generic.IList<Sharp.UI.IGestureRecognizer> gestureRecognizers)
                    where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.View>(obj);
            foreach (var item in gestureRecognizers)
            {
                var mauiItem = MauiWrapper.GetObject<Microsoft.Maui.Controls.IGestureRecognizer>(item);
                mauiObject.GestureRecognizers.Add(mauiItem);
            }
            return obj;
        }

        public static T GestureRecognizers<T>(this T obj,
            params Sharp.UI.IGestureRecognizer[] gestureRecognizers)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.View>(obj);
            foreach (var item in gestureRecognizers)
            {
                var mauiItem = MauiWrapper.GetObject<Microsoft.Maui.Controls.IGestureRecognizer>(item);
                mauiObject.GestureRecognizers.Add(mauiItem);
            }
            return obj;
        }

        public static T GestureRecognizers<T>(this T obj,
            System.Func<Def<System.Collections.Generic.IList<Sharp.UI.IGestureRecognizer>>, Def<System.Collections.Generic.IList<Sharp.UI.IGestureRecognizer>>> definition)
            where T : Sharp.UI.IView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.View>(obj);
            var def = definition(new Def<System.Collections.Generic.IList<Sharp.UI.IGestureRecognizer>>());
            if (def.ValueIsSet())
            {
                var items = def.GetValue();
                foreach (var item in items)
                {
                    var mauiItem = MauiWrapper.GetObject<Microsoft.Maui.Controls.IGestureRecognizer>(item);
                    mauiObject.GestureRecognizers.Add(mauiItem);
                }
            }
            return obj;
        }
    }
}
