﻿//
// <auto-generated>
//

#pragma warning disable CS0108
#pragma warning disable CS8625
#pragma warning disable CS8669


using System.Collections;
using System.Collections.ObjectModel;


namespace Sharp.UI
{
    public partial class Border : Microsoft.Maui.Controls.Border, Sharp.UI.IBorder, IEnumerable, IWrappedBindableObject
    {
        // ----- constructors -----
        

        public Border() { }


        public Border(out Border border) 
        {
            border = this;
        }

        public Border(Action<Border> configure) 
        {
            configure(this);
        }

        public Border(out Border border, Action<Border> configure) 
        {
            border = this;
            configure(this);
        }

        // ----- single item container -----

        public IEnumerator GetEnumerator() { yield return this.Content; }

        public void Add(Microsoft.Maui.Controls.View? content) => this.Content = content;

        // ----- binding context -----

        public new object BindingContext
        {
            get => base.BindingContext;
            set
            {
                var mauiObject = MauiWrapper.GetObject<object>(value);
                base.BindingContext = mauiObject;
            }
        }
        

    }
    
}

#pragma warning restore CS0108
#pragma warning restore CS8625
#pragma warning restore CS8669
