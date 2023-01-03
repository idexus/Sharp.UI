﻿//
// <auto-generated>
//

#pragma warning disable CS8669


using System.Collections;
using System.Collections.ObjectModel;


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.SwipeItemView</c> class.
    /// </summary>
    [ContentProperty("Content")]
    public partial class SwipeItemView : Microsoft.Maui.Controls.SwipeItemView, Sharp.UI.ISwipeItemView, IMauiWrapper, IEnumerable
    {
        // ----- maui object -----

        public Sharp.UI.SwipeItemView MauiObject { get => this; }

        // ----- constructors -----

        public SwipeItemView() { }

        public SwipeItemView(out SwipeItemView swipeItemView) 
        {
            swipeItemView = this;
        }

        public SwipeItemView(System.Action<SwipeItemView> configure) 
        {
            configure(this);
        }

        public SwipeItemView(out SwipeItemView swipeItemView, System.Action<SwipeItemView> configure) 
        {
            swipeItemView = this;
            configure(this);
        }

        // ----- single item container -----

        public IEnumerator GetEnumerator() { yield return this.Content; }
        public void Add(Microsoft.Maui.Controls.View content) => this.Content = content;

        // ----- properties / events -----

        public new object CommandParameter { get => base.CommandParameter; set => base.CommandParameter = MauiWrapper.Value<object>(value); }
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
