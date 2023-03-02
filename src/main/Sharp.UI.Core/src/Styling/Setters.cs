using Sharp.UI.Internal;

namespace Sharp.UI
{
    public class Setters<T> : List<Setter>
        where T : BindableObject
	{
        public Setters(Func<T,T> styleElement)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                FluentStyling.Setters = this;
                styleElement?.Invoke(null);
                FluentStyling.Setters = null;
            });
        }
    }
}