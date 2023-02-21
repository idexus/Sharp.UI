namespace Sharp.UI
{
    public static partial class LayoutExtension
	{
        public static void Add<T>(this T layout, IEnumerable<View> items)
            where T : Layout
        {
            foreach (var item in items)
                layout.Children.Add(item);
        }
    }
}

