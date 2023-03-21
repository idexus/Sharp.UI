namespace CodeMarkup.Maui
{
    public static partial class VisualStateExtension
    {
        public static VisualState Setters(this VisualState self,
            params IList<Setter>[] setterGroups)
        {
            foreach (var group in setterGroups)
                foreach (var setter in group)
                    self.Setters.Add(setter);
            return self;
        }
    }
}