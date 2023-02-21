namespace Sharp.UI
{
    public static class BindablePropertyExtension
    {
        [Obsolete("Use Style<T>(e => e.Property()) or Setter<T>(e => e.Property()) instead")]
        public static Setter Set(this BindableProperty property, object value) => new Setter { Property = property, Value = value };
        [Obsolete("Use Style<T>(e => e.Property()) or Setter<T>(e => e.Property()) instead")]
        public static Setter Set(this BindableProperty property) => new Setter { Property = property };
    }
}