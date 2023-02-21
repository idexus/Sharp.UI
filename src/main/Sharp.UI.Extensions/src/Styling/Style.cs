using System.Collections;
using Microsoft.Maui.Controls;
using Sharp.UI.Internal;

namespace Sharp.UI
{

    public partial class Style<T> : IEnumerable
        where T : BindableObject
    {
        Microsoft.Maui.Controls.Style mauiStyle;
        public static implicit operator Style(Style<T> style) => style.mauiStyle;

        public Style()
        {
            mauiStyle = new Microsoft.Maui.Controls.Style(typeof(T));
        }

        public Style(bool applyToDerivedTypes) : this()
        {
            mauiStyle.ApplyToDerivedTypes = applyToDerivedTypes;
        }

        public Style(Action<T> configure) : this()
        {
            ConfigureSetters(configure);
        }

        public Style(bool applyToDerivedTypes, Action<T> configure) : this()
        {
            mauiStyle.ApplyToDerivedTypes = applyToDerivedTypes;
            ConfigureSetters(configure);
        }

        void ConfigureSetters(Action<T> configure)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                FluentStyling.Setters = mauiStyle.Setters;
                configure?.Invoke(null);
                FluentStyling.Setters = null;
            });
        }

        public void Add(Setter setter) => this.mauiStyle.Setters.Add(setter);
        public void Add(Trigger trigger) => this.mauiStyle.Triggers.Add(trigger);
        public void Add(DataTrigger trigger) => this.mauiStyle.Triggers.Add(trigger);

        public void Add(Microsoft.Maui.Controls.VisualStateGroup group)
        {
            mauiStyle.GetVisualStateGroupList().Add(group);
        }

        public void Add(Microsoft.Maui.Controls.VisualState visualState)
        {
            var visualStateGroupList = mauiStyle.GetVisualStateGroupList();
            visualStateGroupList.GetCommonStatesVisualStateGroup().States.Add(visualState);
        }

        IEnumerator IEnumerable.GetEnumerator() => mauiStyle.Setters.GetEnumerator();
    }
}