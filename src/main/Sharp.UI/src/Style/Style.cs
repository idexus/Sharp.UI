using System.Collections;

namespace Sharp.UI
{
    [SharpObject]
    public partial class Style<T> : IEnumerable // TODO: sealed
    {
        Microsoft.Maui.Controls.Style mauiStyle;
        public static implicit operator Style(Style<T> style) => style.mauiStyle;

        public Style()
        {
            mauiStyle = new Microsoft.Maui.Controls.Style(typeof(T));
        }

        public Style(bool applyToDerivedTypes) : this() { }
        
        Microsoft.Maui.Controls.VisualStateGroupList GetVisualStateGroupList()
        {
            Microsoft.Maui.Controls.VisualStateGroupList groupList = null;
            var groupListSetter = this.mauiStyle.Setters.FirstOrDefault(e => e.Property == VisualStateManager.VisualStateGroupsProperty);
            if (groupListSetter != null)
            {
                groupList = groupListSetter.Value as Microsoft.Maui.Controls.VisualStateGroupList;
            }
            if (groupList == null)
            {
                groupList = new VisualStateGroupList();
                var setter = new Setter { Property = VisualStateManager.VisualStateGroupsProperty, Value = groupList };
                this.mauiStyle.Setters.Add(setter);
            }
            return groupList;
        }

        Microsoft.Maui.Controls.VisualStateGroup GetCommonStatesVisualStateGroup(Microsoft.Maui.Controls.VisualStateGroupList visualStateGroupList)
        {
            var visualStateGroup = visualStateGroupList.FirstOrDefault(e => e.Name.Equals(VisualStateGroup.CommonStates));
            if (visualStateGroup == null)
            {
                visualStateGroup = new Microsoft.Maui.Controls.VisualStateGroup { Name = VisualStateGroup.CommonStates };
                visualStateGroupList.Add(visualStateGroup);
            }
            return visualStateGroup;
        }

        public void Add(Setter setter) => this.mauiStyle.Setters.Add(setter);
        public void Add(Trigger trigger) => this.mauiStyle.Triggers.Add(trigger);
        public void Add(DataTrigger trigger) => this.mauiStyle.Triggers.Add(trigger);
        public void Add(VisualStateGroupList groupList)
        {
            var setter = new Setter { Property = VisualStateManager.VisualStateGroupsProperty, Value = groupList };
            this.mauiStyle.Setters.Add(setter);
        }

        public void Add(VisualStateGroup group)
        {
            GetVisualStateGroupList().Add(group);
        }

        public void Add(VisualState visualState)
        {
            var visualStateGroupList = GetVisualStateGroupList();
            GetCommonStatesVisualStateGroup(visualStateGroupList).States.Add(visualState);
        }

        IEnumerator IEnumerable.GetEnumerator() => mauiStyle.Setters.GetEnumerator();
    }
}