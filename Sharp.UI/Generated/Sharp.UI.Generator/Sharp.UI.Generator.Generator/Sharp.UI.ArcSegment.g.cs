//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.Shapes.ArcSegment</c> class.
    /// </summary>
    public partial class ArcSegment : Microsoft.Maui.Controls.Shapes.ArcSegment, Sharp.UI.IArcSegment, IMauiWrapper
    {
        // ----- constructors -----

        public ArcSegment() { }

        public ArcSegment(out ArcSegment arcSegment) 
        {
            arcSegment = this;
        }

        public ArcSegment(System.Action<ArcSegment> configure) 
        {
            configure(this);
        }

        public ArcSegment(out ArcSegment arcSegment, System.Action<ArcSegment> configure) 
        {
            arcSegment = this;
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
