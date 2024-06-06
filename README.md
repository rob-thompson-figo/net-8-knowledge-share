# .NET 8 C# Demo

This repository provides a demonstration of some of the new features in C# and .NET 8. While .NET 8 has a strong focus on Blazor, Ahead-of-Time (AOT) compilation, and other enhancements, this demo highlights a few specific features that are directly relevant to our team.

## Features Demonstrated

### 1. Type Aliases
Type aliases allow you to create a new name for an existing type. In this demo, we alias a tuple of two integers `(int X, int Y)` to `Point2d`.

```csharp
using Point2d = (int X, int Y);

Console.WriteLine("Hello, World!");
```

### 2.Default or Optional Parameters for Lambda Functions
Lambda functions can now have default parameters.

```csharp
var lambda = (string s = "Default Parameters") => $"Lambda functions can have {s}!";
Console.WriteLine($"Feature 1: {lambda()}");
```

### 3. Array Initializers
The syntax for initializing arrays has been simplified.

```csharp
int[] xCoordinates = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
int[] yCoordinates = [0, 1, 4, 9, 16, 25, 36, 49, 64, 81];
```

### 4. InlineArray Attribute
The `InlineArray` attribute allows you to specify the number of elements in an array, optimizing performance by allocating the array on the stack instead of the heap, which helps avoid garbage collection.

```csharp
[System.Runtime.CompilerServices.InlineArray(10)]
public struct Buffer
{
    private Point2d _element0;
    public const int Length = 10;

    public Point2d this[int index]
    {
        get
        {
            unsafe
            {
                fixed (Point2d* ptr = &_element0)
                {
                    return ptr[index];
                }
            }
        }
        set
        {
            unsafe
            {
                fixed (Point2d* ptr = &_element0)
                {
                    ptr[index] = value;
                }
            }
        }
    }
}
```

### 5. Experimental Attribute
The `Experimental` attribute allows you to mark a feature as experimental, indicating that it is not yet stable and may change in future versions of the language. Experimental features are disabled by default and can be enabled with a `#pragma` compiler flag.

```csharp
[Experimental("EXPERIMENTAL_FEATURE")]
public struct Buffer
{
    private Point2d _element0;
    public const int Length = 10;

    public Point2d this[int index]
    {
        get
        {
            unsafe
            {
                fixed (Point2d* ptr = &_element0)
                {
                    return ptr[index];
                }
            }
        }
        set
        {
            unsafe
            {
                fixed (Point2d* ptr = &_element0)
                {
                    ptr[index] = value;
                }
            }
        }
    }
}

```

## Note
The rest of .NET 8 is centered around Blazor, AOT (Ahead-of-Time) compilation, and other features not pertinent to our team.

Feel free to explore these new features and integrate them into your projects where appropriate.
