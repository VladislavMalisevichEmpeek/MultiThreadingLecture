namespace SynchronizationContexts
{
    internal class Program
    {
        static Program()
        {
            SynchronizationContext.SetSynchronizationContext(new ConsoleSynchronizationContext());
        }

        private static void Main()
        {
            Message message = new Message(ApplicationMain, null);
            MessageListener.AddMessage(message);

            new MessageListener().Listen();

            Console.ReadKey();
        }

        private static void ApplicationMain(object _)
        {
            Console.WriteLine($"Main started in thread {Thread.CurrentThread.ManagedThreadId}");

            StubMethod1();

            MethodAsync();

            StubMethod2();

            Console.WriteLine($"Main finished in thread {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task MethodAsync()
        {
            Console.Write(new string('-', 80));

            Console.WriteLine($"await executed in thread {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(Method);
            Console.WriteLine($"Code after await executed in thread {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine(new string('-', 80));
        }
        private static void StubMethod1()
        {
            Console.WriteLine($"Method 1!!! Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void StubMethod2()
        {
            Console.WriteLine($"Method 2!!! Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }


        private static void Method()
        {
            Console.WriteLine($"Method {nameof(Method)} was executed in thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}