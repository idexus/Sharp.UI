namespace Sharp.UI
{
    public interface IWrappedBindableObject
    {
        public object BindingContext { get; set; }
    }

    public static class IWrappedBindableObjectExtension
    {
        public static T BindingContext<T>(this T obj, object bindingContext)
            where T : Sharp.UI.IWrappedBindableObject
        {
            if (bindingContext != null) obj.BindingContext = (object)bindingContext;
            return obj;
        }
    }
}
