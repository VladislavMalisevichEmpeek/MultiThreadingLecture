using System;
using System.Threading;

namespace Volatile
{
    class Program
    {
        static volatile bool stop; // without JIT optimization.
        //static bool stop; // with JIT optimization.

        static void Main()
        {
            Console.WriteLine("Main: thread started.");
            var thread = new Thread(Worker);
            thread.Start();

            Thread.Sleep(2000);

            stop = true;

            Console.WriteLine("Main: waiting for worker.");
            thread.Join();
        }

        private static void Worker()
        {
            // Attention! Optimization doesn't work in debug mode.
            int x = 0;

            // With JIT optimization the next row will be  'while (true)'
            while (!stop)
            {
                x++;
            }

            Console.WriteLine("Worker: stopped when x = {0}.", x);
        }
    }
}
