namespace Start;

static class Program
{
    static void Main()
    {
        // Create a new thread using ThreadStart
        Thread thread = new Thread(new ThreadStart(WorkerMethod));
        thread.Start();

        // Create a new thread and pass parameters using ParameterizedThreadStart
        Thread parametrizedThread = new Thread(new ParameterizedThreadStart(ParameterizedWorkerMethod));
        parametrizedThread.Start("Hello, World!");


        Console.WriteLine("Main thread continues its execution.");

        // Wait for the thread to complete
        thread.Join();
        Console.WriteLine("Thread completed.");

        Console.ReadKey();
    }

    static void ParameterizedWorkerMethod(object parameter)
    {
        string message = (string)parameter; // Casting the parameter to the appropriate type

        Console.WriteLine($"Worker thread started. Message: {message}");

        // Perform some work
        Thread.Sleep(2000);

        Console.WriteLine("Worker thread completed.");
    }
    static void WorkerMethod()
    {
        Console.WriteLine($"Worker thread started.");

        // Perform some work
        Thread.Sleep(2000);

        Console.WriteLine("Worker thread completed.");
    }
}