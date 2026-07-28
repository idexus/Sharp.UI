## Multi-Bindings

Sometimes a target property needs to combine values from more than one source. Call `.Path()` more than once inside the same builder — each call opens a new sub-binding, and `Source()` / `StringFormat()` / `BindingMode()` / `Convert()` apply to whichever `Path()` was opened last. Each sub-binding can therefore have its own `Convert()`, which transforms that source's raw value before it reaches the combining step — as with `slider1` below, whose raw `double` is converted to a `bool` first. A trailing typed `MultiConvert()` combines all collected values into the final result; its parameter types and count must match the values produced by each `Path()`, in order — either the source's raw type, or the result type of that `Path()`'s own `Convert()` if one was set. Its return type is the type of the target property.

```cs
new VStack
{
    new Slider(out var slider1)
        .Minimum(1).Maximum(30),

    new Slider(out var slider2)
        .Minimum(1).Maximum(30),

    new Slider(out var slider3)
        .Minimum(1).Maximum(30),

    new Slider(out var slider4)
        .Minimum(1).Maximum(30),

    new Label()
        .Text(e => e
            .Path(nameof(Slider.Value)).Source(slider1).Convert((double v) => v > 10)
            .Path(nameof(Slider.Value)).Source(slider2)
            .Path(nameof(Slider.Value)).Source(slider3)
            .Path(nameof(Slider.Value)).Source(slider4)
            .MultiConvert((bool v1, double v2, double v3, double v4) =>
            {
                return $"{v1}, {v2:F2}, {v3:F2}, {v4:F2}";
            }))
}
```

Here, the `Label`'s text is recomputed automatically whenever any of the four sliders changes, since each `Path()` creates its own binding to that slider's `Value` property. `slider1`'s value is first converted to a `bool` by the `Convert()` attached to its own `Path()`, so `MultiConvert()` receives it as `v1: bool` while `v2`–`v4` arrive as the raw `double` values from their sliders.

The two names mark the two roles: `Convert()` always belongs to the `Path()` it follows, `MultiConvert()` always closes the builder. Forgetting the second one is caught in `Build()` with a message naming the arity you need.

A multi-binding does not fire until every one of its sources has produced a value; until then the target keeps whatever it had. If any source is `null`, the update is skipped rather than pushing `null` into the target property.

### Two-way multi-bindings

For two-way scenarios, use `MultiConvertBack()` with a matching arity, returning a tuple in the same order as the `Path()` calls. Each element of that tuple then passes through the `ConvertBack()` of its own `Path()`, if one was declared — so a path whose `Convert()` changes the value type needs a matching `ConvertBack()` to be writable.

```cs
new Entry()
    .Text(e => e
        .Path(nameof(Rect.Width)).Source(rect)
        .Path(nameof(Rect.Height)).Source(rect)
        .MultiMode(BindingMode.TwoWay)
        .MultiConvert((double w, double h) => $"{w:F0} x {h:F0}")
        .MultiConvertBack((string s) =>
        {
            var parts = s.Split('x');
            return (double.Parse(parts[0].Trim()), double.Parse(parts[1].Trim()));
        }))
```

`MultiMode()` sets the mode of the whole `MultiBinding`; an individual `Path()` can still override it with its own `BindingMode()`, which is how you keep one of the sources read-only.

### Dynamic number of bindings

When the number of `Path()` calls is not known in advance, use `MultiConvertRaw()`. It skips the arity check that `MultiConvert()` performs in `Build()`, and comes in two forms.

The typed form takes the values already unboxed to a single type, with the same diagnostics `MultiConvert()` gives you — a mismatch names the offending path and value index instead of throwing a raw cast error:

```cs
new Button()
    .IsEnabled(e => e
        .Path(nameof(Entry.Text)).Source(nameEntry).Convert((string s) => !string.IsNullOrWhiteSpace(s))
        .Path(nameof(Entry.Text)).Source(emailEntry).Convert((string s) => !string.IsNullOrWhiteSpace(s))
        .Path(nameof(Entry.Text)).Source(phoneEntry).Convert((string s) => !string.IsNullOrWhiteSpace(s))
        .MultiConvertRaw<bool>(values =>
        {
            for (var i = 0; i < values.Count; i++)
                if (!values[i]) return false;
            return true;
        }))
```

The untyped form hands you the raw `object[]` in `Path()` order plus an optional inverse. Use it only when the sources genuinely have different types and you want to inspect them yourself; you are responsible for the casts:

```cs
.MultiConvertRaw(
    values => Describe(values),
    value => Split(value))
```

### Boolean aggregates

The typed form above is what the built-in boolean helpers are built on, so the common cases need no lambda at all:

```cs
new Button()
    .IsEnabled(e => e
        .Path(nameof(CheckBox.IsChecked)).Source(terms)
        .Path(nameof(CheckBox.IsChecked)).Source(privacy)
        .Path(nameof(CheckBox.IsChecked)).Source(marketing)
        .MultiAll())
```

| Helper | True when |
| --- | --- |
| `MultiAll()` | every source is `true` |
| `MultiAny()` | at least one source is `true` |
| `MultiNone()` | no source is `true` |
| `MultiAtLeast(n)` | at least `n` sources are `true` |
| `MultiExactly(n)` | exactly `n` sources are `true` |

They apply to a `bool` target property and expect every path to produce a `bool` — either directly, or through that path's own `Convert()`, as in the validation example above.

Because these run on the dynamic-arity path, `Build()` does not check the count of `Path()` calls against anything. `MultiAtLeast(3)` over two paths is therefore always `false` rather than a build-time error.