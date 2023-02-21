﻿//
// <auto-generated>
//

#nullable enable


using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;


namespace Sharp.UI
{
	public partial class SwipeItemView : IEnumerable
	{

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

        IEnumerator IEnumerable.GetEnumerator() { yield return this.Content; }
        public void Add(Microsoft.Maui.Controls.View content) => this.Content = content;

    }
}

#nullable restore