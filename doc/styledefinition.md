# Application Styling

`Sharp.UI` provides a way to define the styles of elements using the `Style<T>` class. Here's an example of how to define the style of a button:

```cs
new Style<Button>
{
    Button.FontSizeProperty.Set(14),
    Button.CornerRadiusProperty.Set(8)
    ...
}
```

In the example, the properties of a button are set using the BindableProperty `Set()` extension method.

You can also use different values depending on the app theme, device idiom, or platform:

```cs
new Style<Button>
{
    Button.TextColorProperty.Set().OnLight(Colors.White).OnDark(AppColors.Primary),
    Button.BackgroundColorProperty.Set().OnLight(AppColors.Primary).OnDark(Colors.White),
    Button.FontSizeProperty.Set(14).OnDesktop(20),
    Button.CornerRadiusProperty.Set(8).OniOS(15),
    ...
}
```

Additionally, you can define visual states for elements:

```cs
new Style<Button>
{
    ...
    new VisualState(VisualState.VisualElement.Normal)
    {
        Button.TextColorProperty.Set().OnLight(Colors.White).OnDark(AppColors.Primary),
        Button.BackgroundColorProperty.Set().OnLight(AppColors.Primary).OnDark(Colors.White),
    },
    new VisualState(VisualState.VisualElement.Disabled)
    {
        Button.TextColorProperty.Set().OnLight(AppColors.Gray950).OnDark(AppColors.Gray200),
        Button.BackgroundColorProperty.Set().OnLight(AppColors.Gray200).OnDark(AppColors.Gray600),
    },
    ...
},
```
Finally, all defined styles can be placed in a `ResourceDictionary`:

```cs
new ResourceDictionary
{
    new Style<Button>
    {
        Button.TextColorProperty.Set().OnLight(Colors.White).OnDark(AppColors.Primary),
        Button.BackgroundColorProperty.Set().OnLight(AppColors.Primary).OnDark(Colors.White),
        ...

        new VisualState(VisualState.VisualElement.Normal)
        {
            Button.TextColorProperty.Set().OnLight(Colors.White).OnDark(AppColors.Primary),
            Button.BackgroundColorProperty.Set().OnLight(AppColors.Primary).OnDark(Colors.White),
        },

        ...
    },          
      
    new Style<Label>
    {
        Label.TextColorProperty.Set(Colors.Red),
        Label.FontSizeProperty.Set(30.0),
        Label.MarginProperty.Set(new Thickness(10,10)),
        Label.HorizontalOptionsProperty.Set(LayoutOptions.Center),
        ...
    },
    ...
};
```
