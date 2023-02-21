# Application Styling

`Sharp.UI` provides a way to define the styles of elements using the `Style<T>` class. Here's an example of how to define the style of a button:

```cs
new Style<Button>(e => e
    .TextColor(e => e.OnLight(Colors.White).OnDark(AppColors.Primary))
    .BackgroundColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
    .FontFamily("OpenSansRegular")
    .FontSize(14)
    .CornerRadius(8)
    .Padding(new Thickness(14,10))
    .MinimumHeightRequest(44)
    .MinimumWidthRequest(44))
```

In the example, the properties of a button are set using fluent extension methods.

You can also use different values depending on the app theme, device idiom, or platform:

Additionally, you can define visual states for elements:

```cs
new Style<Button>(e => e...)
{
    ...
    new VisualState<Button> (VisualStateEnum.VisualElement.Normal, e => e
        .TextColor(e => e.OnLight(Colors.White).OnDark(AppColors.Primary))
        .BackgroundColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))),

    new VisualState<Button> (VisualStateEnum.VisualElement.Disabled, e => e
        .TextColor(e => e.OnLight(AppColors.Gray950).OnDark(AppColors.Gray200))
        .BackgroundColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray600))),
},
```
Finally, all defined styles can be placed in a `ResourceDictionary`:

```cs
new ResourceDictionary
{
    ...

    new Style<Button>(e => e
        .TextColor(e => e.OnLight(Colors.White).OnDark(AppColors.Primary))
        .BackgroundColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))
        .FontFamily("OpenSansRegular")
        .FontSize(14)
        .CornerRadius(8)
        .Padding(new Thickness(14,10))
        .MinimumHeightRequest(44)
        .MinimumWidthRequest(44))
    {
        new VisualState<Button> (VisualStateEnum.VisualElement.Normal, e => e
            .TextColor(e => e.OnLight(Colors.White).OnDark(AppColors.Primary))
            .BackgroundColor(e => e.OnLight(AppColors.Primary).OnDark(Colors.White))),

        new VisualState<Button> (VisualStateEnum.VisualElement.Disabled, e => e
            .TextColor(e => e.OnLight(AppColors.Gray950).OnDark(AppColors.Gray200))
            .BackgroundColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray600)))
    },      
        
    new Style<Frame>(e => e
        .HasShadow(false)
        .BorderColor(e => e.OnLight(AppColors.Gray200).OnDark(AppColors.Gray950))
        .CornerRadius(8)),
    ...
};
```
