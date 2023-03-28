
namespace CodeMarkup.Maui
{
    public class SettersContext<T> 
        where T :  BindableObject
	{
        public List<Setter> XamlSetters = new();
    }
}
