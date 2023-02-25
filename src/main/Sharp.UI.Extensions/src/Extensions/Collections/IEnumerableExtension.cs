using System.Collections;

namespace Sharp.UI
{
	public static class IEnumerableExtension
	{
        public static void Add<T>(this T self, Action<T> configure)
            where T : IEnumerable
        {
            configure(self);
        }
    }
}

