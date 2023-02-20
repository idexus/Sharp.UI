namespace Sharp.UI
{
    public static class BindablePropertyExtension
    {
        public static Setter Set(this BindableProperty property, object value) => new Setter { Property = property, Value = value };
        public static Setter Set(this BindableProperty property) => new Setter { Property = property };
    }
}