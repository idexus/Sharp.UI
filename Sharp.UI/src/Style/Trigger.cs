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
        public MultiTrigger() : base(new Microsoft.Maui.Controls.MultiTrigger(typeof(T))) { }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.BindingCondition),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class BindingCondition
    {
        public BindingCondition(Func<Binding, Binding> bindingBuilder, object value) : this(new Microsoft.Maui.Controls.BindingCondition())
        {
            Binding = bindingBuilder(new Binding());
            Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.PropertyCondition),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class PropertyCondition
    {
        public PropertyCondition(BindableProperty property, object value) : this(new Microsoft.Maui.Controls.PropertyCondition())
        {
            Property = property; Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.StateTrigger),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: true)]
    public partial class StateTrigger { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.AdaptiveTrigger),
    generateAdditionalConstructors: false,
    generateNoParamConstructor: true)]
    public partial class AdaptiveTrigger { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.CompareStateTrigger),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class CompareStateTrigger
    {
        public CompareStateTrigger(Func<Binding, Binding> bindingBuilder, object value) : this(new Microsoft.Maui.Controls.CompareStateTrigger())
        {
            Property = bindingBuilder(new Binding());
            Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DeviceStateTrigger),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: true)]
    public partial class DeviceStateTrigger { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.OrientationStateTrigger),
    generateAdditionalConstructors: false,
    generateNoParamConstructor: true)]
    public partial class OrientationStateTrigger { }
}