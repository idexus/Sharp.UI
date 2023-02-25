namespace Sharp.UI
{
    public static class PublicExtension
    {
        public static T Assign<T>(this T self, out T obj) { obj = self; return obj; }
        public static T InvokeOn<T>(this T self, Action<T> action) { action(self); return self; }
    }
}
