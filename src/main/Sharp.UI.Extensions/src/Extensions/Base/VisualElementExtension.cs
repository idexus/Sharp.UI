using System;
using System.Text.RegularExpressions;

namespace Sharp.UI
{
    public static partial class VisualElementExtension
    {
        // Microsoft.Maui.Controls.AbsoluteLayout

        public static T AbsoluteLayoutFlags<T>(this T obj, Microsoft.Maui.Layouts.AbsoluteLayoutFlags flags) where T : VisualElement
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.AbsoluteLayout.LayoutFlagsProperty, flags);
            return obj;
        }

        public static T AbsoluteLayoutBounds<T>(this T obj, Rect bounds) where T : VisualElement
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.AbsoluteLayout.LayoutBoundsProperty, bounds);
            return obj;
        }

        // Microsoft.Maui.Controls.SemanticProperties - attached properties

        public static T SemanticHint<T>(this T obj, string hintProperty) where T : VisualElement
        {
            obj.SetValueOrSetter(SemanticProperties.HintProperty, hintProperty);
            return obj;
        }

        public static T SemanticDescription<T>(this T obj, string description) where T : VisualElement
        {
            obj.SetValueOrSetter(SemanticProperties.DescriptionProperty, description);
            return obj;
        }

        public static T SemanticHeadingLevel<T>(this T obj, SemanticHeadingLevel headingLevel) where T : VisualElement
        {
            obj.SetValueOrSetter(SemanticProperties.HeadingLevelProperty, headingLevel);
            return obj;
        }

        // Microsoft.Maui.Controls.AutomationProperties - attached properties

        public static T AutomationExcludedWithChildren<T>(this T obj, bool? excludedWithChildren) where T : VisualElement
        {
            obj.SetValueOrSetter(AutomationProperties.ExcludedWithChildrenProperty, excludedWithChildren);
            return obj;
        }

        public static T AutomationIsInAccessibleTree<T>(this T obj, bool? isInAccessibleTree) where T : VisualElement
        {
            obj.SetValueOrSetter(AutomationProperties.IsInAccessibleTreeProperty, isInAccessibleTree);
            return obj;
        }

        public static T AutomationName<T>(this T obj, string name) where T : VisualElement
        {
            obj.SetValueOrSetter(AutomationProperties.NameProperty, name);
            return obj;
        }

        public static T AutomationHelpText<T>(this T obj, string helpText) where T : VisualElement
        {
            obj.SetValueOrSetter(AutomationProperties.HelpTextProperty, helpText);
            return obj;
        }

        public static T AutomationLabeledBy<T>(this T obj, VisualElement labeledBy) where T : VisualElement
        {
            obj.SetValueOrSetter(AutomationProperties.LabeledByProperty, labeledBy);
            return obj;
        }

        // Microsoft.Maui.Controls.VisualStateManager - attached properties

        public static T VisualStateGroups<T>(this T obj, VisualStateGroupList groups) where T : VisualElement
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.VisualStateManager.VisualStateGroupsProperty, groups);
            return obj;
        }

        // ------------

        public static T SizeRequest<T>(this T obj, double widthRequest, double heightRequest)
            where T : VisualElement
        {
            obj.SetValueOrSetter(VisualElement.WidthRequestProperty, widthRequest);
            obj.SetValueOrSetter(VisualElement.HeightRequestProperty, heightRequest);
            return obj;
        }

        public static Task<bool> AnimateSizeRequestTo<T>(this T self, double width, double height, uint length = 250, Easing easing = null)
            where T : VisualElement
        {
            Size from = new Size(self.WidthRequest, self.HeightRequest);
            Size to = new Size(width, height);
            var transform = (double t) => Transformations.SizeTransform(from, to, t);
            var callback = (Size value) => { self.SizeRequest(value.Width, value.Height); };
            return Transformations.AnimateAsync<Size>(self, "AnimateSizeRequestTo", transform, callback, length, easing);
        }
    }
}
