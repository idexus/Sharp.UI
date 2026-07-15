using Microsoft.Maui.Layouts;
using Sharp.UI.Internal;

namespace Sharp.UI
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

        public Setters(string targetName, Func<SettersContext<T>, SettersContext<T>> buildSetters)
        {
            var settersContext = new SettersContext<T>();
            buildSetters(settersContext);
            foreach (var setter in settersContext.XamlSetters)
                this.Add(setter);

            this.TargetName(targetName);
        }
    }
}