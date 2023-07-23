namespace Continue;

class Program
{
    static void Main()
    {
        Task<int> task = Task.Run<int>(new Func<int>(GetValue));

        task.ContinueWith(Increment)
            .ContinueWith(Increment)
            .ContinueWith(Increment)
            .ContinueWith(Increment)
            .ContinueWith(Increment)
            .ContinueWith(ShowRes);

        Console.WriteLine("The Main has completed...");
        Console.ReadKey();


        int GetValue()
        {
            return 10;
        }

        int Increment(Task<int> t)
        {
            Console.WriteLine(
                $"Continuation task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
            int result = t.Result + 1;
            return result;
        }

        void ShowRes(Task<int> t)
        {
            Console.WriteLine(
                $"Continuation task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
            Console.WriteLine($"Result - {t.Result}");
        }
    }
}