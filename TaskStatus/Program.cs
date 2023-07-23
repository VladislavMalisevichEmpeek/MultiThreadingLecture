namespace Status;

internal static class Program
{
    private static void Main()
    {
        Task task = new Task(Method);

        Console.WriteLine($"{task.Status}");

        task.Start();

        Console.WriteLine($"{task.Status}");
        Thread.Sleep(1000);

        Console.WriteLine($"{task.Status}");
        Thread.Sleep(2000);

        Console.WriteLine($"{task.Status}");
    }

    private static void Method()
    {
        Thread.Sleep(2000);
    }
}