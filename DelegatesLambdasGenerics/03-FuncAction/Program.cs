using System.Diagnostics;

// Note: Do not use stopwatch to find out wether you algorithms are really good.
// If you want to do performance measurement, then use BenchmarkDotNet.
// For our demo it is okay.

var watch = Stopwatch.StartNew();
CountToNearlyInfinity(); // <<<< Method to benchmark
watch.Stop();
Console.WriteLine("time elapsed: "+ watch.Elapsed);

MeasureTime(() => CountToNearlyInfinity());
MeasureTime(CountToNearlyInfinity);

// This is the definition of an Action.
// It takes no paremeters and returns void.
// delegate void Action(); 

System.Console.WriteLine($"The result is: {MeasureTimeFunc(() => CalculateSomeResult())}");

static void MeasureTime(Action a)
{
    var watch = Stopwatch.StartNew();
    a();
    watch.Stop();
    Console.WriteLine("time elapsed: "+ watch.Elapsed);
}

// The last parameter of Func<..., ..., ...> is the return type.
static int MeasureTimeFunc(Func<int> f)
{
    var watch = Stopwatch.StartNew();
    var result = f();
    watch.Stop();
    Console.WriteLine("time elapsed: "+ watch.Elapsed);
    return result;
}

static void CountToNearlyInfinity()
{
    for (var i = 0; i < 2000000000; i++);
    Console.WriteLine("Finished counting to infinity.");
}

static int CalculateSomeResult()
{
    // Simulate some interesting calculation.
    for (var i = 0; i < 2000000000; i++);

    return 42;
}