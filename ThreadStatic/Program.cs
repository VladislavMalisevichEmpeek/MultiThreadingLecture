namespace ThreadStatic;

class Program
{
    [ThreadStatic]
    static int threadLocalValue;

    static void Main(string[] args)
    {
        Thread thread1 = new Thread(() =>
        {
            threadLocalValue = 1;
            Console.WriteLine("Thread 1: threadLocalValue = " + threadLocalValue);
        });

        Thread thread2 = new Thread(() =>
        {
            threadLocalValue = 2;
            Console.WriteLine("Thread 2: threadLocalValue = " + threadLocalValue);
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Main thread: threadLocalValue = " + threadLocalValue);
    }
}