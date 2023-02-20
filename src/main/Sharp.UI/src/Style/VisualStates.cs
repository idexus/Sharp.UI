using System;
using System.Collections;
using Microsoft.Maui.Controls;

namespace Sharp.UI
{
    public partial class VisualStateGroup : IEnumerable // TODO: sealed
    {
        Microsoft.Maui.Controls.VisualStateGroup mauiVisualStateGroup;
        public static implicit operator Microsoft.Maui.Controls.VisualStateGroup(VisualStateGroup visualState) => visualState.mauiVisualStateGroup;

        IEnumerator IEnumerable.GetEnumerator() => mauiVisualStateGroup.States.GetEnumerator();
        public void Add(VisualState visualState) => this.mauiVisualStateGroup.States.Add(visualState);


        public VisualStateGroup(string name = VisualStateGroup.CommonStates)
        {
            this.mauiVisualStateGroup = new Microsoft.Maui.Controls.VisualStateGroup();
            if (string.IsNullOrEmpty(name)) name = Guid.NewGuid().ToString();
            this.mauiVisualStateGroup.Name = name;
        }

        public const string CommonStates = "CommonStates";
    }

    public partial class VisualState : IEnumerable  // TODO: sealed
    {
        Microsoft.Maui.Controls.VisualState mauiVisualState;
        public static implicit operator Microsoft.Maui.Controls.VisualState(VisualState visualState) => visualState.mauiVisualState;

        IEnumerator IEnumerable.GetEnumerator() => mauiVisualState.Setters.GetEnumerator();
        public void Add(Setter setter) => this.mauiVisualState.Setters.Add(setter);
        public void Add(Microsoft.Maui.Controls.StateTriggerBase triggerBase) => this.mauiVisualState.StateTriggers.Add(triggerBase);

        public VisualState() : this(Guid.NewGuid().ToString()) { }

        public VisualState(string name)
        {
            this.mauiVisualState = new Microsoft.Maui.Controls.VisualState();
            this.mauiVisualState.Name = name;
        }

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

