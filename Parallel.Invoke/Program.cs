namespace Invoke;

static class Program
{
    static void Main()
    {
        Console.WriteLine("Main started.");

        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount > 2
                ? Environment.ProcessorCount - 1 
                : 1
        };

        Console.WriteLine("Number of logical processors: " + Environment.ProcessorCount);

        // Execute two methods in parallel.
        Parallel.Invoke(Method1, Method2, Method1, Method2);

        // Note: The execution of the Main method is paused
        // until the completion of the Invoke method.

        Console.WriteLine("Main thread completed.");

        // Delay.
        Console.ReadKey();
    }

    static void Method1()
    {
        Console.WriteLine("Method1() started.");
        for (int count = 0; count < 5; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("Inside Method1(), counter is: " + count);
        }
        Console.WriteLine("Method1() completed.");
    }

    static void Method2()
    {
        Console.WriteLine("Method2() started.");
        for (int count = 0; count < 5; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("Inside Method2(), counter is: " + count);
        }
        Console.WriteLine("Method2() completed.");
    }
}