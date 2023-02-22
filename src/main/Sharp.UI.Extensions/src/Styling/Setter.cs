using Sharp.UI.Internal;

namespace Sharp.UI
{
    public class Setter<T> : List<Setter>
        where T : BindableObject
	{
        public Setter(Action<T> settersBuilder)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                FluentStyling.Setters = this;
                settersBuilder?.Invoke(null);
                FluentStyling.Setters = null;
            });
        }
    }
}