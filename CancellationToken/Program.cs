using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main started.");

            var cancelTokSrc = new CancellationTokenSource();

            Task task = new Task(() => MyTask(cancelTokSrc.Token), cancelTokSrc.Token);
            
            task.Start();
            Thread.Sleep(2000);

            try
            {
                cancelTokSrc.Cancel();

                task.Wait();
            }
            catch (AggregateException e)
            {
                if (task.IsCanceled)
                    Console.WriteLine(e.InnerException.Message);
            }

            Console.WriteLine("Main completed.");

            // Delay.
            Console.ReadKey();
        }

        static void MyTask(object ct)
        {
            var cancelTok = (CancellationToken)ct;

            Console.WriteLine("MyTask() started.");

            for (int count = 0; count < 10; count++)
            {
                if (cancelTok.IsCancellationRequested)
                {
                    Console.WriteLine("A request to cancel a task has been received.");
                    cancelTok.ThrowIfCancellationRequested();
                }

                Thread.Sleep(500);
            }

            Console.WriteLine("MyTask() completed.");
        }
    }
}
