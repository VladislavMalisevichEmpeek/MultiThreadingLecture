class Program
{
    static void Main()
    {
        Thread thread = new Thread(WorkerMethod);
        thread.Start();

        // Allow the thread to execute for some time
        Thread.Sleep(2000);

        // Suspend the thread
        thread.Suspend();
        Console.WriteLine("Thread suspended.");

        // Wait for user input to resume the thread
        Console.WriteLine("Press any key to resume the thread...");
        Console.ReadKey();

        // Resume the thread
        thread.Resume();
        Console.WriteLine("Thread resumed.");

        // Wait for the thread to complete
        thread.Join();
        Console.WriteLine("Thread completed.");

        Console.ReadKey();
    }

    static void WorkerMethod()
    {
        Console.WriteLine("Worker thread started.");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Iteration {i}");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Worker thread completed.");
    }
}