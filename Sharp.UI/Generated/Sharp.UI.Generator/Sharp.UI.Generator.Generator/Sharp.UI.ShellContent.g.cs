﻿//
// <auto-generated>
//

#pragma warning disable CS8669


using System.Collections;
using System.Collections.ObjectModel;


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.ShellContent</c> class.
    /// </summary>
    public partial class ShellContent : Microsoft.Maui.Controls.ShellContent, Sharp.UI.IShellContent, IMauiWrapper, IEnumerable
    {
        // ----- maui object -----

        public Sharp.UI.ShellContent MauiObject { get => this; }

        // ----- constructors -----

        public ShellContent() { }

        public ShellContent(out ShellContent shellContent) 
        {
            shellContent = this;
        }

        public ShellContent(System.Action<ShellContent> configure) 
        {
            configure(this);
        }

        public ShellContent(out ShellContent shellContent, System.Action<ShellContent> configure) 
        {
            shellContent = this;
            configure(this);
        }

        public ShellContent(System.Type page, out ShellContent shellContent) : this(page)
        {
            shellContent = this;
        }

        public ShellContent(System.Type page, System.Action<ShellContent> configure) : this(page)
        {
            configure(this);
        }

        public ShellContent(System.Type page, out ShellContent shellContent, System.Action<ShellContent> configure) : this(page)
        {
            shellContent = this;
            configure(this);
        }

        public ShellContent(string title, object content) 
        {  
            this.Title = title;
            this.Content = content;
        }

        public ShellContent(string title, object content, out ShellContent shellContent) 
        {  
            this.Title = title;
            this.Content = content;;
            shellContent = this;
        }

        public ShellContent(string title, object content, System.Action<ShellContent> configure) 
        {  
            this.Title = title;
            this.Content = content;
            configure(this);
        }

        public ShellContent(string title, object content, out ShellContent shellContent, System.Action<ShellContent> configure) 
        {  
            this.Title = title;
            this.Content = content;
            shellContent = this;
            configure(this);
        }

        // ----- single item container -----

        public IEnumerator GetEnumerator() { yield return this.Content; }

        public void Add(object content) => this.Content = content;

        // ----- properties / events -----

        public new object Content { get => base.Content; set => base.Content = MauiWrapper.Value<object>(value); }
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
