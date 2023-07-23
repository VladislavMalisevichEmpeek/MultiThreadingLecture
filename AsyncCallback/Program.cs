namespace AsyncCallback;

class Program
{
    static void Main()
    {
        // Queue work item to ThreadPool with callback
        ThreadPool.QueueUserWorkItem(WorkerMethod, CallbackMethod);

        Console.WriteLine("Main thread continues executing...");

        Console.ReadKey();
    }

    static void WorkerMethod(object state)
    {
        Console.WriteLine("Worker thread executes.");

        // Simulating some work
        Thread.Sleep(2000);

        // Retrieve the callback method from state
        Action callback = (Action)state;

        // Invoke the callback method
        callback?.Invoke();
    }

    static void CallbackMethod()
    {
        Console.WriteLine("Callback method is invoked.");
    }
}