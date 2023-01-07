﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.ProgressBar</c> class.
    /// </summary>
    public partial class ProgressBar : Microsoft.Maui.Controls.ProgressBar, Sharp.UI.IProgressBar, IMauiWrapper
    {
        // ----- constructors -----

        public ProgressBar() { }

        public ProgressBar(out ProgressBar progressBar) 
        {
            progressBar = this;
        }

        public ProgressBar(System.Action<ProgressBar> configure) 
        {
            configure(this);
        }

        public ProgressBar(out ProgressBar progressBar, System.Action<ProgressBar> configure) 
        {
            progressBar = this;
            configure(this);
        }

        public ProgressBar(double progress, out ProgressBar progressBar) : this(progress)
        {
            progressBar = this;
        }

        public ProgressBar(double progress, System.Action<ProgressBar> configure) : this(progress)
        {
            configure(this);
        }

        public ProgressBar(double progress, out ProgressBar progressBar, System.Action<ProgressBar> configure) : this(progress)
        {
            progressBar = this;
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
