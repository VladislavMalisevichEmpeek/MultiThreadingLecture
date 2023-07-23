
Console.WriteLine("Main started");

Task[] tasks = new Task[] {
            new Task(DoWork, 1000),
            new Task(DoWork, 800),
            new Task(DoWork, 2000),
            new Task(DoWork, 1000),
            new Task(DoWork, 3500),
        };



foreach (Task task in tasks)
    task.Start();

Console.WriteLine($"Main is waiting...");

Task.WaitAll(tasks);
//Task.WaitAll(tasks, new CancellationToken());
//Task.WaitAll(tasks, 100);

//Task.WaitAny(tasks);

Console.WriteLine($"Continue Main");

static void DoWork(object sleepTime)
{
    Console.WriteLine($"Task #{Task.CurrentId} started");

    Thread.Sleep((int)sleepTime);
}
