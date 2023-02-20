using System.Collections;

namespace Sharp.UI
{
	public static class IEnumerableExtension
	{
        public static void Add<T>(this T obj, Func<T, T> configure)
            where T : IEnumerable
        {
            configure(obj);
        }
    }
}

