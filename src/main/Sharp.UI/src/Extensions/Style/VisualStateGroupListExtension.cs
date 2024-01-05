namespace Sharp.UI
{
    public static class VisualStateGroupListExtension
    {
        public static VisualStateGroup GetCommonStatesVisualStateGroup(this VisualStateGroupList self)
        {
            var visualStateGroup = self.FirstOrDefault(e => e.Name.Equals("CommonStates"));
            if (visualStateGroup == null)
            {
                visualStateGroup = new VisualStateGroup { Name = "CommonStates" };
                self.Add(visualStateGroup);
            }
            return visualStateGroup;
        }

        public static void Add(this VisualStateGroupList self, VisualState visualState)
        {
            self.GetCommonStatesVisualStateGroup().States.Add(visualState);
        }
    }
}


