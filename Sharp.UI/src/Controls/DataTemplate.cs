using System.Collections;

namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.DataTemplate))]
    public partial class DataTemplate : IEnumerable
    {
        public new System.Func<object> LoadTemplate { get => base.LoadTemplate; set => base.LoadTemplate = () => MauiWrapper.Value<object>(value()); }

        public DataTemplate(System.Func<object> loadTemplate)
            : base(() => MauiWrapper.Value<object>(loadTemplate()))
        {
        }

        public IEnumerator GetEnumerator() { yield return this.LoadTemplate; }
        public void Add(System.Func<object> loadTemplate) => this.LoadTemplate = loadTemplate;
    }

}