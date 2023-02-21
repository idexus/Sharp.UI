using Sharp.UI.Internal;

namespace Sharp.UI
{
    public class Setter<T> : List<Setter>
        where T : BindableObject
	{
        public Setter(Action<T> configure)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                FluentStyling.Setters = this;
                configure?.Invoke(null);
                FluentStyling.Setters = null;
            });
        }
    }
}