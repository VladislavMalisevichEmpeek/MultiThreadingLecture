using System;
using System.Threading.Tasks;

namespace For
{
    class Program
    {
        
        static void Main()
        {
            Console.WriteLine("Main thread started.");

            var data = new int[1_000];
            for (int i = 0; i < data.Length; i++)
                data[i] = i;

            Parallel.For(0, data.Length, new Action<int>(Info));

            // Note: The execution of the Main method is paused
            // until the completion of the For method.

            Console.WriteLine("Main thread completed.");

            Console.ReadKey();
        }

        static void Info(int i)
        {
            Console.WriteLine($"Loop - {i}, task - {Task.CurrentId}, thread - {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}