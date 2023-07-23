namespace LockObject;

static class Program
{
    private const int LockObject = 7;

    private static void LockWorkerMethod()
    {
        Console.WriteLine("Worker thread started.");

        lock ((object)LockObject)
        {
            Console.WriteLine("Worker thread executing inside the critical section.");
            Thread.Sleep(2000);
        }

        Console.WriteLine("Worker thread completed.");
    }

    private static void MonitorWorkerMethod()
    {
        Console.WriteLine("Worker thread started.");

        Monitor.Enter(LockObject);
        
        Console.WriteLine("Worker thread executing inside the critical section.");
        Thread.Sleep(2000);

        Monitor.Exit(LockObject);

        Console.WriteLine("Worker thread completed.");
    }

    static void Main()
    {
        Thread thread1 = new Thread(LockWorkerMethod);
        Thread thread2 = new Thread(MonitorWorkerMethod);

        thread1.Start();
        thread2.Start();

        Console.ReadKey();
    }
}