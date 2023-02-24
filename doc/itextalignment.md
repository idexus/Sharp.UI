# ITextAlignment interface extension methods

In Sharp.UI, all classes that implement the `ITextAlignment` interface get the following extension methods:

- `CenterTextHorizontally`
- `CenterTextVertically`
- `CenterText`
- `AlignTextLeft`
- `AlignTextRight`
- `AlignTextBottom`
- `AlignTextBottomLeft`
- `AlignTextBottomRight`
- `AlignTextTop`
- `AlignTextTopLeft`
- `AlignTextTopRight`
- `AlignTextJustified`

## Usage

To use the extension methods, create a `Label` object (or any object that implements `ITextAlignment`), and call the desired method:

```cs
Label().CenterText()
```

This example centers the text both horizontally and vertically within the label's containing element.