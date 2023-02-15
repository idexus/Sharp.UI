using System.Collections;

namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.DataTemplate))]
    public partial class DataTemplate : IEnumerable
    {
        static object getValue(System.Func<object> loadValue)
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
            return MauiWrapper.Value<object>(value);
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
            base.LoadTemplate = () =>
            {
                if (Application.HotReloadIsEnabled)
                {
                    var typeName = type.FullName;
                    if (HotReload.ReplacedTypesDict.TryGetValue(typeName, out var replacedType))
                    {
                        type = replacedType;
                    }
                }

                var value = ActivatorUtilities.CreateInstance(Application.Services, type);
                return MauiWrapper.Value<object>(value);
            };
        }

        public IEnumerator GetEnumerator() { yield return this.LoadTemplate; }
        public void Add(System.Func<object> loadTemplate) => this.LoadTemplate = loadTemplate;
    }

    public class DataTemplate<T> : DataTemplate
    {
        public DataTemplate(System.Func<T> loadTemplate)
            : base(() => loadTemplate())
        {
        }

        public new T CreateContent() => (T)base.CreateContent();
    }
}