namespace Sharp.UI
{

    [MauiWrapper(typeof(Microsoft.Maui.Controls.EventTrigger),
    generateAdditionalConstructors: false,
    generateNoParamConstructor: false)]
    public partial class EventTrigger
    {
        public EventTrigger(string @event) : this(new Microsoft.Maui.Controls.EventTrigger { Event = @event }) { }
    }

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
