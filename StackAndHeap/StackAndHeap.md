# Stack vs. Heap

## Stack

Stack means that when you enter a function variables are put on the stack and as soon the function returns the variables are removed from the stack.

```csharp
int CalculateSomething(int n)
{


    // "factor" is an int, therefore a value type and therefore it lives on the stack.
    var factor = 42;

    // "n" is an int, therefore a value type and therefore it lives on the stack.
    return factor * n; // return values always go over the stack.

    // Note: factor can not be accessed outside of CalculateSomething because it lives on the stack of CalculateSomething.
}
```

```csharp
int CalculateSomethingRecursive(int n)
{
    if (n == 0) return 0;

    var factor = 42;
    return factor * CalculateSomethingRecursive(n - 1);

    // Q: What is happening with factor?
    // A: With every new call of a function you get new variables on the stack. 
    //    So the second time CalculateSomethingRecursive is called you get a second intance of the factor variable on the stack.

    // The variables are removed from the stack as soon the function returns. 
    // Meaning if the first CalculateSomethingRecursive is returns also the first factor variable will be removed from the stack.
}
```
## Heap

Describe me