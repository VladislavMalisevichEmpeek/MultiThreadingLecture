namespace Result;

static class Program
{
    
    static async Task Main()
    {
        var result = MyTask().Result;
        //var result = MyTask().GetAwaiter().GetResult();
        //var result = await MyTask();

        Console.WriteLine($"Task result: {result}");
    }

    static async Task<int> MyTask()
    {
        await Task.Delay(1000);
        return 77;
    }
}