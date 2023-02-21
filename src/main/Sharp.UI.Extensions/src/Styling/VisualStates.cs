namespace Sharp.UI
{
    public class VisualStates
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

