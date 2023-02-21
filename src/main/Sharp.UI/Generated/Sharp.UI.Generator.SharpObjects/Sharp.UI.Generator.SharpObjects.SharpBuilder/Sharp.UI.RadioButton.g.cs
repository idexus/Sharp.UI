﻿//
// <auto-generated>
//

#nullable enable


using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;


namespace Sharp.UI
{
	public partial class RadioButton : IEnumerable
	{

        // ----- constructors -----

        public RadioButton() { }

        public RadioButton(out RadioButton radioButton) 
        {
            radioButton = this;
        }

        public RadioButton(System.Action<RadioButton> configure) 
        {
            configure(this);
        }

        public RadioButton(out RadioButton radioButton, System.Action<RadioButton> configure) 
        {
            radioButton = this;
            configure(this);
        }

        // ----- single item container -----

        IEnumerator IEnumerable.GetEnumerator() { yield return this.Content; }
        public void Add(object content) => this.Content = content;

    }
}

#nullable restore