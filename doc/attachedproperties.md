# Attached properties

`Sharp.UI` matches attached properties with the attached property fluent methods.

### Example

`Shell.NavBarIsVisible` is an attached property. You can set it using the `ShellNavBarIsVisible()` fluent method.

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