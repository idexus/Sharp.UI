using System;
namespace Sharp.UI
{
	public static class IListExtension
	{
        public static void Add<T>(this T list, Action<IList<IView>> itemsBuilder)
            where T : IList<IView>
        {
            List<IView> items = new List<IView>();
            itemsBuilder(items);
            foreach (var item in items)
                list.Add(item);
        }
    }
}