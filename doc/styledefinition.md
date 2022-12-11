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
    Button.TextColorProperty.Set().Light(Colors.White).Dark(AppColors.Primary),
    Button.BackgroundColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
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
        Button.TextColorProperty.Set().Light(Colors.White).Dark(AppColors.Primary),
        Button.BackgroundColorProperty.Set().Light(AppColors.Primary).Dark(Colors.White),
    },
    new VisualState(VisualState.VisualElement.Disabled)
    {
        Button.TextColorProperty.Set().Light(AppColors.Gray950).Dark(AppColors.Gray200),
        Button.BackgroundColorProperty.Set().Light(AppColors.Gray200).Dark(AppColors.Gray600),
    },
    ...
},
```
### Resource dictionary

All defined styles can be placed in the `ResourceDictionary`

```cs
new ResourceDictionary
{
    new Style<VStack>
    {
        VStack.VerticalOptionsProperty.Set(LayoutOptions.Center),
        VStack.HorizontalOptionsProperty.Set(LayoutOptions.Center)
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
