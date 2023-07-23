namespace ThreadPool;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine($"Main method thread Id - {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("Press any key to start");
        Console.ReadKey();

        Report();
        System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(Example1));
        Report();
        System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(Example2));
        Report();

        Console.ReadKey();
        Report();
    }

    private static void Example1(object state)
    {
        Console.WriteLine($"Example1 method started executing in thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(2000);
        Console.WriteLine($"Example1 method finished executing in thread {Thread.CurrentThread.ManagedThreadId}");
    }

    private static void Example2(object state)
    {
        Console.WriteLine($"Example2 method started executing in thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        Console.WriteLine($"Example2 method finished executing in thread {Thread.CurrentThread.ManagedThreadId}");
    }

    private static void Report()
    {
        System.Threading.ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxPortThreads);
        System.Threading.ThreadPool.GetAvailableThreads(out int workerThreads, out int portThreads);

        Console.WriteLine($"Worker threads: {workerThreads} out of {maxWorkerThreads}");
        Console.WriteLine($"I/O threads: {portThreads} out of {maxPortThreads}");
        Console.WriteLine(new string('-', 80));
    }
}