using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadingExamples
{
    class ThreadLocking
    {
        public void Display()
        {
            lock (this)
            {
                Console.Write("[Hi all, I am");
                Thread.Sleep(5000);
                Console.WriteLine(" learning C Sharp.]");
            }
        }

        public static void Main()
        {
            ThreadLocking threadLocking = new ThreadLocking();
            Thread thread1 = new Thread(threadLocking.Display);
            Thread thread2 = new Thread(threadLocking.Display);
            Thread thread3 = new Thread(threadLocking.Display);
            thread1.Start(); thread2.Start(); thread3.Start();
            Console.ReadLine();
        }
    }
}
