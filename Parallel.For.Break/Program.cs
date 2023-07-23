using System;
using System.Threading.Tasks;

namespace For.Break
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Main thread started.");

            var data = new int[1_000];
            for (int i = 0; i < data.Length; i++)
                data[i] = i;

            ParallelLoopResult loopResult = Parallel.For(0, data.Length, Info);

            if (!loopResult.IsCompleted)
                Console.WriteLine($"Break Iteration - {loopResult.LowestBreakIteration}");

            Console.WriteLine("Main thread completed.");

            Console.ReadKey();
        }

        static void Info(int i, ParallelLoopState state)
        {
            if(i != 0 && i % 100 == 0)
                state.Break();
        }
    }
}