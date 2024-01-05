namespace Sharp.UI
{
    public static class PublicExtension
    {
        public static T Assign<T>(this T self, out T obj) where T : Element { obj = self; return obj; }
        public static T InvokeOnElement<T>(this T self, Action<T> action) where T : Element { action(self); return self; }
    }
}
