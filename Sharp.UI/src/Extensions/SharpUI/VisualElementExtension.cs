using System;

namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.SemanticProperties))]
    public interface IVisualElementSemanticProperties
    {
        [AttachedName("Hint")]
        string SemanticHint { get; set; }

        [AttachedName("Description")]
        string SemanticDescription { get; set; }

        [AttachedName("HeadingLevel")]
        SemanticHeadingLevel SemanticHeadingLevel { get; set; }
    }

    [AttachedProperties(typeof(Microsoft.Maui.Controls.AutomationProperties))]
    public interface IVisualElementAutomationProperties
    {
        [AttachedName("ExcludedWithChildren")]
        bool? AutomationExcludedWithChildren { get; set; }

        [AttachedName("IsInAccessibleTree")]
        bool? AutomationIsInAccessibleTree { get; set; }

        [AttachedName("Name")]
        string AutomationName { get; set; }

        [AttachedName("HelpText")]
        string AutomationHelpText { get; set; }

        [AttachedName("LabeledBy")]
        Microsoft.Maui.Controls.VisualElement AutomationLabeledBy { get; set; }
    }

    [AttachedProperties(typeof(Microsoft.Maui.Controls.VisualStateManager))]
    public interface IVisualElementVisualStateGroupsAttachedProperties
    {
        Microsoft.Maui.Controls.VisualStateGroupList VisualStateGroups { get; set; }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.VisualElement))]
    [AttachedInterfaces(new[] {typeof(IVisualElementVisualStateGroupsAttachedProperties), typeof(IVisualElementAutomationProperties), typeof(IVisualElementSemanticProperties) })]
	public static class VisualElementExtension
    {
        public static T SizeRequest<T>(this T obj, double widthRequest, double heightRequest)
            where T : IVisualElement
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.VisualElement>(obj);
            mauiObject.WidthRequest = widthRequest;
            mauiObject.HeightRequest = heightRequest;
            return obj;
        }
    }
}