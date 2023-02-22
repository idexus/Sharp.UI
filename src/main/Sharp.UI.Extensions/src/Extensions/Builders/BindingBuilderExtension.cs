namespace Sharp.UI
{
    public static class BindingBuilderExtension
    {
        public static BindingBuilder<bool> Negate(this BindingBuilder<bool> self)
        {
            return self.Convert<bool>(e => !e).ConvertBack<bool>(e => !e);
        }
    }
}
