﻿using System;
using System.Linq;

namespace PLINQ
{
    class Program
    {
        static void Main()
        {
            var data = new int[10000000];

            for (int i = 0; i < data.Length; i++)
                data[i] = i;

            data[1000] = -1;
            data[14000] = -2;
            data[15000] = -3;
            data[676000] = -4;
            data[8024540] = -5;
            data[9908000] = -6;


            var negatives = data.AsParallel()
                .Where(x => x < 0);

            foreach (var v in negatives)
                Console.Write(v + " ");

            // Delay.
            Console.ReadKey();
        }
    }
}