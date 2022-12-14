//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.AbsoluteLayout</c> class.
    /// </summary>
    public partial class AbsoluteLayout : Microsoft.Maui.Controls.AbsoluteLayout, Sharp.UI.IAbsoluteLayout, IMauiWrapper
    {
        // ----- constructors -----

        public AbsoluteLayout() { }

        public AbsoluteLayout(out AbsoluteLayout absoluteLayout) 
        {
            absoluteLayout = this;
        }

        public AbsoluteLayout(System.Action<AbsoluteLayout> configure) 
        {
            configure(this);
        }

        public AbsoluteLayout(out AbsoluteLayout absoluteLayout, System.Action<AbsoluteLayout> configure) 
        {
            absoluteLayout = this;
            configure(this);
        }

        // ----- properties / events -----

        public new Sharp.UI.Style Style { get => new Sharp.UI.Style(base.Style); set => base.Style = value.MauiObject; }
        public new object BindingContext { get => base.BindingContext; set => base.BindingContext = MauiWrapper.Value<object>(value); }

        // ----- set value method -----

        public new void SetValue(Microsoft.Maui.Controls.BindableProperty property, object value)
        {
            var mauiValue = MauiWrapper.Value<object>(value);
            ((Microsoft.Maui.Controls.BindableObject)this).SetValue(property, mauiValue);
        }

        public new void SetValue(Microsoft.Maui.Controls.BindablePropertyKey propertyKey, object value)
        {
            var mauiValue = MauiWrapper.Value<object>(value);
            ((Microsoft.Maui.Controls.BindableObject)this).SetValue(propertyKey, mauiValue);
        }
    }
}

#pragma warning restore CS8669
