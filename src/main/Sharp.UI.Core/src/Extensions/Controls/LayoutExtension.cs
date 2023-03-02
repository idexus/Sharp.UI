namespace Sharp.UI
{
    public static partial class LayoutExtension
	{
        public static void Add<T>(this T self, IEnumerable<View> items)
            where T : Layout
        {
            foreach (var item in items)
                self.Children.Add(item);
        }
    }
}

