namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.Trigger),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class Trigger
    {
        public Trigger(BindableProperty property, object value) : this(new Microsoft.Maui.Controls.Trigger(property.DeclaringType))
        {
            Property = property; Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DataTrigger),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class DataTrigger { }

    public class DataTrigger<T> : DataTrigger
    {
        public DataTrigger(Func<Binding, Binding> bindingBuilder, object value) : base(new Microsoft.Maui.Controls.DataTrigger(typeof(T)))
        {
            Binding = bindingBuilder(new Binding());
            Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.EventTrigger),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class EventTrigger
    {
        public EventTrigger(string @event) : this(new Microsoft.Maui.Controls.EventTrigger { Event = @event }) { }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.MultiTrigger),
    generateAdditionalConstructors: false,
    generateNoParamConstructor: false)]
    public partial class MultiTrigger { }

    public class MultiTrigger<T> : MultiTrigger
    {
        public MultiTrigger(Func<Binding, Binding> bindingBuilder, object value) : base(new Microsoft.Maui.Controls.MultiTrigger(typeof(T)))
        {
        }
    }
}