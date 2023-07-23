namespace HotAndCold;

static class Program
{
    static void Main()
    {
        // Hot task
        Task task = Task.Run(DoWork);

        // Cold start
        //Task task = new Task(DoWork);
        //task.Start();

        // Do some other work in the main thread
        Console.WriteLine("Main thread is doing some work...");

        // Wait for the task to complete
        task.Wait();

        Console.WriteLine("Main thread completed.");

        Console.ReadKey();
    }

    private static void DoWork()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Task completed!");
    }
}