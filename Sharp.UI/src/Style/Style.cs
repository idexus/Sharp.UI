using System.Collections;

namespace Sharp.UI
{
    public class Style<T> : Style
    {
        public Style(bool applyToDerivedTypes = false, bool canCascade = false, string styleClass = null)
            : base(MauiWrapper.GetMauiType<T>(), applyToDerivedTypes, canCascade, styleClass)
        {

        }
    }    

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Style),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class Style
    {
        public Style(Type type, bool applyToDerivedTypes = false, bool canCascade = false, string styleClass = null)
        {
            this.MauiObject = new Microsoft.Maui.Controls.Style(type);
            this.MauiObject.ApplyToDerivedTypes = applyToDerivedTypes;
            this.MauiObject.CanCascade = canCascade;
            this.MauiObject.Class = styleClass;
        }

        Microsoft.Maui.Controls.VisualStateGroupList GetVisualStateGroupList()
        {
            Microsoft.Maui.Controls.VisualStateGroupList groupList = null;
            var groupListSetter = Setters.FirstOrDefault(e => e.Property == VisualStateManager.VisualStateGroupsProperty);
            if (groupListSetter != null)
            {
                groupList = groupListSetter.Value as Microsoft.Maui.Controls.VisualStateGroupList;
            }
            if (groupList == null)
            {
                groupList = new VisualStateGroupList();
                var setter = new Setter { Property = VisualStateManager.VisualStateGroupsProperty, Value = groupList };
                this.Setters.Add(setter);
            }
            return groupList;
        }

        VisualStateGroup GetCommonStatesVisualStateGroup(Microsoft.Maui.Controls.VisualStateGroupList visualStateGroupList)
        {
            var visualStateGroup = visualStateGroupList.FirstOrDefault(e => e.Name.Equals(VisualStateGroup.CommonStates));
            if (visualStateGroup == null)
            {
                visualStateGroup = new VisualStateGroup(VisualStateGroup.CommonStates);
                visualStateGroupList.Add(visualStateGroup);
            }
            return visualStateGroup;
        }

        public void Add(Trigger trigger) => this.MauiObject.Triggers.Add(trigger);
        public void Add(DataTrigger trigger) => this.MauiObject.Triggers.Add(trigger);
        public void Add(VisualStateGroupList groupList)
        {
            var setter = new Setter { Property = VisualStateManager.VisualStateGroupsProperty, Value = groupList };
            this.Setters.Add(setter);
        }

        public void Add(VisualStateGroup group)
        {
            GetVisualStateGroupList().Add(group);
        }

        public void Add(VisualState visualState)
        {
            var visualStateGroupList = GetVisualStateGroupList();
            GetCommonStatesVisualStateGroup(visualStateGroupList).Add(visualState);
        }
    }
}