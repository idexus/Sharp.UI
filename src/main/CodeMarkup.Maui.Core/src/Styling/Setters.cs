using CodeMarkup.Maui.Internal;

namespace CodeMarkup.Maui
{
    public class Setters<T> : List<Setter>
        where T : BindableObject
	{
        public Setters(Func<T,T> buildSetters)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                FluentStyling.Setters = this;
                buildSetters?.Invoke(null);
                FluentStyling.Setters = null;
            });
        }
    }
}