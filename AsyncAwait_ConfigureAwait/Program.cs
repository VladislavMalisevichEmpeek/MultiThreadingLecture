using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Main method started.");

        await DeadlockExample();

        Console.WriteLine("Main method completed.");
    }

    static async Task DeadlockExample()
    {
        Console.WriteLine("DeadlockExample method started.");

        // Perform an asynchronous operation
        await Task.Delay(1000).ConfigureAwait(false);

        // Attempt to continue on the captured context
        await Task.Run(() => Console.WriteLine("Continuation executed."));

        Console.WriteLine("DeadlockExample method completed.");
    }
}