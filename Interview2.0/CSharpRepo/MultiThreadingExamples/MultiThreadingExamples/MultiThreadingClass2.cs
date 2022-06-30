using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadingExamples
{
    class MultiThreadingClass2
    {
        public static void ThreadTest1()
        {
            for (int i = 0; i < 50; i++)
                Console.Write("  TT1 :>" + i + "\t");
        }
        static void Main(string[] args)
        {
            //ThreadStart is a pre-defined delegate 
            //with no input parameters and void as return type
            //ThreadStart threadStart = new ThreadStart(ThreadTest1);
            //ThreadStart threadStart = ThreadTest1;
            //ThreadStart threadStart = delegate () { ThreadTest1(); };
            ThreadStart threadStart =  () => { ThreadTest1(); };

            Thread thread1 = new Thread(threadStart);
            thread1.Start();
            Console.ReadLine();
        }
    }

    class MultiThreadingClass3
    {        
        public static void ThreadTest1(object maxLength)
        {
            int length = Convert.ToInt32(maxLength);
            for (int i = 0; i < length; i++)
                Console.Write("  TT3 :>" + i + "\t");
        }
        static void Main(string[] args)
        {
            //ParameterizedThreadStart is a pre-defined delegate 
            //with "1" input parameters and void as return type
            //ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(ThreadTest1);
            ParameterizedThreadStart parameterizedThreadStart = ThreadTest1;    

            Thread thread1 = new Thread(parameterizedThreadStart);
            //We need to pass the parameter via Thread -> Start method
            thread1.Start(50);
            Console.ReadLine();
        }
    }
}
