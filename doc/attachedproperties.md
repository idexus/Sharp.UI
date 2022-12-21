# Attached properties

`Sharp.UI` matches attached properties with the attached property fluent methods.


### Attached properties list

| Maui attached property | `Sharp.UI` fluent method |
|-|-|
|`Shell.ItemTemplate`|`ShellItemTemplate(shellItemTemplate)`|
|`FlyoutBase.ContextFlyout`|`ContextFlyout(contextFlyout)`|
|`Grid.Column`|`Column(column)`|
|`Grid.Row`|`Row(row)`|
|`Grid.ColumnSpan`|`ColumnSpan(rowSpan)`|
|`Grid.RowSpan`|`RowSpan(columnSpan)`|
||`Span(column, row)`|
|`VisualStateManager.VisualStateGroups`|`VisualStateGroups(visualStateGroups)`|
|`AbsoluteLayout.LayoutFlags`|`AbsoluteLayoutFlags(layoutFlags)`|
|`AbsoluteLayout.LayoutBounds`|`AbsoluteLayoutBounds(layoutBounds)`|
|`Shell.PresentationMode`|`ShellPresentationMode(presentationMode)`|
|`ShellBackgroundColor`|`ShellBackgroundColor(backgroundColor)`|
|`Shell.ForegroundColor`|`ShellForegroundColor(foregroundColor)`|
|`Shell.TitleColor`|`ShellTitleColor(titleColor)`|
|`Shell.DisabledColor`|`ShellDisabledColor(disabledColor)`|
|`Shell.UnselectedColor`|`ShellUnselectedColor(unselectedColor)`|
|`Shell.NavBarHasShadow`|`ShellNavBarHasShadow(navBarHasShadow)`|
|`Shell.NavBarIsVisible`|`ShellNavBarIsVisible(navBarIsVisible)`|
|`Shell.TitleView`|`ShellTitleView(titleView)`|
|`SemanticProperties.Hint`|`SemanticHint(hint)`|
|`SemanticProperties.Description`|`SemanticDescription(description)`|
|`SemanticProperties.HeadingLevel`|`SemanticHeadingLevel(headingLevel)`|
|`AutomationProperties.ExcludedWithChildren`|`AutomationExcludedWithChildren(excludedWithChildren)`|
|`AutomationProperties.IsInAccessibleTree`|`AutomationIsInAccessibleTree(isInAccessibleTree)`|
|`AutomationProperties.Name`|`AutomationName(name)`|
|`AutomationProperties.HelpText`|`AutomationHelpText(helpText)`|
|`AutomationProperties.LabeledBy`|`AutomationLabeledBy(labeledBy)`|

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