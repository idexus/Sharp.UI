namespace CodeMarkup.Maui
{
    public static partial class SetterListExtension
    {
        public static T TargetName<T>(this T self, string targetName)
            where T : IList<Setter>
        {
            foreach (var setter in self)
                setter.TargetName = targetName;
            return self;
        }
    }
}