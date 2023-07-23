namespace RaceCondition;

class Program
{
    static int counter = 0;

    static void Main(string[] args)
    {
        // Create two threads
        Thread thread1 = new Thread(IncrementCounter);
        Thread thread2 = new Thread(DecrementCounter);

        // Start the threads
        thread1.Start();
        thread2.Start();

        // Wait for the threads to finish
        thread1.Join();
        thread2.Join();

        // Output the final value of the counter
        Console.WriteLine("Final counter value: " + counter);
    }

    static void IncrementCounter()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            // Increment the counter
            counter++;
            //Interlocked.Increment(ref counter);
        }
    }

    static void DecrementCounter()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            // Decrement the counter
            counter--;
            //Interlocked.Decrement(ref counter);
        }
    }
}