using System.Collections;
using System.Reflection;
using System.Xml.Linq;

namespace Sharp.UI
{

    public interface IWrappedBindableObject
    {
        public object BindingContext { get; set; }
    }

    public interface ISealedMauiWrapper
    {
        public object _maui_RawObject { get; set; }
    }

    public class MauiWrapper
    {
        public static T GetObject<T>(object obj)
        {
            if (obj is ISealedMauiWrapper)
                return (T)((obj as ISealedMauiWrapper)._maui_RawObject);
            else
                return (T)obj;
        }

        public static Type GetMauiType<T>()
        {
            var mauiObjectMember = typeof(T).GetMember("MauiObject").FirstOrDefault();
            if (mauiObjectMember != null)
                return ((PropertyInfo)mauiObjectMember).PropertyType;
            else
                return typeof(T);
        }
    }

    public delegate void OnEventAction<TObj,TArgs>(TObj sender, TArgs args);
    public delegate void OnEventAction<TObj>(TObj sender);

    public static class ObjectSharpUIExtension
    {
        public static T Assign<T>(this T _element, out T element) { element = _element; return element; }
        public static T Invoke<T>(this T element, Action<T> action) { action(element); return element; }
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
