﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.Shapes.PolyLineSegment</c> class.
    /// </summary>
    public partial class PolyLineSegment : Microsoft.Maui.Controls.Shapes.PolyLineSegment, Sharp.UI.IPolyLineSegment, IMauiWrapper
    {
        // ----- maui object -----

        public Sharp.UI.PolyLineSegment MauiObject { get => this; }

        // ----- constructors -----

        public PolyLineSegment() { }

        public PolyLineSegment(out PolyLineSegment polyLineSegment) 
        {
            polyLineSegment = this;
        }

        public PolyLineSegment(System.Action<PolyLineSegment> configure) 
        {
            configure(this);
        }

        public PolyLineSegment(out PolyLineSegment polyLineSegment, System.Action<PolyLineSegment> configure) 
        {
            polyLineSegment = this;
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