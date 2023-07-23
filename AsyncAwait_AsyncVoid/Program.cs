using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncVoid
{
    internal class Program
    {
        static Program()
        {
            SynchronizationContext.SetSynchronizationContext(new TestSyncContext());
        }

        private static void Main()
        {
            MethodAsync();

            Console.ReadKey();
        }

        private static async void MethodAsync()
        {
            Console.WriteLine($"Code before the await was executed on the thread {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() => Console.WriteLine($"The task was executed in a thread {Thread.CurrentThread.ManagedThreadId}"));
            //await Task.Run(() => throw new AsyncVoidException("Error while executing an asynchronous task"));
            //throw new AsyncVoidException("Error in asynchronous method");
            Console.WriteLine($"The code after the await was executed on the thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }

    internal class AsyncVoidException : Exception
    {
        public AsyncVoidException(string message)
            : base(message) { }
    }
}