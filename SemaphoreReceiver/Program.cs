namespace SemaphoreReceiver;

class Program
{
    static void Main(string[] args)
    {
        using (Semaphore semaphore = Semaphore.OpenExisting("MySemaphore"))
        {
            Console.WriteLine("Process 2: Signaling Process 1...");
            semaphore.Release(); // Signal Process 1

            Console.WriteLine("Process 2: Signal sent to Process 1.");
            // Perform synchronization actions here
        }
    }
}