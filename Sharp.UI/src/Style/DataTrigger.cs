namespace Sharp.UI
{

    public class DataTrigger<T> : DataTrigger
    {
        public DataTrigger(Func<Binding, Binding> bindingBuilder, object value) : base(new Microsoft.Maui.Controls.DataTrigger(typeof(T)))
        {
            Binding = bindingBuilder(new Binding());
            Value = value;
        }

        //public static implicit operator Microsoft.Maui.Controls.TriggerBase(DataTrigger<T> trigger) => trigger.MauiObject;
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DataTrigger),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class DataTrigger { }
}
