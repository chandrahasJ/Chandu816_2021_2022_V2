using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MultiThreadingExamples
{
    class ThreadPerformance
    {
        public static void Increment1Count()
        {
            long counter = 0;
            for (long i = 0; i < 10000000000; i++)
                counter++;
            Console.WriteLine($"Increment1Count :> {counter}");
        }
        public static void Increment2Count()
        {
            long counter = 0;
            for (long i = 0; i < 10000000000; i++)
                counter++;
            Console.WriteLine($"Increment2Count :> {counter}");
        }
        public static void Main()
        {
            Thread thread1 = new Thread(Increment1Count);
            Thread thread2 = new Thread(Increment2Count);
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch1.Start();
            Increment1Count(); Increment2Count();
            stopwatch1.Stop();

            stopwatch2.Start();
            thread1.Start(); thread2.Start();
            stopwatch2.Stop();

            thread1.Join(); thread2.Join();

            Console.WriteLine($"Time taken STA:> {stopwatch1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Time taken MTA:> {stopwatch2.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
