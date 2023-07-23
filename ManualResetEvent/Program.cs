namespace ResetEvent;

static class Program
{
    //private static readonly AutoResetEvent ResetEvent = new AutoResetEvent(false);
    //private static readonly ManualResetEvent ResetEvent = new ManualResetEvent(false);
    private static readonly EventWaitHandle ResetEvent = new EventWaitHandle(false, EventResetMode.AutoReset);

    static void Main(string[] args)
    {
        var thread1 = new Thread(DoWork);
        var thread2 = new Thread(DoWork);
        var thread3 = new Thread(DoWork);

        thread1.Start();
        thread2.Start();
        thread3.Start();

        Console.WriteLine("All threads started.");
        Thread.Sleep(2000);

        ResetEvent.Set();

        Console.WriteLine("Signal from event.");

        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("All threads completed.");
    }

    static void DoWork()
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is waiting.");
        ResetEvent.WaitOne();

        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed.");
    }
}