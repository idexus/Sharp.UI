## Attached properties

#### Example

`Shell.NavBarIsVisible` is an attached property. In this example you can set it on the `ContentPage` using the `ShellNavBarIsVisible()` method.

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