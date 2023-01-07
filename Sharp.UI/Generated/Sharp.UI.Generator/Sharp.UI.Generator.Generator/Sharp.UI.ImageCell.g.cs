﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.ImageCell</c> class.
    /// </summary>
    public partial class ImageCell : Microsoft.Maui.Controls.ImageCell, Sharp.UI.IImageCell, IMauiWrapper
    {
        // ----- constructors -----

        public ImageCell() { }

        public ImageCell(out ImageCell imageCell) 
        {
            imageCell = this;
        }

        public ImageCell(System.Action<ImageCell> configure) 
        {
            configure(this);
        }

        public ImageCell(out ImageCell imageCell, System.Action<ImageCell> configure) 
        {
            imageCell = this;
            configure(this);
        }

        // ----- properties / events -----

        public new object CommandParameter { get => base.CommandParameter; set => base.CommandParameter = MauiWrapper.Value<object>(value); }
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
