// Q: What is a delegsate?
// A: A delegate is a type definition for functions like a class is a type definition for an object.

MathOp f = Add; // Assigning a pointer (no brackets in place like Add())
Console.WriteLine(f(4, 2)); // prints 6 to the console

f = Substract;
Console.WriteLine(f(4, 2)); // prints 2 to the console

CalculateAndPrint(15, 10, Add); // prints 25 to the console
CalculateAndPrint(15, 10, Substract); // prints 5 to the console

// Various short forms how to pass a function / functionpointer:
// This deleagte here has nothing to do with the delagate (delegate int MathOp(..)) which is a type definition
// This delegate here allows us to write an anonymous function.
// Of course the function has a name, but it is chosen by the compiler.
CalculateAndPrint(30, 10, delegate (int a, int b) { return a + b; });
// Even more simplification. The "=>" is called the "fat arrow".
CalculateAndPrint(30, 10, (int a, int b) => { return a + b; });
// We can remove the return statement, because we have ONLY A SINGLE line of code.
CalculateAndPrint(30, 10, (int a, int b) => a + b);
// Compiler can derive parameter type from delegetate definition. 
CalculateAndPrint(30, 10, (a, b) => a + b); // -> Now we have a LAMBDA FUNCTION!
CalculateAndPrint(30, 10, (a, b) => a - b); // -> Now we have a LAMBDA FUNCTION!
CalculateAndPrint(30, 10, (a, b) => a * b); // -> Now we have a LAMBDA FUNCTION!

static int Add(int x, int y)
{
    return x + y;
}

static int Substract(int a, int b)
{
    return a - b;
}

// Takes a delegate as a parameter (MathOp f).
// Pattern: Strategy pattern, because you pass in the strategy how to calculate as an input parameter.
// The original strategy pattern was based on interfaces, but you can do it with delagetes too.
static void CalculateAndPrint(int x, int y, MathOp f)
{
    var result = f(x, y);
    Console.WriteLine(result);
}

delegate int MathOp(int x, int y);