namespace Monitor;

static class Program
{
    private static readonly object LockObject = new object();

    static void Main()
    {
        Thread thread1 = new Thread(WorkerMethod);
        Thread thread2 = new Thread(WorkerMethod);

        thread1.Start();
        thread2.Start();

        Console.ReadKey();
    }

    static void WorkerMethod()
    {
        Console.WriteLine("Worker thread started.");

        // Enter a critical section using Monitor.Enter
        System.Threading.Monitor.Enter(LockObject);

        Console.WriteLine("Worker thread executing inside the critical section.");
        Thread.Sleep(2000);

        // Exit the critical section using Monitor.Exit
        System.Threading.Monitor.Exit(LockObject);

        Console.WriteLine("Worker thread completed.");
    }
}