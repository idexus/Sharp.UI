using System.Collections;
using System.Security.AccessControl;

namespace Sharp.UI
{
    [SharpObject]
    public partial class DataTemplate : Microsoft.Maui.Controls.DataTemplate, IEnumerable
    {
        public static T Activate<T>(Type type) 
        {
            if (!type.IsAssignableTo(typeof(T))) throw new ArgumentException($"Type {type} is not assignable to {typeof(T)}");
            if (Application.HotReloadIsEnabled)
            {
                var typeName = type.FullName;
                if (HotReload.ReplacedTypesDict.TryGetValue(typeName, out var replacedType))
                {
                    type = replacedType;
                }
            }

            return (T)ActivatorUtilities.CreateInstance(Application.Services, type);
        }

        object getValue(System.Func<object> loadValue)
        {
            object value = loadValue();
            if (Application.HotReloadIsEnabled)
            {
                var typeName = value.GetType().FullName;
                if (HotReload.ReplacedTypesDict.TryGetValue(typeName, out var replacedType))
                {
                    value = ActivatorUtilities.CreateInstance(Application.Services, replacedType);
                }
            }
            return value;
        }

        public new System.Func<object> LoadTemplate
        {
            get => base.LoadTemplate;
            set => base.LoadTemplate = () => getValue(value);
        }

        public DataTemplate(System.Func<object> loadTemplate)
        {
            base.LoadTemplate = () => getValue(loadTemplate);
        }

        public DataTemplate(Type type)
        {            
            base.LoadTemplate = () => Activate<object>(type);         
        }

        public IEnumerator GetEnumerator() { yield return this.LoadTemplate; }
        public void Add(System.Func<object> loadTemplate) => this.LoadTemplate = loadTemplate;
    }

    //public class DataTemplate<T> : DataTemplate
    //{
    //    public DataTemplate(System.Func<T> loadTemplate)
    //        : base(() => loadTemplate())
    //    {
    //    }

    //    public new T CreateContent() => (T)base.CreateContent();
    //}
}