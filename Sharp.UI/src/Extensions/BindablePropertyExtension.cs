namespace Sharp.UI
{
    public static class BindablePropertyExtension
    {
        public static Setter Set(this BindableProperty property, object value)
        {
            return new Setter(property, value);
        }

        public static Setter Set(this BindableProperty property)
        {
            return new Setter(property);
        }
    }
}