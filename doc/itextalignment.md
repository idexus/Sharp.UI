# ITextAlignment interface extension methods

In Sharp.UI, all classes that implement the `ITextAlignment` interface get the following extension methods:

- `TextCenterHorizontal`
- `TextCenterVertical`
- `TextCenter`
- `TextStart`
- `TextEnd`
- `TextBottom`
- `TextBottomStart`
- `TextBottomEnd`
- `TextTop`
- `TextTopStart`
- `TextTopEnd`

## Usage

To use the extension methods, create a `Label` object (or any object that implements `ITextAlignment`), and call the desired method:

```cs
Label().TextCenter()
```

This example centers the text both horizontally and vertically within the label's containing element.