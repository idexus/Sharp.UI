using System;

namespace Sharp.UI
{
    public static partial class VisualElementExtension
    {
        // Microsoft.Maui.Controls.AbsoluteLayout

        public static T AbsoluteLayoutFlags<T>(this T obj, Microsoft.Maui.Layouts.AbsoluteLayoutFlags flags) where T : VisualElement
        {
            obj.SetValue(Microsoft.Maui.Controls.AbsoluteLayout.LayoutFlagsProperty, flags);
            return obj;
        }

        public static T AbsoluteLayoutBounds<T>(this T obj, Rect bounds) where T : VisualElement
        {
            obj.SetValue(Microsoft.Maui.Controls.AbsoluteLayout.LayoutBoundsProperty, bounds);
            return obj;
        }

        // Microsoft.Maui.Controls.SemanticProperties - attached properties

        public static T SemanticHint<T>(this T obj, string hintProperty) where T : VisualElement
        {
            obj.SetValue(SemanticProperties.HintProperty, hintProperty);
            return obj;
        }

        public static T SemanticDescription<T>(this T obj, string description) where T : VisualElement
        {
            obj.SetValue(SemanticProperties.DescriptionProperty, description);
            return obj;
        }

        public static T SemanticHeadingLevel<T>(this T obj, SemanticHeadingLevel headingLevel) where T : VisualElement
        {
            obj.SetValue(SemanticProperties.HeadingLevelProperty, headingLevel);
            return obj;
        }

        // Microsoft.Maui.Controls.AutomationProperties - attached properties

        public static T AutomationExcludedWithChildren<T>(this T obj, bool? excludedWithChildren) where T : VisualElement
        {
            obj.SetValue(AutomationProperties.ExcludedWithChildrenProperty, excludedWithChildren);
            return obj;
        }

        public static T AutomationIsInAccessibleTree<T>(this T obj, bool? isInAccessibleTree) where T : VisualElement
        {
            obj.SetValue(AutomationProperties.IsInAccessibleTreeProperty, isInAccessibleTree);
            return obj;
        }

        public static T AutomationName<T>(this T obj, string name) where T : VisualElement
        {
            obj.SetValue(AutomationProperties.NameProperty, name);
            return obj;
        }

        public static T AutomationHelpText<T>(this T obj, string helpText) where T : VisualElement
        {
            obj.SetValue(AutomationProperties.HelpTextProperty, helpText);
            return obj;
        }

        public static T AutomationLabeledBy<T>(this T obj, VisualElement labeledBy) where T : VisualElement
        {
            obj.SetValue(AutomationProperties.LabeledByProperty, labeledBy);
            return obj;
        }

        // Microsoft.Maui.Controls.VisualStateManager - attached properties

        public static T VisualStateGroups<T>(this T obj, Microsoft.Maui.Controls.VisualStateGroupList groups) where T : VisualElement
        {
            obj.SetValue(Microsoft.Maui.Controls.VisualStateManager.VisualStateGroupsProperty, groups);
            return obj;
        }

        // ------------

        public static T SizeRequest<T>(this T obj, double widthRequest, double heightRequest)
            where T : VisualElement
        {
            obj.WidthRequest = widthRequest;
            obj.HeightRequest = heightRequest;
            return obj;
        }
    }
}