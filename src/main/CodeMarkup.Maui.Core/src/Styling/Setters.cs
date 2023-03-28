using CodeMarkup.Maui.Internal;

namespace CodeMarkup.Maui
{
    public class Setters<T> : List<Setter>
        where T : BindableObject
	{
        public Setters(Func<SettersContext<T>, SettersContext<T>> buildSetters)
        {
            var settersContext = new SettersContext<T>();
            buildSetters(settersContext);
            foreach (var setter in settersContext.XamlSetters)
                this.Add(setter);
        }
    }
}