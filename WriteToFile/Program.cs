namespace WriteToFile;

class Program
{
    static Mutex mutex = new Mutex(); 

    static void Main()
    {
        Thread thread1 = new Thread(WriteToFile);
        Thread thread2 = new Thread(WriteToFile);

        thread1.Start("Thread 1");
        thread2.Start("Thread 2");

        Console.ReadKey();
    }

    static void WriteToFile(object threadName)
    {
        mutex.WaitOne();

        using (var writer = new StreamWriter("file.txt", true))
        {
            writer.WriteLine("Thread {0} is writing to the file.", threadName);
        }

        mutex.ReleaseMutex();
    }
}