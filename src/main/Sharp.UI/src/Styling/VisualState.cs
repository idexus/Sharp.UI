using System;
using System.Collections;
using Microsoft.Maui.Animations;
using Microsoft.Maui.Controls;
using Sharp.UI.Internal;

namespace Sharp.UI
{
    public partial class VisualState<T> : IEnumerable
        where T : BindableObject
    {
        readonly static BindableProperty AttachedVisualStateInvokeProperty =
            BindableProperty.CreateAttached($"{nameof(VisualState<T>)}.AttachedInvokeProperty", typeof(Action<T>), typeof(VisualState<T>), null, propertyChanged: OnAttachedInvokeChanged);

        static void OnAttachedInvokeChanged(BindableObject obj, object oldValue, object newValue)
        {
            var action = newValue as Action<T>;
            if (obj is VisualElement visualElement && visualElement.Handler != null)
                action?.Invoke(obj as T);
        }

        Microsoft.Maui.Controls.VisualState mauiVisualState;
        public static implicit operator Microsoft.Maui.Controls.VisualState(VisualState<T> visualState) => visualState.mauiVisualState;

        IEnumerator IEnumerable.GetEnumerator() => mauiVisualState.Setters.GetEnumerator();
        public void Add(Setter setter) => this.mauiVisualState.Setters.Add(setter);
        public void Add(Microsoft.Maui.Controls.StateTriggerBase triggerBase) => this.mauiVisualState.StateTriggers.Add(triggerBase);

        public void Add(Action<T> invokeOnElement)
        {
            mauiVisualState.Setters.Add(new Setter { Property = AttachedVisualStateInvokeProperty, Value = invokeOnElement });
        }

        public VisualState(string name)
        {
            this.mauiVisualState = new Microsoft.Maui.Controls.VisualState();
            this.mauiVisualState.Name = name;
        }

        public VisualState() : this(Guid.NewGuid().ToString()) { }

        public VisualState(Func<SettersContext<T>, SettersContext<T>> buildSetters) : this()
        {
            BuildSetters(buildSetters);
        }

        public VisualState(string name, Func<SettersContext<T>, SettersContext<T>> buildSetters) : this(name)
        {
            BuildSetters(buildSetters);
        }

        void BuildSetters(Func<SettersContext<T>, SettersContext<T>> buildSetters)
        {
            var settersContext = new SettersContext<T>();
            buildSetters(settersContext);
            foreach (var setter in settersContext.XamlSetters)
                this.mauiVisualState.Setters.Add(setter);
        }
    }
}

