namespace Sharp.UI
{
    public static class VisualStateGroupListExtension
    {
        public static VisualStateGroup GetCommonStatesVisualStateGroup(this VisualStateGroupList visualStateGroupList)
        {
            var visualStateGroup = visualStateGroupList.FirstOrDefault(e => e.Name.Equals("CommonStates"));
            if (visualStateGroup == null)
            {
                visualStateGroup = new Microsoft.Maui.Controls.VisualStateGroup { Name = "CommonStates" };
                visualStateGroupList.Add(visualStateGroup);
            }
            return visualStateGroup;
        }

        public static void Add(this VisualStateGroupList visualStateGroupList, Microsoft.Maui.Controls.VisualState visualState)
        {
            visualStateGroupList.GetCommonStatesVisualStateGroup().States.Add(visualState);
        }
    }
}


