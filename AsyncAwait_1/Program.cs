namespace ThreadContinuation
{
    public static class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Main started. Thread Id {Thread.CurrentThread.ManagedThreadId}.");

            WriteCharAsync('#'); 
            WriteChar('*');

            Console.WriteLine($"\nMain finished.Thread Id {Thread.CurrentThread.ManagedThreadId}.");
            Console.ReadKey();
        }

        private static async Task WriteCharAsync(char symbol)
        {
            Console.WriteLine($"WriteCharAsync method started in thread {Thread.CurrentThread.ManagedThreadId}.");

            await Task.Run(() => WriteChar(symbol));

            Console.WriteLine($"WriteCharAsync method finished in thread {Thread.CurrentThread.ManagedThreadId}.");
        }

        private static void WriteChar(char symbol)
        {
            Thread.Sleep(500);

            for (int i = 0; i < 80; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(100);
            }
        }
    }
}