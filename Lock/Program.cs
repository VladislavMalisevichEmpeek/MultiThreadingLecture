namespace Lock;

static class Program
{
    private static readonly object LockObject = new object();

    static void Main()
    {
        Thread thread1 = new Thread(WorkerMethod);
        Thread thread2 = new Thread(WorkerMethod);
        Thread thread3 = new Thread(WorkerMethod);

        thread1.Start();
        thread2.Start();
        thread3.Start();

        Console.ReadKey();
    }

    static void WorkerMethod()
    {
        Console.WriteLine("Worker thread started.");

        lock (LockObject)
        {
            Console.WriteLine("Worker thread executing inside the critical section.");
        }

        Console.WriteLine("Worker thread completed.");
    }
}