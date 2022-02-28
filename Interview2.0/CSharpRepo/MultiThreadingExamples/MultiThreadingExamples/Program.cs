using System;
using System.Threading;

namespace MultiThreadingExamples
{
    class Program
    {
        public static void ThreadTest1()
        {
            for (int i = 0; i < 50; i++)
                 Console.Write("  TT1 :>"+i+"\t");          
        }
        public static void ThreadTest2()
        {
            for (int i = 0; i < 50; i++) {
                Console.Write("  TT2 :>" + i + "\t");
                if (i == 25)
                {
                    Console.Write("Sleep Start \t");
                    Thread.Sleep(5);
                    Console.Write("Sleep End \t");
                }
            }
        }

        public static void ThreadTest3()
        {
            for (int i = 0; i < 50; i++)
                Console.Write("  TT3 :>" + i + "\t");
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(ThreadTest1);
            Thread thread2 = new Thread(ThreadTest2);
            Thread thread3 = new Thread(ThreadTest3);
            thread1.Start(); thread2.Start(); thread3.Start();
            Console.ReadLine();
        }
    }
}
