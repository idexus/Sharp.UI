﻿//
// <auto-generated>
//

#pragma warning disable CS8669


using System.Collections;
using System.Collections.ObjectModel;


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.RadialGradientBrush</c> class.
    /// </summary>
    public partial class RadialGradientBrush : Microsoft.Maui.Controls.RadialGradientBrush, Sharp.UI.IRadialGradientBrush, IMauiWrapper, IList<Microsoft.Maui.Controls.GradientStop>
    {
        // ----- maui object -----

        public Sharp.UI.RadialGradientBrush MauiObject { get => this; }

        // ----- constructors -----

        public RadialGradientBrush() { }

        public RadialGradientBrush(out RadialGradientBrush radialGradientBrush) 
        {
            radialGradientBrush = this;
        }

        public RadialGradientBrush(System.Action<RadialGradientBrush> configure) 
        {
            configure(this);
        }

        public RadialGradientBrush(out RadialGradientBrush radialGradientBrush, System.Action<RadialGradientBrush> configure) 
        {
            radialGradientBrush = this;
            configure(this);
        }

        public RadialGradientBrush(Microsoft.Maui.Graphics.Point center, out RadialGradientBrush radialGradientBrush) : this(center)
        {
            radialGradientBrush = this;
        }

        public RadialGradientBrush(Microsoft.Maui.Graphics.Point center, System.Action<RadialGradientBrush> configure) : this(center)
        {
            configure(this);
        }

        public RadialGradientBrush(Microsoft.Maui.Graphics.Point center, out RadialGradientBrush radialGradientBrush, System.Action<RadialGradientBrush> configure) : this(center)
        {
            radialGradientBrush = this;
            configure(this);
        }

        // ----- collection container -----

        public int Count => this.GradientStops.Count;
        public Microsoft.Maui.Controls.GradientStop this[int index] { get => this.GradientStops[index]; set => this.GradientStops[index] = value; }
        public bool IsReadOnly => false;
        public void Add(Microsoft.Maui.Controls.GradientStop item) => this.GradientStops.Add(item);
        public void Clear() => this.GradientStops.Clear();
        public bool Contains(Microsoft.Maui.Controls.GradientStop item) => this.GradientStops.Contains(item);
        public void CopyTo(Microsoft.Maui.Controls.GradientStop[] array, int arrayIndex) => this.GradientStops.CopyTo(array, arrayIndex);
        public IEnumerator<Microsoft.Maui.Controls.GradientStop> GetEnumerator() => this.GradientStops.GetEnumerator();
        public int IndexOf(Microsoft.Maui.Controls.GradientStop item) => this.GradientStops.IndexOf(item);
        public void Insert(int index, Microsoft.Maui.Controls.GradientStop item) => this.GradientStops.Insert(index, item);
        public bool Remove(Microsoft.Maui.Controls.GradientStop item) => this.GradientStops.Remove(item);
        public void RemoveAt(int index) => this.GradientStops.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => this.GradientStops.GetEnumerator();

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
