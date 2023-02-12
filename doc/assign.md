
# How to assign object references

There are two main ways to assign objects in `Sharp.UI`: 

- using the `Assign` method,
- using a constructor parameter.

The first example uses the `Assign` method to assign a label object to a variable named label. This is done using the following code:

```cs
new Label().Assign(out label)
```

The second example uses a constructor parameter to achieve the same result. This is done using the following code:

```cs
new Label(out label)
```