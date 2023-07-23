using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        TaskFactory taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);

        // Creating a new Task with custom parameters
        Task task = taskFactory.StartNew(() =>
        {
            Console.WriteLine("Long-running task executed!");
        });

        // Waiting for the task to complete
        task.Wait();
    }
}