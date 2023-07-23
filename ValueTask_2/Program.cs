namespace ValueTask
{
    internal class Program
    {
        private static void Main()
        {
            int salary = 20000;
            ValueTask<double> valueTask = GetIndexing(salary);

            while (!valueTask.IsCompleted)
            {
                Console.Write('*');
                Thread.Sleep(200);
            }

            Task<double> task = valueTask.AsTask();

            task.ContinueWith((t) => Console.WriteLine($"\n Salary index for {salary} = {t.Result}%"));

            Console.ReadKey();
        }

        private static ValueTask<double> GetIndexing(int salary)
        {
            return salary switch
            {
                <= 0 => new ValueTask<double>(0),
                > 5000 => new ValueTask<double>(0),
                5000 => new ValueTask<double>(0.1),
                _ => new ValueTask<double>(Task.Run(() =>
                {
                    var index = 0.0;
                    for (var i = 0; i < 5; i++)
                    {
                        // Some hard work.
                        Thread.Sleep(500);
                        index += 0.1;
                    }

                    return index;
                }))
            };
        }
    }
}