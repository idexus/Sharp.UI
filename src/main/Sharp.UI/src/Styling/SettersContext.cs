
namespace Sharp.UI
{
    public class SettersContext<T> 
        where T :  BindableObject
	{
        public List<Setter> XamlSetters = new();
    }
}
