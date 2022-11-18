using System.Threading.Tasks;
using System.Linq;


// Riddle: 
// What will be printed to the console?
IEnumerable<Task> tasks = Enumerable.Range(0, 2)
    .Select(_ => Task.Run(() => Console.Write("*")));

await Task.WhenAll(tasks);

Console.Write($"{tasks.Count()} stars!");

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
// We force the task to take more time then the Console.write() methods takes to execute
// so the tasks are still running on the threadpool and the last two stars will not be printed.
// ----------------------------------------------------------------------------------------------

Console.WriteLine();
Console.WriteLine("--------------");

// Better way to do things is to create a list
// The list will hold the Count as a field
// and does not need to iterate over it again to count the tasks.
IEnumerable<Task> tasks3 = Enumerable.Range(0, 2).ToList()
    .Select(_ => Task.Run(async () =>
    {
        await Task.Delay(10);
        Console.Write("*");
    }));

await Task.WhenAll(tasks3);

Console.Write($"{tasks3.Count()} stars!");
// ----------------------------------------------------------------------------------------------


// Btw. The answere to the riddle is:
// It will always print: **
// because the two tasks are awaited.
// Then it depends how fast the tasks are executed.
// **2 stars!** or
// ****2 stars! or
// ***2 stars!*