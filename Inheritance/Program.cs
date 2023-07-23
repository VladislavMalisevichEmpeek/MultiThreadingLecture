using System;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        CustomTask customTask = new CustomTask(() =>
        {
            Console.WriteLine("Custom task executed");
        });

        customTask.Start();
        customTask.CustomMethod();

        customTask.Wait();
        Console.WriteLine("Main thread completed");
    }
}

public class CustomTask : Task
{
    public CustomTask(Action action) : base(action)
    {
        // Custom initialization or additional logic
    }

    // Custom methods or properties
    public void CustomMethod()
    {
        Console.WriteLine("Custom method called");
    }
}