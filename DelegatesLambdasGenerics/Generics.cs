namespace DelegatesAndLambdas.Generics;

// Q: What is a generic?
// A: Generics allow you to pass in a type as parameter.

public class LearnGenerics 
{

    void ExecuteSomewhere()
    {
        CalculateAndPrint(30, 10, (a, b) => a + b);
        CalculateAndPrint("A", "B", (a, b) => a + b);
        CalculateAndPrint(true, true, (a, b) => a && b);
    }

    static void CalculateAndPrint<T>(T x, T y, Combine<T> f)
    {
        var result = f(x, y);
        Console.WriteLine(result);
    }

    delegate T Combine<T>(T a, T b); // T is type paramater
}