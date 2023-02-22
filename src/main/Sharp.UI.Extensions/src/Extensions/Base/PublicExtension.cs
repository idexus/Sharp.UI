namespace Sharp.UI
{
    public static class PublicExtension
    {
        public static T Assign<T>(this T _element, out T element) { element = _element; return element; }
        public static T Invoke<T>(this T element, Action<T> action) { action(element); return element; }

        [Obsolete("use Invoke(action) instead")]
        public static T Configure<T>(this T element, Action<T> action) { action(element); return element; }
    }
}
