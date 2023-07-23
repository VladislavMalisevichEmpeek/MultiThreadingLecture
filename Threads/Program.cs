using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread thread = new Thread(DoWork);


        thread.Start();

        thread.Is
        thread.Join();
       

        Console.WriteLine("Усі потоки завершили роботу.");
    }

    static void DoWork()
    {
        Console.WriteLine("Потік {0} починає виконання.", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Потік {0} завершив виконання.", Thread.CurrentThread.ManagedThreadId);
    }
}