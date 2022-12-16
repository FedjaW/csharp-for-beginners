﻿// A higher order function is a function that takes and or returns a function.

Func<int, int> calculator = CreateCalculator();
System.Console.WriteLine(calculator(2));

// Pattern: So called "Factory pattern".
// We are creating a factory for functions.
Func<int, int> CreateCalculator()
{
    // factor lives on the stack.
    // But it is used outside of "CreateCalculator()".
    // It is used when "calculator(2)" is called.
    // So factor can not live on the stack, because then it would not exist after "CreateCalculator()" was called.
    // The indicator for that is that factor has a shorter live than the function we return.
    // Solution: C# is promoting factor from the stack to the heap.
    // This is called a closure!
    // Technical term is: The lambda method captures factor.
    var factor = 42;
    return n => n * factor;

    // What C# behind the scenes does is:
    // Binding the livetime of factor to the lambda method.
    // Essentially C# is rewriting the lambda function by creating a class like BehindTheScenes
    // 
}

// C# is creating an instance of this autogenerated class (which I called BehindTheScenes)
// to get an reference type which lives on the heap, so that factor will live as long the instance live
// So factor is bind to the function Calculator aka lambda function which we return and will be called at any point in time.
// This mechanism promotes a local variable (value type) from the stack to the heap.
// In other words: factor is no longer a value type on the stack, but a member of a class and created on the heap.
BehindTheScenes CreateCalculatorInternal()
{
    return new BehindTheScenes { factor = 42 };
}

// Just for explanation of C#'s behind the scenes to make closures happen.
class BehindTheScenes
{
    public int factor;
    public int Calculator(int n) => n * factor;
}