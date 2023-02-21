using System;
using System.Collections;
using Microsoft.Maui.Controls;
using Sharp.UI.Internal;

namespace Sharp.UI
{
    public partial class VisualState<T> : IEnumerable
        where T : BindableObject
    {
        Microsoft.Maui.Controls.VisualState mauiVisualState;
        public static implicit operator Microsoft.Maui.Controls.VisualState(VisualState<T> visualState) => visualState.mauiVisualState;

        IEnumerator IEnumerable.GetEnumerator() => mauiVisualState.Setters.GetEnumerator();
        public void Add(Setter setter) => this.mauiVisualState.Setters.Add(setter);
        public void Add(Microsoft.Maui.Controls.StateTriggerBase triggerBase) => this.mauiVisualState.StateTriggers.Add(triggerBase);

        public VisualState(string name)
        {
            this.mauiVisualState = new Microsoft.Maui.Controls.VisualState();
            this.mauiVisualState.Name = name;
        }

        public VisualState() : this(Guid.NewGuid().ToString()) { }

        public VisualState(Action<T> configure) : this()
        {
            ConfigureSetters(configure);
        }

        public VisualState(string name, Action<T> configure) : this(name)
        {
            ConfigureSetters(configure);
        }

        void ConfigureSetters(Action<T> configure)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                FluentStyling.Setters = mauiVisualState.Setters;
                configure?.Invoke(null);
                FluentStyling.Setters = null;
            });
        }
    }


    public partial class VisualStateEnum  // TODO: sealed
    {
        //------ consts -------

        public class VisualElement
        {
            public const string Normal = "Normal";
            public const string Disabled = "Disabled";
            public const string Focused = "Focused";
            public const string PointerOver = "PointerOver";
        }

        public class Switch : VisualElement
        {
            public const string On = "On";
            public const string Off = "Off";
        }

        public class RadioButton : VisualElement
        {
            public const string Checked = "Checked";
            public const string Unchecked = "Unchecked";
        }

        public class ImageButton : VisualElement
        {
            public const string Pressed = "Pressed";
        }

        public class CollectionView : VisualElement
        {
            public const string Selected = "Selected";
        }

        public class CheckBox : VisualElement
        {
            public const string IsChecked = "IsChecked";
        }

        public class CarouselView : VisualElement
        {
            public const string DefaultItem = "DefaultItem";
            public const string CurrentItem = "CurrentItem";
            public const string PreviousItem = "PreviousItem";
            public const string NextItem = "NextItem";
        }

        public class Button : VisualElement
        {
            public const string Pressed = "Pressed";
        }        
    }
}

