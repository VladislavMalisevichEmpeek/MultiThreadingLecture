namespace Id;

static class Program
{
    static void Main()
    {
        Console.WriteLine("Main thread started");

        var task1 = new Task(() => Info("First task"));
        var task2 = new Task(() => Info("Second task"));

        task1.Start();
        task2.Start();

        Info("Main");

        Console.ReadKey();
    }

    static void Info(string name)
    {
        Console.WriteLine($"{name}: Task Id - {(Task.CurrentId.HasValue ? Task.CurrentId : "null")}, Thread Id - {Thread.CurrentThread.ManagedThreadId}");
    }
}