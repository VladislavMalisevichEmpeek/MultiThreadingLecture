namespace SemaphoreSender;

class Program
{
    static void Main(string[] args)
    {
        using (Semaphore semaphore = new Semaphore(0, 1, "MySemaphore"))
        {
            Console.WriteLine("Process 1: Waiting for Process 2...");
            semaphore.WaitOne(); // Wait until Process 2 signals

            Console.WriteLine("Process 1: Received signal from Process 2.");
            // Perform synchronization actions here
        }
    }
}