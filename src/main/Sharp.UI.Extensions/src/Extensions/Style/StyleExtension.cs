namespace Sharp.UI
{
    public static class StyleExtension
    {
        public static Microsoft.Maui.Controls.VisualStateGroupList GetVisualStateGroupList(this Style style)
        {
            Microsoft.Maui.Controls.VisualStateGroupList groupList = null;
            var groupListSetter = style.Setters.FirstOrDefault(e => e.Property == VisualStateManager.VisualStateGroupsProperty);
            if (groupListSetter != null)
            {
                groupList = groupListSetter.Value as Microsoft.Maui.Controls.VisualStateGroupList;
            }
            if (groupList == null)
            {
                groupList = new VisualStateGroupList();
                var setter = new Setter { Property = VisualStateManager.VisualStateGroupsProperty, Value = groupList };
                style.Setters.Add(setter);
            }
            return groupList;
        }
    }
}