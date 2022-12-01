namespace Sharp.UI
{

    public class DataTrigger<T> : DataTrigger
    {
        public DataTrigger(Func<Binding, Binding> bindingBuilder, object value) : base(new Microsoft.Maui.Controls.DataTrigger(typeof(T)))
        {
            Binding = bindingBuilder(new Binding());
            Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DataTrigger),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class DataTrigger { }
}
