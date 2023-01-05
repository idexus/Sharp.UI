# Application styling

### `Style<T>`
Using the `Style<T>` class you can define the style of the elements

```cs
new Style<Button>
{
    Button.FontSizeProperty.Set(14),
    Button.CornerRadiusProperty.Set(8)
    ...
}
```

You define setter values using `BindableProperty` `Set()` extension method.

### Theme, device idiom and platform

If you want to use different values depending on your app theme, device idiom, or platform, you can combine following methods.

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

### Visual states
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
### Resource dictionary

All defined styles can be placed in the `ResourceDictionary`

```cs
new ResourceDictionary
{
    new Style<Button>
    {
        Button.TextColorProperty.Set().OnLight(Colors.White).OnDark(AppColors.Primary),
        Button.BackgroundColorProperty.Set().OnLight(AppColors.Primary).OnDark(Colors.White),
        Button.FontFamilyProperty.Set("OpenSansRegular"),
        Button.FontSizeProperty.Set(14),
        Button.CornerRadiusProperty.Set(8),
        Button.PaddingProperty.Set(new Thickness(14,10)),
        Button.MinimumHeightRequestProperty.Set(44),
        Button.MinimumWidthRequestProperty.Set(44),

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
