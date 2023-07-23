using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContinueWith
{
    static class Program
    {
        static void Main()
        {
            Task<int> task = Task.Run(() => 10);

            task.ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(ShowResult);

            Console.WriteLine("Main completed.");
            Console.ReadKey();
        }

        private static int Increment(Task<int> t)
        {
            Console.WriteLine($"Continuation task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
            var result = t.Result + 1;
            return result;
        }

        private static void ShowResult(Task<int> t)
        {
            Console.WriteLine($"Result - {t.Result}");
        }
    }
}