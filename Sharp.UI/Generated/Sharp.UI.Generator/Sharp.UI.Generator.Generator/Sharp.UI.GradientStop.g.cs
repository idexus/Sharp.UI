﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.GradientStop</c> class.
    /// </summary>
    public partial class GradientStop : Microsoft.Maui.Controls.GradientStop, Sharp.UI.IGradientStop, IMauiWrapper
    {
        // ----- constructors -----

        public GradientStop() { }

        public GradientStop(out GradientStop gradientStop) 
        {
            gradientStop = this;
        }

        public GradientStop(System.Action<GradientStop> configure) 
        {
            configure(this);
        }

        public GradientStop(out GradientStop gradientStop, System.Action<GradientStop> configure) 
        {
            gradientStop = this;
            configure(this);
        }

        public GradientStop(Microsoft.Maui.Graphics.Color color, double offset, out GradientStop gradientStop) : this(color, offset)
        {
            gradientStop = this;
        }

        public GradientStop(Microsoft.Maui.Graphics.Color color, double offset, System.Action<GradientStop> configure) : this(color, offset)
        {
            configure(this);
        }

        public GradientStop(Microsoft.Maui.Graphics.Color color, double offset, out GradientStop gradientStop, System.Action<GradientStop> configure) : this(color, offset)
        {
            gradientStop = this;
            configure(this);
        }

        // ----- properties / events -----

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
