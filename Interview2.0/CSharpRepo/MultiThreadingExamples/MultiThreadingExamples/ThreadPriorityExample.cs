using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadingExamples
{
    class ThreadPriorityExample
    {
        static int counter1, counter2;
        public static void Counter1Increment() 
            { while (true) counter1++; }
        public static void Counter2Increment() 
            { while (true) counter2++; }
        public static void Main()
        {
            Thread counter1Thread = new Thread(Counter1Increment);
            Thread counter2Thread = new Thread(Counter2Increment);
            //counter1Thread.Priority = ThreadPriority.Lowest;
            //Counter2Thread will get more CPU resources
            //counter2Thread.Priority = ThreadPriority.Highest;
            counter1Thread.Start(); counter2Thread.Start();
            Console.WriteLine("Main Thread Sleep Start");
            Thread.Sleep(1000);
            Console.WriteLine("Main Thread Sleep End");
            try
            {
                //Abort has been deprected
                //Interrupt is use to terminate the thread.
                counter1Thread.Interrupt(); counter2Thread.Interrupt();
            }
            catch (ThreadInterruptedException) 
            {
                counter1Thread.Join(); counter2Thread.Join();
            }
            finally{
                Console.WriteLine($"Counter1 :> {counter1}");
                Console.WriteLine($"Counter2 :> {counter2}");
                Console.WriteLine($"Differnce :> {counter2 - counter1}");
            }                      
            Console.ReadLine();
        }
    }
}
