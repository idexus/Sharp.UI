# Layout options

In Sharp.UI, you can layout every view in their container using the following extension methods:

- `CenterHorizontally`
- `CenterVertically`
- `CenterInContainer`
- `AlignStart`
- `AlignEnd`
- `AlignTop`
- `AlignTopStart`
- `AlignTopEnd`
- `AlignBottom`
- `AlignBottomStart`
- `AlignBottomEnd`
- `FillHorizontally`
- `FillVertically`
- `FillBothDirections`

## Usage

To use the layout options, create a container view (such as `HStack` or `VStack`), add the view you want to layout to the container, and call the desired method:

```cs
new VStack
{
    new Label("Hello, World!").CenterHorizontally()
}
```

This example centers a Label inside a `VStack` container. You can use the same method with other container views, and with any view that you want to lay out within its containing element.