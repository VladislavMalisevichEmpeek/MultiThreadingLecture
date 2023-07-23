using System;
using System.Threading;

namespace Semaphores
{
    public class Program
    {
        private static Semaphore pool;

        private static void Work(object number)
        {
            pool.WaitOne();
            pool.
            Console.WriteLine($"Thread {number} occupied the semaphore slot.");
            Thread.Sleep(1000);
            Console.WriteLine($"Thread {number} -----> released the semaphore slot");

            pool.Release();
        }

        public static void Main()
        {
            pool = new Semaphore(2, 4, "fa4c3e15-eae1-4794-ae4a-aa0a6594e968");

            for (int i = 1; i <= 8; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(Work));
                thread.Start(i);
            }
            Thread.Sleep(2000);
            pool.Release();

            Console.ReadKey();
        }
    }
}