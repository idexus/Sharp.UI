//
// <auto-generated>
//

#pragma warning disable CS8669


using System.Collections;
using System.Collections.ObjectModel;


namespace Sharp.UI
{  
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>Microsoft.Maui.Controls.TabBar</c> class.
    /// </summary>
    public partial class TabBar : Microsoft.Maui.Controls.TabBar, Sharp.UI.ITabBar, IMauiWrapper, IList<Microsoft.Maui.Controls.ShellSection>
    {
        // ----- constructors -----

        public TabBar() { }

        public TabBar(out TabBar tabBar) 
        {
            tabBar = this;
        }

        public TabBar(System.Action<TabBar> configure) 
        {
            configure(this);
        }

        public TabBar(out TabBar tabBar, System.Action<TabBar> configure) 
        {
            tabBar = this;
            configure(this);
        }

        // ----- collection container -----

        public int Count => this.Items.Count;
        public Microsoft.Maui.Controls.ShellSection this[int index] { get => this.Items[index]; set => this.Items[index] = value; }
        public bool IsReadOnly => false;
        public void Add(Microsoft.Maui.Controls.ShellSection item) => this.Items.Add(item);
        public void Clear() => this.Items.Clear();
        public bool Contains(Microsoft.Maui.Controls.ShellSection item) => this.Items.Contains(item);
        public void CopyTo(Microsoft.Maui.Controls.ShellSection[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);
        public IEnumerator<Microsoft.Maui.Controls.ShellSection> GetEnumerator() => this.Items.GetEnumerator();
        public int IndexOf(Microsoft.Maui.Controls.ShellSection item) => this.Items.IndexOf(item);
        public void Insert(int index, Microsoft.Maui.Controls.ShellSection item) => this.Items.Insert(index, item);
        public bool Remove(Microsoft.Maui.Controls.ShellSection item) => this.Items.Remove(item);
        public void RemoveAt(int index) => this.Items.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => this.Items.GetEnumerator();

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
