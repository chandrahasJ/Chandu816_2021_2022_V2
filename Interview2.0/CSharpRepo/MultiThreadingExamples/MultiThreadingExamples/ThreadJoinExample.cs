using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadingExamples
{
    public class ThreadJoinExample
    {
        public static void Thread1Test()
        {
            Console.WriteLine("Thread 1 Start");
            for (int i = 0; i < 50; i++)             
                Console.Write($"\t TT1: {i}  ");           
            Console.WriteLine("Thread 1 Ended");
        }
        public static void Thread2Test()
        {
            Console.WriteLine("Thread 2 Start");
            for (int i = 0; i < 50; i++)
                if (i == 25) { Thread.Sleep(5000);  }
                else { Console.Write($"\t TT2: {i}  "); }                     
            Console.WriteLine("Thread 2 Ended");
        }
        public static void Thread3Test()
        {
            Console.WriteLine("Thread 3 Start");
            for (int i = 0; i < 50; i++)            
                Console.Write($"\t TT3: {i}  ");            
            Console.WriteLine("Thread 3 Ended");
        }
        public static void Main()
        {
            Console.WriteLine("Main Thread Start");
            Thread thread1 = new Thread(Thread1Test);
            Thread thread2 = new Thread(Thread2Test);
            Thread thread3 = new Thread(Thread3Test);
            thread1.Start(); thread2.Start(); thread3.Start();
            //Adding Join Makes sure that Main Thread will 
            //Wait for child threads to complete the execution.
            thread1.Join(2000 ); thread2.Join(); thread3.Join();
            Console.WriteLine("Main Thread End");
        }
    }
}
