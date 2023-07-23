namespace WithCancellation
{
    class Program
    {
        static void Main()
        {
            var token = new CancellationTokenSource();
            var data = new int[10000000];

           
            for (int i = 0; i < data.Length; i++) 
                data[i] = i;

            data[1000] = -1;
            data[14000] = -2;
            data[15000] = -3;
            data[676000] = -4;
            data[8024540] = -5;
            data[9908000] = -6;


            ParallelQuery<int> negatives = data
                .AsParallel()
                .WithCancellation(token.Token)
                .Where(x => x < 0);

            token.CancelAfter(200);

            try
            {
                foreach (var v in negatives)
                    Console.Write(v + " ");

                Console.WriteLine("Enumeration completed successfully!");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                token.Dispose();
            }

            // Delay.
            Console.ReadKey();
        }
    }
}