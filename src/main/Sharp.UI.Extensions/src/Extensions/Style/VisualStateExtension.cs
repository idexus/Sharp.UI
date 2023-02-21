namespace Sharp.UI
{
    public static partial class VisualStateExtension
    {
        public static Microsoft.Maui.Controls.VisualState Setters(this Microsoft.Maui.Controls.VisualState obj,
            params IList<Setter>[] setterGropus)
        {
            foreach (var group in setterGropus)
                foreach (var setter in group)
                    obj.Setters.Add(setter);
            return obj;
        }
    }
}