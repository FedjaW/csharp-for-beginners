using System.Threading.Tasks;
using System.Linq;

IEnumerable<Task> tasks = Enumerable.Range(0, 2)
    .Select(_ => Task.Run(() => Console.Write("*")));

await Task.WhenAll(tasks);

Console.Write($"{tasks.Count()} stars!");

// Riddle: 
// What will be printed to the console?
// A. **2 stars!
// B. **2 stars!**
// C. ****2 stars!
// D. not defined

// Explanation:
// In this example are multiple tricks hidden
// 1. .Range(0, 2) -> will generate numbers from start value to one before end value -> 0, 1
// 2. _ means ignoring the number wich is generated from .Range
// 3. Task.Run() will not run as long the Enumable is not enumerated
//               In general tasks must not be awaited to run, they run when Task.Run() is executed
// 4. await Tasks.WhenaAll will enumerate and cause the tasks to run
// 5. Count() trys not to enumerate the enumerable, but if will, if can not avoid doing so
//            In this case it will enumerate it again
// Note: By default, Taks run on a managed threadpool
// -----------------------------------------------------------------------------------------------

Console.WriteLine();
Console.WriteLine("--------------");

// Proof answere by delaying the tasks
IEnumerable<Task> tasks2 = Enumerable.Range(0, 2)
    .Select(_ => Task.Run(async () =>
    {
        await Task.Delay(10);
        Console.Write("*");
    }));

await Task.WhenAll(tasks2);

Console.Write($"{tasks2.Count()} stars!");
// We force the task to take more time then the console.write() methods takes to execute
// so the taks are still running on the threadpool and the last two stars will no be printed.
// ----------------------------------------------------------------------------------------------

Console.WriteLine();
Console.WriteLine("--------------");

// Better way to do things is to create a list
// The list will hold the tasks in a dedicated memory
// Then the list will not be enumerated multiple times
IEnumerable<Task> tasks3 = Enumerable.Range(0, 2).ToList()
    .Select(_ => Task.Run(async () =>
    {
        await Task.Delay(10);
        Console.Write("*");
    }));

await Task.WhenAll(tasks3);

Console.Write($"{tasks3.Count()} stars!");
// ----------------------------------------------------------------------------------------------

// Btw. The answere is D.