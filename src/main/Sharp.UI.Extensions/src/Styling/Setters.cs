using Sharp.UI.Internal;

namespace Sharp.UI
{
    public class Setters<T> : List<Setter>
        where T : BindableObject
	{
        public Setters(Action<T> settersBuilder)
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