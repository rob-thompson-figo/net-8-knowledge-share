using System.Diagnostics.CodeAnalysis;
using Point2d = (int X, int Y); //Feature 1: Type Aliases - allows you to create a new name for an existing type


Console.WriteLine("Hello, World!");

//Feature 2: Default or optional params for lambda functions
var lambda = (string s = "Default Parameters") => $"Lambda functions can have {s}!";

Console.WriteLine($"Feature 1: {lambda()}");

int[] xCoordinates = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]; //Feature 3: Array Initializers - previously the syntax was -> new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
int[] yCoordinates = [0, 1, 4, 9, 16, 25, 36, 49, 64, 81];

#pragma warning disable EXPERIMENTAL_FEATURE //comment this out to see what experimental feature attribute does
Buffer buffer = new();

for (int i = 0; i < Buffer.Length; i++)
{
    buffer[i] = (xCoordinates[i], yCoordinates[i]);
    Console.WriteLine($"Coordinates: ({buffer[i].X},{buffer[i].Y})");
}




//below are the attributes that feed the demo


//Feature 4: InlineArray attribute - allows you to specify the number of elements in an array.
//This is a feature that is used to optimize performance by allocating the array on the stack instead of heap,
//avoiding a garbage collection.
[System.Runtime.CompilerServices.InlineArray(10)]

//Feature 5: Experimental attribute - allows you to mark a feature as experimental,
//which means that it is not yet stable and may change in future versions of the language.
//Experimental features are disabled by default and can be enabled with a #pragma compiler flag.
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