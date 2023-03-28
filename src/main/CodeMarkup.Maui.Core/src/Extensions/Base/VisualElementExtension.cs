using System;
using System.Text.RegularExpressions;


namespace CodeMarkup.Maui
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.SemanticProperties))]
    public interface IVisualElementSemanticProperties
    {
        [AttachedName("HintProperty")]
        string SemanticHint { get; set; }

        [AttachedName("DescriptionProperty")]
        string SemanticDescription { get; set; }

        [AttachedName("HeadingLevelProperty")]
        SemanticHeadingLevel SemanticHeadingLevel { get; set; }
    }

    [AttachedProperties(typeof(Microsoft.Maui.Controls.AutomationProperties))]
    public interface IVisualElementAutomationProperties
    {
        [AttachedName("ExcludedWithChildrenProperty")]
        bool? AutomationExcludedWithChildren { get; set; }

        [AttachedName("IsInAccessibleTreeProperty")]
        bool? AutomationIsInAccessibleTree { get; set; }

        [AttachedName("NameProperty")]
        string AutomationName { get; set; }

        [AttachedName("HelpTextProperty")]
        string AutomationHelpText { get; set; }

        [AttachedName("LabeledByProperty")]
        Microsoft.Maui.Controls.VisualElement AutomationLabeledBy { get; set; }
    }

    [AttachedProperties(typeof(Microsoft.Maui.Controls.VisualStateManager))]
    public interface IVisualElementVisualStateGroupsAttachedProperties
    {
        Microsoft.Maui.Controls.VisualStateGroupList VisualStateGroups { get; set; }
    }

    [CodeMarkup]
    [AttachedInterfaces(typeof(Microsoft.Maui.Controls.VisualElement),
        new[] 
        { 
            typeof(IVisualElementVisualStateGroupsAttachedProperties), 
            typeof(IVisualElementAutomationProperties), 
            typeof(IVisualElementSemanticProperties) 
        })]
    public static partial class VisualElementExtension
    {
        // ------------

        public static T SizeRequest<T>(this T self, double widthRequest, double heightRequest)
            where T : VisualElement
        {
            self.SetValue(VisualElement.WidthRequestProperty, widthRequest);
            self.SetValue(VisualElement.HeightRequestProperty, heightRequest);
            return self;
        }

        public static SettersContext<T> SizeRequest<T>(this SettersContext<T> self, double widthRequest, double heightRequest)
            where T : VisualElement
        {
            self.XamlSetters.Add(new Setter { Property = VisualElement.WidthRequestProperty, Value = widthRequest });
            self.XamlSetters.Add(new Setter { Property = VisualElement.HeightRequestProperty, Value = heightRequest });
            return self;
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
