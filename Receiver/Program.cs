using System.IO.Pipes;

namespace Receiver;

class Program
{
    static void Main(string[] args)
    {
        using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "MyNamedPipe", PipeDirection.In))
        {
            Console.WriteLine("Connecting to Process 1...");
            pipeClient.Connect();

            using (StreamReader reader = new StreamReader(pipeClient))
            {
                string message = reader.ReadLine();
                Console.WriteLine("Received message from Process 1: " + message);
            }

            Console.ReadKey();
        }
    }
}