using System;
using System.Diagnostics;
using System.Text;

namespace StringVsStringBuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatchString = new Stopwatch();
            Stopwatch stopwatchStringBuilder = new Stopwatch();
            Stopwatch stopwatchStringBuilderWithCapacity = new Stopwatch();
            String stringValue = String.Empty;
            stopwatchString.Start();
            for (int i = 0; i < 100000; i++)
            {
                stringValue = stringValue + i;
            }
            stopwatchString.Stop();
            stopwatchStringBuilder.Start();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                stringBuilder.Append(i);
            }
            stopwatchStringBuilder.Stop();
            stopwatchStringBuilderWithCapacity.Start();
            StringBuilder stringBuilderWithCapacity = new StringBuilder(100005);
            for (int i = 0; i < 100000; i++)
            {
                stringBuilderWithCapacity.Append(i);
            }
            stopwatchStringBuilderWithCapacity.Stop();
            Console.WriteLine($"Time taken to perform 100000 iteration for string " +
                                    $"{stopwatchString.ElapsedMilliseconds} ms");
            Console.WriteLine($"Time taken to perform 100000 iteration for StringBuilder" +
                                    $" {stopwatchStringBuilder.ElapsedMilliseconds} ms");
            Console.WriteLine($"Time taken to perform 100000 iteration for stringBuilderWithCapacity" +
                                    $" {stopwatchStringBuilderWithCapacity.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
