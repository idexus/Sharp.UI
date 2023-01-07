﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.EntryCell</c> class.
    /// </summary>
    public partial class EntryCell : Microsoft.Maui.Controls.EntryCell, Sharp.UI.IEntryCell, IMauiWrapper
    {
        // ----- constructors -----

        public EntryCell() { }

        public EntryCell(out EntryCell entryCell) 
        {
            entryCell = this;
        }

        public EntryCell(System.Action<EntryCell> configure) 
        {
            configure(this);
        }

        public EntryCell(out EntryCell entryCell, System.Action<EntryCell> configure) 
        {
            entryCell = this;
            configure(this);
        }

        public EntryCell(string placeholder, out EntryCell entryCell) : this(placeholder)
        {
            entryCell = this;
        }

        public EntryCell(string placeholder, System.Action<EntryCell> configure) : this(placeholder)
        {
            configure(this);
        }

        public EntryCell(string placeholder, out EntryCell entryCell, System.Action<EntryCell> configure) : this(placeholder)
        {
            entryCell = this;
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
