
# How to assign object references
There are two main ways to assign objects in `Sharp.UI`. 

Using the `Assign` method 

```cs
new Label().Assign(out label)
```

or using a constructor parameter

```cs
new Label(out label)
```