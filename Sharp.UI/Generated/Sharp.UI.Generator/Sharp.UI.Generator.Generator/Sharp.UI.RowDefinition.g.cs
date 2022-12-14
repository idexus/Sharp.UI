//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class wrapping the sealed <c>Microsoft.Maui.Controls.RowDefinition</c> class.
    /// Use the <value>MauiObject</value> property to get the raw Maui object.
    /// </summary>
    public partial class RowDefinition : Sharp.UI.IRowDefinition, IMauiWrapper, ISealedMauiWrapper
    {
        // ----- maui object -----

        public object _maui_RawObject { get; set; }

        public Microsoft.Maui.Controls.RowDefinition MauiObject { get => (Microsoft.Maui.Controls.RowDefinition)_maui_RawObject; protected set => _maui_RawObject = value; }

        // ----- constructors -----

        public RowDefinition(Microsoft.Maui.Controls.RowDefinition rowDefinition)
        {
            MauiObject = rowDefinition;
        }

        public RowDefinition()
        {
            MauiObject = new Microsoft.Maui.Controls.RowDefinition();
        }

        public RowDefinition(out RowDefinition rowDefinition) : this()
        {
            rowDefinition = this;
        }

        public RowDefinition(System.Action<RowDefinition> configure) : this()
        {
            configure(this);
        }

        public RowDefinition(out RowDefinition rowDefinition, System.Action<RowDefinition> configure) : this()
        {
            rowDefinition = this;
            configure(this);
        }

        public RowDefinition(double height, out RowDefinition rowDefinition) : this(height)
        {
            rowDefinition = this;
        }

        public RowDefinition(double height, System.Action<RowDefinition> configure) : this(height)
        {
            configure(this);
        }

        public RowDefinition(double height, out RowDefinition rowDefinition, System.Action<RowDefinition> configure) : this(height)
        {
            rowDefinition = this;
            configure(this);
        }

        public RowDefinition(double height, Microsoft.Maui.GridUnitType unitType, out RowDefinition rowDefinition) : this(height, unitType)
        {
            rowDefinition = this;
        }

        public RowDefinition(double height, Microsoft.Maui.GridUnitType unitType, System.Action<RowDefinition> configure) : this(height, unitType)
        {
            configure(this);
        }

        public RowDefinition(double height, Microsoft.Maui.GridUnitType unitType, out RowDefinition rowDefinition, System.Action<RowDefinition> configure) : this(height, unitType)
        {
            rowDefinition = this;
            configure(this);
        }

        // ----- operators -----

        public static implicit operator RowDefinition(Microsoft.Maui.Controls.RowDefinition mauiObject) => new RowDefinition(mauiObject);
        public static implicit operator Microsoft.Maui.Controls.RowDefinition(RowDefinition obj) => obj.MauiObject;

        // ----- sealed bindable properties -----

        public static Microsoft.Maui.Controls.BindableProperty HeightProperty => Microsoft.Maui.Controls.RowDefinition.HeightProperty;
        public static Microsoft.Maui.Controls.BindableProperty BindingContextProperty => Microsoft.Maui.Controls.BindableObject.BindingContextProperty;

        // ----- properties / events -----

        public Microsoft.Maui.GridLength Height { get => MauiObject.Height; set => MauiObject.Height = value; }
        public Microsoft.Maui.Dispatching.IDispatcher Dispatcher { get => MauiObject.Dispatcher; }
        public object BindingContext { get => MauiObject.BindingContext; set => MauiObject.BindingContext = MauiWrapper.Value<object>(value); }
        public event System.EventHandler SizeChanged { add => MauiObject.SizeChanged += value; remove => MauiObject.SizeChanged -= value; }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged { add => MauiObject.PropertyChanged += value; remove => MauiObject.PropertyChanged -= value; }
        public event Microsoft.Maui.Controls.PropertyChangingEventHandler PropertyChanging { add => MauiObject.PropertyChanging += value; remove => MauiObject.PropertyChanging -= value; }
        public event System.EventHandler BindingContextChanged { add => MauiObject.BindingContextChanged += value; remove => MauiObject.BindingContextChanged -= value; }

        // ----- set value method -----

        public void SetValue(Microsoft.Maui.Controls.BindableProperty property, object value)
        {
            var mauiValue = MauiWrapper.Value<object>(value);
            MauiObject.SetValue(property, mauiValue);
        }

        public void SetValue(Microsoft.Maui.Controls.BindablePropertyKey propertyKey, object value)
        {
            var mauiValue = MauiWrapper.Value<object>(value);
            MauiObject.SetValue(propertyKey, mauiValue);
        }
    }
}

#pragma warning restore CS8669
