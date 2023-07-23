class Program
{
    static void Main()
    {
        Thread thread = new Thread(WorkerMethod);
        thread.Start();

        // Allow the thread to execute for some time
        Thread.Sleep(2000);

        // Interrupt the thread
        thread.Interrupt();  // throw ThreadInterruptedException

        // Abort the thread
        thread.Abort(); // throw ThreadAbortException


        Console.WriteLine("Thread interrupted.");

        // Wait for the thread to complete
        thread.Join();
        Console.WriteLine("Thread completed.");

        Console.ReadKey();
    }

    static void WorkerMethod()
    {
        try
        {
            Console.WriteLine("Worker thread started.");

            while (true)
            {
                Console.WriteLine("Worker thread executing.");
                Thread.Sleep(500);
            }
        }
        catch (ThreadInterruptedException)
        {
            Console.WriteLine("Worker thread interrupted.");
        }
        catch (ThreadAbortException)
        {
            Console.WriteLine("Worker thread aborted.");
        }
        catch (PlatformNotSupportedException)
        {
            Console.WriteLine("Abort not supported.");
        }
        finally
        {
            Console.WriteLine("Worker thread cleanup.");
        }
    }
}