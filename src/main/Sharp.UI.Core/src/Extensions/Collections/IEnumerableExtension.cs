using System.Collections;

namespace Sharp.UI
{
	public static partial class IEnumerableExtension
	{
        public static void Add<T>(this T self, Func<T, T> configure)
            where T : BindableObject, IEnumerable
        {
            configure(self);
        }

        public static void Add<T>(this T self, Action<T> configure)
            where T : Layout, IEnumerable
        {
            configure(self);
        }
    }
}
