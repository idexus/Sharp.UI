# Attached properties

`Sharp.UI` matches attached properties with the attached property fluent methods.


### Attached properties list

| Maui attached property | `Sharp.UI` fluent method |
|-|-|
|`Shell.ItemTemplate`|`ShellItemTemplate()`|
|`FlyoutBase.ContextFlyout`|`ContextFlyout()`|
|`Grid.Column`|`Column()`|
|`Grid.Row`|`Row()`|
|`Grid.ColumnSpan`|`ColumnSpan()`|
|`Grid.RowSpan`|`RowSpan()`|
||`Span(column, row)`|
|`VisualStateManager.VisualStateGroups`|`VisualStateGroups()`|
|`AbsoluteLayout.LayoutFlags`|`AbsoluteLayoutFlags()`|
|`AbsoluteLayout.LayoutBounds`|`AbsoluteLayoutBounds()`|
|`Shell.PresentationMode`|`ShellPresentationMode()`|
|`ShellBackgroundColor`|`ShellBackgroundColor()`|
|`Shell.ForegroundColor`|`ShellForegroundColor()`|
|`Shell.TitleColor`|`ShellTitleColor()`|
|`Shell.DisabledColor`|`ShellDisabledColor()`|
|`Shell.UnselectedColor`|`ShellUnselectedColor()`|
|`Shell.NavBarHasShadow`|`ShellNavBarHasShadow()`|
|`Shell.NavBarIsVisible`|`ShellNavBarIsVisible()`|
|`Shell.TitleView`|`ShellTitleView()`|
|`SemanticProperties.Hint`|`SemanticHint()`|
|`SemanticProperties.Description`|`SemanticDescription()`|
|`SemanticProperties.HeadingLevel`|`SemanticHeadingLevel()`|
|`AutomationProperties.ExcludedWithChildren`|`AutomationExcludedWithChildren()`|
|`AutomationProperties.IsInAccessibleTree`|`AutomationIsInAccessibleTree()`|
|`AutomationProperties.Name`|`AutomationName()`|
|`AutomationProperties.HelpText`|`AutomationHelpText()`|
|`AutomationProperties.LabeledBy`|`AutomationLabeledBy()`|

### Example

```cs
public class GridPage : ContentPage
{
    public GridPage()
    {
        Content = new Grid
        {
            ...
        }

        this.ShellNavBarIsVisible(false);
    }
}
```