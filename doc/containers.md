## Containers
Sharp.UI allows you to create single and multi-element containers using braces.

#### Single item containers
Objects such as `ScrollView`, `Border`, `ContentView` etc. can contain only one element.

```cs
new Scrollview
{
    new VStack
    {
        ...
    }
}
```

#### Multi item containers
Objects such as `Grid`, `VStack` (short name for VerticalStackLayout), `HStack` (short name for HorizontalStackLayout) etc. can contain many elements.

```cs
new VStack
{
    new Label("Hello,")
        .FontSize(40),
    new Label("World!"),
    new Ellipse()
        .WidthRequest(100)
        .HeightRequest(40)
},
```