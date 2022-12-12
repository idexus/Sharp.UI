namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.Trigger))]
    public partial class Trigger
    {
        public Trigger(BindableProperty property, object value)
            : this(new Microsoft.Maui.Controls.Trigger(property.DeclaringType))
        {
            Property = property; Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DataTrigger))]
    public partial class DataTrigger { }

    public class DataTrigger<T> : DataTrigger
    {
        public DataTrigger(Func<Binding, Binding> bindingBuilder, object value)
            : base(new Microsoft.Maui.Controls.DataTrigger(typeof(T)))
        {
            Binding = bindingBuilder(new Binding());
            Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.EventTrigger))]
    public partial class EventTrigger
    {
        public EventTrigger(string @event)
            : this(new Microsoft.Maui.Controls.EventTrigger { Event = @event }) { }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.MultiTrigger))]
    public partial class MultiTrigger { }

    public class MultiTrigger<T> : MultiTrigger
    {
        public MultiTrigger()
            : base(new Microsoft.Maui.Controls.MultiTrigger(typeof(T))) { }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.BindingCondition))]
    public partial class BindingCondition
    {
        public BindingCondition(Func<Binding, Binding> bindingBuilder, object value)
            : this(new Microsoft.Maui.Controls.BindingCondition())
        {
            Binding = bindingBuilder(new Binding());
            Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.PropertyCondition))]
    public partial class PropertyCondition
    {
        public PropertyCondition(BindableProperty property, object value)
            : this(new Microsoft.Maui.Controls.PropertyCondition())
        {
            Property = property; Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.StateTrigger))]
    public partial class StateTrigger { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.AdaptiveTrigger))]
    public partial class AdaptiveTrigger { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.CompareStateTrigger))]
    public partial class CompareStateTrigger
    {
        public CompareStateTrigger(Func<Binding, Binding> bindingBuilder, object value)
            : this(new Microsoft.Maui.Controls.CompareStateTrigger())
        {
            Property = bindingBuilder(new Binding());
            Value = value;
        }
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DeviceStateTrigger))]
    public partial class DeviceStateTrigger { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.OrientationStateTrigger))]
    public partial class OrientationStateTrigger { }
}