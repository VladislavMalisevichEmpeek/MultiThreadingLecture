namespace Join;

class Program
{
    static void Main()
    {
        Thread thread1 = new Thread(DoWork);
        Thread thread2 = new Thread(DoWork);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        var wasSlow = thread2.Join(200);

        Console.WriteLine("All threads are completed.");
        Console.WriteLine($"{wasSlow}");
    }

    static void DoWork()
    {
        Thread.Sleep(5000);
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started.");
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished.");
    }
}