//
// <auto-generated>
//

#pragma warning disable CS8669


using System.Collections;
using System.Collections.ObjectModel;


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.ContentPage</c> class.
    /// </summary>
    [ContentProperty("Content")]
    public partial class ContentPage : Microsoft.Maui.Controls.ContentPage, Sharp.UI.IContentPage, IMauiWrapper, IEnumerable
    {
        // ----- constructors -----

        public ContentPage(out ContentPage contentPage) : this()
        {
            contentPage = this;
        }

        public ContentPage(System.Action<ContentPage> configure) : this()
        {
            configure(this);
        }

        public ContentPage(out ContentPage contentPage, System.Action<ContentPage> configure) : this()
        {
            contentPage = this;
            configure(this);
        }

        public ContentPage(string title, out ContentPage contentPage) : this(title)
        {
            contentPage = this;
        }

        public ContentPage(string title, System.Action<ContentPage> configure) : this(title)
        {
            configure(this);
        }

        public ContentPage(string title, out ContentPage contentPage, System.Action<ContentPage> configure) : this(title)
        {
            contentPage = this;
            configure(this);
        }

        // ----- single item container -----

        public IEnumerator GetEnumerator() { yield return this.Content; }
        public void Add(Microsoft.Maui.Controls.View content) => this.Content = content;

        // ----- consumed attached properties -----

        public Microsoft.Maui.Controls.PresentationMode ShellPresentationMode
        {
            get => (Microsoft.Maui.Controls.PresentationMode)GetValue(Microsoft.Maui.Controls.Shell.PresentationModeProperty);
            set => SetValue(Microsoft.Maui.Controls.Shell.PresentationModeProperty, value);
        }
        
        public Microsoft.Maui.Graphics.Color ShellBackgroundColor
        {
            get => (Microsoft.Maui.Graphics.Color)GetValue(Microsoft.Maui.Controls.Shell.BackgroundColorProperty);
            set => SetValue(Microsoft.Maui.Controls.Shell.BackgroundColorProperty, value);
        }
        
        public Microsoft.Maui.Graphics.Color ShellForegroundColor
        {
            get => (Microsoft.Maui.Graphics.Color)GetValue(Microsoft.Maui.Controls.Shell.ForegroundColorProperty);
            set => SetValue(Microsoft.Maui.Controls.Shell.ForegroundColorProperty, value);
        }
        
        public Microsoft.Maui.Graphics.Color ShellTitleColor
        {
            get => (Microsoft.Maui.Graphics.Color)GetValue(Microsoft.Maui.Controls.Shell.TitleColorProperty);
            set => SetValue(Microsoft.Maui.Controls.Shell.TitleColorProperty, value);
        }
        
        public Microsoft.Maui.Graphics.Color ShellDisabledColor
        {
            get => (Microsoft.Maui.Graphics.Color)GetValue(Microsoft.Maui.Controls.Shell.DisabledColorProperty);
            set => SetValue(Microsoft.Maui.Controls.Shell.DisabledColorProperty, value);
        }
        
        public Microsoft.Maui.Graphics.Color ShellUnselectedColor
        {
            get => (Microsoft.Maui.Graphics.Color)GetValue(Microsoft.Maui.Controls.Shell.UnselectedColorProperty);
            set => SetValue(Microsoft.Maui.Controls.Shell.UnselectedColorProperty, value);
        }
        
        public bool ShellNavBarHasShadow
        {
            get => (bool)GetValue(Microsoft.Maui.Controls.Shell.NavBarHasShadowProperty);
            set => SetValue(Microsoft.Maui.Controls.Shell.NavBarHasShadowProperty, value);
        }
        
        public bool ShellNavBarIsVisible
        {
            get => (bool)GetValue(Microsoft.Maui.Controls.Shell.NavBarIsVisibleProperty);
            set => SetValue(Microsoft.Maui.Controls.Shell.NavBarIsVisibleProperty, value);
        }
        
        public Microsoft.Maui.Controls.View ShellTitleView
        {
            get => (Microsoft.Maui.Controls.View)GetValue(Microsoft.Maui.Controls.Shell.TitleViewProperty);
            set => SetValue(Microsoft.Maui.Controls.Shell.TitleViewProperty, value);
        }
        
        // ----- properties / events -----

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
