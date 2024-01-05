# Attached properties

Attached properties are properties that are defined on a type but are intended to be used with instances of other types. In `Sharp.UI`, attached properties are matched with attached property fluent methods, allowing you to set their values in a more readable and fluent manner.

For example, if you want to set the `AbsoluteLayout.LayoutBounds` attached property on a Border object, you would create an instance of Border and then use the `AbsoluteLayoutBounds` fluent method to set its value, like this:

```cs
new Border
{
    // ...
}.AbsoluteLayoutBounds(new Rect(100, 100, 200, 200));
```

This would set the `AbsoluteLayout.LayoutBounds` attached property to the specified rectangle value on the `Border` object.

## Attached properties list

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
