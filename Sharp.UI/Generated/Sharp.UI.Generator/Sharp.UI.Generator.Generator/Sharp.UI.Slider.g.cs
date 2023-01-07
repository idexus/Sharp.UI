﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.Slider</c> class.
    /// </summary>
    public partial class Slider : Microsoft.Maui.Controls.Slider, Sharp.UI.ISlider, IMauiWrapper
    {
        // ----- constructors -----

        public Slider() { }

        public Slider(out Slider slider) 
        {
            slider = this;
        }

        public Slider(System.Action<Slider> configure) 
        {
            configure(this);
        }

        public Slider(out Slider slider, System.Action<Slider> configure) 
        {
            slider = this;
            configure(this);
        }

        public Slider(double minimum, double maximum, double value, out Slider slider) : this(minimum, maximum, value)
        {
            slider = this;
        }

        public Slider(double minimum, double maximum, double value, System.Action<Slider> configure) : this(minimum, maximum, value)
        {
            configure(this);
        }

        public Slider(double minimum, double maximum, double value, out Slider slider, System.Action<Slider> configure) : this(minimum, maximum, value)
        {
            slider = this;
            configure(this);
        }

        public Slider(double minimum, double maximum, out Slider slider) : this(minimum, maximum)
        {
            slider = this;
        }

        public Slider(double minimum, double maximum, System.Action<Slider> configure) : this(minimum, maximum)
        {
            configure(this);
        }

        public Slider(double minimum, double maximum, out Slider slider, System.Action<Slider> configure) : this(minimum, maximum)
        {
            slider = this;
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
