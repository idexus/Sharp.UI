//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class wrapping the sealed <c>Microsoft.Maui.Controls.ColumnDefinition</c> class.
    /// Use the <value>MauiObject</value> property to get the raw Maui object.
    /// </summary>
    public partial class ColumnDefinition : Sharp.UI.IColumnDefinition, IMauiWrapper, ISealedMauiWrapper
    {
        // ----- maui object -----

        public object _maui_RawObject { get; set; }

        public Microsoft.Maui.Controls.ColumnDefinition MauiObject { get => (Microsoft.Maui.Controls.ColumnDefinition)_maui_RawObject; protected set => _maui_RawObject = value; }

        // ----- constructors -----

        public ColumnDefinition(Microsoft.Maui.Controls.ColumnDefinition columnDefinition)
        {
            MauiObject = columnDefinition;
        }

        public ColumnDefinition()
        {
            MauiObject = new Microsoft.Maui.Controls.ColumnDefinition();
        }

        public ColumnDefinition(out ColumnDefinition columnDefinition) : this()
        {
            columnDefinition = this;
        }

        public ColumnDefinition(System.Action<ColumnDefinition> configure) : this()
        {
            configure(this);
        }

        public ColumnDefinition(out ColumnDefinition columnDefinition, System.Action<ColumnDefinition> configure) : this()
        {
            columnDefinition = this;
            configure(this);
        }

        public ColumnDefinition(double width, out ColumnDefinition columnDefinition) : this(width)
        {
            columnDefinition = this;
        }

        public ColumnDefinition(double width, System.Action<ColumnDefinition> configure) : this(width)
        {
            configure(this);
        }

        public ColumnDefinition(double width, out ColumnDefinition columnDefinition, System.Action<ColumnDefinition> configure) : this(width)
        {
            columnDefinition = this;
            configure(this);
        }

        public ColumnDefinition(double width, Microsoft.Maui.GridUnitType unitType, out ColumnDefinition columnDefinition) : this(width, unitType)
        {
            columnDefinition = this;
        }

        public ColumnDefinition(double width, Microsoft.Maui.GridUnitType unitType, System.Action<ColumnDefinition> configure) : this(width, unitType)
        {
            configure(this);
        }

        public ColumnDefinition(double width, Microsoft.Maui.GridUnitType unitType, out ColumnDefinition columnDefinition, System.Action<ColumnDefinition> configure) : this(width, unitType)
        {
            columnDefinition = this;
            configure(this);
        }

        // ----- operators -----

        public static implicit operator ColumnDefinition(Microsoft.Maui.Controls.ColumnDefinition mauiObject) => new ColumnDefinition(mauiObject);
        public static implicit operator Microsoft.Maui.Controls.ColumnDefinition(ColumnDefinition obj) => obj.MauiObject;

        // ----- sealed bindable properties -----

        public static Microsoft.Maui.Controls.BindableProperty WidthProperty => Microsoft.Maui.Controls.ColumnDefinition.WidthProperty;
        public static Microsoft.Maui.Controls.BindableProperty BindingContextProperty => Microsoft.Maui.Controls.BindableObject.BindingContextProperty;

        // ----- properties / events -----

        public Microsoft.Maui.GridLength Width { get => MauiObject.Width; set => MauiObject.Width = value; }
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
