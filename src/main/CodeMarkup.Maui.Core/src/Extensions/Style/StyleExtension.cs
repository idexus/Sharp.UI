namespace CodeMarkup.Maui
{
    public static class StyleExtension
    {
        public static VisualStateGroupList GetVisualStateGroupList(this Style self)
        {
            VisualStateGroupList groupList = null;
            var groupListSetter = self.Setters.FirstOrDefault(e => e.Property == VisualStateManager.VisualStateGroupsProperty);
            if (groupListSetter != null)
            {
                groupList = groupListSetter.Value as VisualStateGroupList;
            }
            if (groupList == null)
            {
                groupList = new VisualStateGroupList();
                var setter = new Setter { Property = VisualStateManager.VisualStateGroupsProperty, Value = groupList };
                self.Setters.Add(setter);
            }
            return groupList;
        }
    }
}