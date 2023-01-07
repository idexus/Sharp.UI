﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.DropGestureRecognizer</c> class.
    /// </summary>
    public partial class DropGestureRecognizer : Microsoft.Maui.Controls.DropGestureRecognizer, Sharp.UI.IDropGestureRecognizer, IMauiWrapper
    {
        // ----- constructors -----

        public DropGestureRecognizer() { }

        public DropGestureRecognizer(out DropGestureRecognizer dropGestureRecognizer) 
        {
            dropGestureRecognizer = this;
        }

        public DropGestureRecognizer(System.Action<DropGestureRecognizer> configure) 
        {
            configure(this);
        }

        public DropGestureRecognizer(out DropGestureRecognizer dropGestureRecognizer, System.Action<DropGestureRecognizer> configure) 
        {
            dropGestureRecognizer = this;
            configure(this);
        }

        // ----- properties / events -----

        public new object DragOverCommandParameter { get => base.DragOverCommandParameter; set => base.DragOverCommandParameter = MauiWrapper.Value<object>(value); }
        public new object DragLeaveCommandParameter { get => base.DragLeaveCommandParameter; set => base.DragLeaveCommandParameter = MauiWrapper.Value<object>(value); }
        public new object DropCommandParameter { get => base.DropCommandParameter; set => base.DropCommandParameter = MauiWrapper.Value<object>(value); }
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
