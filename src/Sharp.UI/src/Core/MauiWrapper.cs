using System.Reflection;

namespace Sharp.UI
{
    public interface IMauiWrapper { }

    public interface ISealedMauiWrapper
    {
        public object _maui_RawObject { get; set; }
    }

    public class MauiWrapper
    {
        public static T Value<T>(object obj)
        {
            if (typeof(T) is ISealedMauiWrapper) return (T)obj;
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
}
