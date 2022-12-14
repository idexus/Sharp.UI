//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.NavigationPage</c> class.
    /// </summary>
    public partial class NavigationPage : Microsoft.Maui.Controls.NavigationPage, Sharp.UI.INavigationPage, IMauiWrapper
    {
        // ----- constructors -----

        public NavigationPage() { }

        public NavigationPage(out NavigationPage navigationPage) 
        {
            navigationPage = this;
        }

        public NavigationPage(System.Action<NavigationPage> configure) 
        {
            configure(this);
        }

        public NavigationPage(out NavigationPage navigationPage, System.Action<NavigationPage> configure) 
        {
            navigationPage = this;
            configure(this);
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
