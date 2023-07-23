namespace MutexReceiver;

class Program
{
    static void Main(string[] args)
    {
        using (Mutex mutex = Mutex.OpenExisting("MyMutex"))
        {
            Console.WriteLine("Process 2: Attempting to acquire ownership of the mutex...");
            bool isAcquired = mutex.WaitOne(TimeSpan.FromSeconds(5)); 

            if (isAcquired)
            {
                Console.WriteLine("Process 2: Acquired ownership of the mutex.");
                Thread.Sleep(2000);
                Console.WriteLine("Process 2: Releasing ownership of the mutex.");

                mutex.ReleaseMutex(); 
            }
            else
            {
                Console.WriteLine("Process 2: Failed to acquire ownership of the mutex within the timeout.");
            }
        }
    }
}