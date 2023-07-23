using System;
using System.Threading.Tasks;

namespace ForEach
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Main thread started.");

            var data = new int[100];
            for (int i = 0; i < data.Length; i++)
                data[i] = i;

            ParallelLoopResult loopResult = Parallel.ForEach(data, (value, state) =>
            {
                Console.WriteLine($"Data - {value}, task - {Task.CurrentId}, thread - {Thread.CurrentThread.ManagedThreadId}");

                if(value == 777)
                    state.Break();
            });

            Console.WriteLine("Main thread completed.");

            Console.ReadKey();
        }
    }
}