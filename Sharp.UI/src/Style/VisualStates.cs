using System;
using Microsoft.Maui.Controls;

namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.VisualStateGroupList))]
    public partial class VisualStateGroupList { }

    [SharpObject(typeof(Microsoft.Maui.Controls.VisualStateGroup))]
    public partial class VisualStateGroup
    {
        public VisualStateGroup(string name = VisualStateGroup.CommonStates)
            : this(new Microsoft.Maui.Controls.VisualStateGroup())
        {
            if (string.IsNullOrEmpty(name)) name = Guid.NewGuid().ToString();
            this.Name = name;
        }

        public const string CommonStates = "CommonStates";
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.VisualState),
        containerPopertyName: "Setters")]
    public partial class VisualState
    {
        public VisualState() : this(Guid.NewGuid().ToString()) { }

        public VisualState(string name) : this(new Microsoft.Maui.Controls.VisualState())
        {
            this.Name = name;
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

