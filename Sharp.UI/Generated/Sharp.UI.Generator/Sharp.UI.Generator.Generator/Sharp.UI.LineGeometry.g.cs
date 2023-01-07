﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.Shapes.LineGeometry</c> class.
    /// </summary>
    public partial class LineGeometry : Microsoft.Maui.Controls.Shapes.LineGeometry, Sharp.UI.ILineGeometry, IMauiWrapper
    {
        // ----- constructors -----

        public LineGeometry() { }

        public LineGeometry(out LineGeometry lineGeometry) 
        {
            lineGeometry = this;
        }

        public LineGeometry(System.Action<LineGeometry> configure) 
        {
            configure(this);
        }

        public LineGeometry(out LineGeometry lineGeometry, System.Action<LineGeometry> configure) 
        {
            lineGeometry = this;
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
