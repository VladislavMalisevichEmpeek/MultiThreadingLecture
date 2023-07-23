namespace AsyncPeek
{
    internal class Program
    {
        private static async Task Main()
        {
            await WriteCharAsync();

            Console.ReadKey();
        }

        private static async Task WriteCharAsync()
        {
            Console.WriteLine($"WriteCharAsync started. Thread Id - {Thread.CurrentThread.ManagedThreadId}.");

            await Task.Run(() => WriteChar('#'));

            Console.WriteLine($"WriteCharAsync continued. Thread Id - {Thread.CurrentThread.ManagedThreadId}.");

            await Task.Run(() => WriteChar('*'));

            Console.WriteLine($"WriteCharAsync finished. Thread Id - {Thread.CurrentThread.ManagedThreadId}.");
        }

        private static void WriteChar(char symbol)
        {
            Thread.Sleep(500);

            for (var i = 0; i < 80; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(100);
            }
        }
    }
}