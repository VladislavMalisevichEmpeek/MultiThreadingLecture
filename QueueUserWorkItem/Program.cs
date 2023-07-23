namespace QueueUserWorkItem;

static class Program
{
    static void Main()
    {
        ThreadPool.GetMaxThreads(out var threadsCount, out var portThreadsCount);
       
        Console.WriteLine($"Max Thread Count - {threadsCount}, Max Port Threads Count - {portThreadsCount}");

        for (int i = 0; i < 100; i++)
        {
            ThreadPool.QueueUserWorkItem((object _) => GetInfo());
        }

        Console.WriteLine("Main thread continues executing...");

        Console.ReadKey();
    }

    static void GetInfo()
    {
        Console.WriteLine($"Count - {ThreadPool.ThreadCount}, Completed - {ThreadPool.CompletedWorkItemCount}, Pending - {ThreadPool.PendingWorkItemCount}");
        Thread.Sleep(500);
    }
}