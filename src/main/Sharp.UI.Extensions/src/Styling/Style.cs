using System.Collections;
using Microsoft.Maui.Controls;
using Sharp.UI.Internal;

namespace Sharp.UI
{
    public partial class Style<T> : IEnumerable
        where T : BindableObject
    {
        readonly static BindableProperty AttachedStyleInvokeProperty =
            BindableProperty.CreateAttached($"{nameof(Style<T>)}.AttachedInvokeProperty", typeof(Action<T>), typeof(Style<T>), null, propertyChanged: OnAttachedInvokeChanged);

        static void OnAttachedInvokeChanged(BindableObject obj, object oldValue, object newValue)
        {
            var action = newValue as Action<T>;            
            action?.Invoke(obj as T);
        }

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

        public Style(Action<T> settersBuilder) : this()
        {
            BuildSetters(settersBuilder);
        }

        public Style(bool applyToDerivedTypes, Action<T> settersBuilder) : this()
        {
            mauiStyle.ApplyToDerivedTypes = applyToDerivedTypes;
            BuildSetters(settersBuilder);
        }

        void BuildSetters(Action<T> settersBuilder)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                FluentStyling.Setters = mauiStyle.Setters;
                settersBuilder?.Invoke(null);
                FluentStyling.Setters = null;
            });
        }

        public void Add(Action<T> action)
        {
            mauiStyle.Setters.Add(new Setter { Property = AttachedStyleInvokeProperty, Value = action });
        }

        public void Add(Func<T, T> settersBuilder)
        {
            BuildSetters(e => settersBuilder(e));
        }

        public void Add(Setter setter) => this.mauiStyle.Setters.Add(setter);
        public void Add(TriggerBase trigger) => this.mauiStyle.Triggers.Add(trigger);

        public void Add(VisualStateGroup group)
        {
            mauiStyle.GetVisualStateGroupList().Add(group);
        }

        public void Add(VisualState visualState)
        {
            var visualStateGroupList = mauiStyle.GetVisualStateGroupList();
            visualStateGroupList.GetCommonStatesVisualStateGroup().States.Add(visualState);
        }

        IEnumerator IEnumerable.GetEnumerator() => mauiStyle.Setters.GetEnumerator();
    }
}