using System.IO.Pipes;

namespace Sender;

class Program
{
    static void Main(string[] args)
    {
        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("MyNamedPipe"))
        {
            Console.WriteLine("Waiting for connection...");
            pipeServer.WaitForConnection();

            using (StreamWriter writer = new StreamWriter(pipeServer))
            {
                writer.WriteLine("Hello from Process 1!");
            }

            Console.WriteLine("Message sent to Process 2.");
        }
    }
}