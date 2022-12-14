//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class wrapping the sealed <c>Microsoft.Maui.Controls.BindingCondition</c> class.
    /// Use the <value>MauiObject</value> property to get the raw Maui object.
    /// </summary>
    public partial class BindingCondition : Sharp.UI.IBindingCondition, IMauiWrapper, ISealedMauiWrapper
    {
        // ----- maui object -----

        public object _maui_RawObject { get; set; }

        public Microsoft.Maui.Controls.BindingCondition MauiObject { get => (Microsoft.Maui.Controls.BindingCondition)_maui_RawObject; protected set => _maui_RawObject = value; }

        // ----- constructors -----

        public BindingCondition(Microsoft.Maui.Controls.BindingCondition bindingCondition)
        {
            MauiObject = bindingCondition;
        }

        public BindingCondition()
        {
            MauiObject = new Microsoft.Maui.Controls.BindingCondition();
        }

        public BindingCondition(out BindingCondition bindingCondition) : this()
        {
            bindingCondition = this;
        }

        public BindingCondition(System.Action<BindingCondition> configure) : this()
        {
            configure(this);
        }

        public BindingCondition(out BindingCondition bindingCondition, System.Action<BindingCondition> configure) : this()
        {
            bindingCondition = this;
            configure(this);
        }

        public BindingCondition(System.Func<Sharp.UI.Binding, Sharp.UI.Binding> bindingBuilder, object value, out BindingCondition bindingCondition) : this(bindingBuilder, value)
        {
            bindingCondition = this;
        }

        public BindingCondition(System.Func<Sharp.UI.Binding, Sharp.UI.Binding> bindingBuilder, object value, System.Action<BindingCondition> configure) : this(bindingBuilder, value)
        {
            configure(this);
        }

        public BindingCondition(System.Func<Sharp.UI.Binding, Sharp.UI.Binding> bindingBuilder, object value, out BindingCondition bindingCondition, System.Action<BindingCondition> configure) : this(bindingBuilder, value)
        {
            bindingCondition = this;
            configure(this);
        }

        // ----- operators -----

        public static implicit operator BindingCondition(Microsoft.Maui.Controls.BindingCondition mauiObject) => new BindingCondition(mauiObject);
        public static implicit operator Microsoft.Maui.Controls.BindingCondition(BindingCondition obj) => obj.MauiObject;

        // ----- properties / events -----

        public Microsoft.Maui.Controls.BindingBase Binding { get => MauiObject.Binding; set => MauiObject.Binding = value; }
        public object Value { get => MauiObject.Value; set => MauiObject.Value = MauiWrapper.Value<object>(value); }

    }
}

#pragma warning restore CS8669
