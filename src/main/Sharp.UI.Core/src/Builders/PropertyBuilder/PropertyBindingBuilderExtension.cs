namespace Sharp.UI
{
    public static class PropertyBindingBuilderExtension
    {
        public static PropertyBindingBuilder<bool> Negate(this PropertyBindingBuilder<bool> self)
        {
            return self.Convert<bool>(e => !e).ConvertBack<bool>(e => !e);
        }
    }
}
