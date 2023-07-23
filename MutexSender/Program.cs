namespace MutexSender;

class Program
{
    static void Main(string[] args)
    {
        using (Mutex mutex = new Mutex(initiallyOwned: false, name: "MyMutex"))
        {
            Console.WriteLine("Process 1: Waiting for ownership of the mutex...");
            mutex.WaitOne(); // Wait until the mutex is available

            Console.WriteLine("Process 1: Acquired ownership of the mutex.");
            // Perform synchronization actions here

            Console.WriteLine("Process 1: Releasing ownership of the mutex.");
            mutex.ReleaseMutex(); // Release the mutex
        }
    }
}