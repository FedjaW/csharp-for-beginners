namespace DelegatesAndLambdas.Generics;

// Q: What is a generic?
// A: A generic is 

public class LearnGenerics 
{

    void ExecuteSomewhere()
    {
        CalculateAndPrint(30, 10, (a, b) => a + b);
    }

    static int Add(int x, int y)
    {
        return x + y;
    }

    static int Substract(int a, int b)
    {
        return a - b;
    }

    static void CalculateAndPrint(int x, int y, MathOp f)
    {
        var result = f(x, y);
        Console.WriteLine(result);
    }

    delegate int MathOp(int x, int y);
}