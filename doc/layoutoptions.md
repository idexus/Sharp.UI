# Layout options

In Sharp.UI, you can layout every view in their container using the following extension methods:

- `CenterHorizontally`
- `CenterVertically`
- `Center`
- `PlaceStart`
- `PlaceEnd`
- `PlaceTop`
- `PlaceTopStart`
- `PlaceTopEnd`
- `PlaceBottom`
- `PlaceBottomStart`
- `PlaceBottomEnd`
- `FillHorizontally`
- `FillVertically`
- `FillBothDirections`

## Usage

To use the layout options, create a container view (such as `HStack` or `VStack`), add the view you want to layout to the container, and call the desired method:

```cs
new VStack
{
    new Label("Hello, World!").Center()
}
```

This example centers a Label inside a `VStack` container. You can use the same method with other container views, and with any view that you want to lay out within its containing element.