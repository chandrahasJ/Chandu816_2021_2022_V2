using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateExample
{
    public delegate void PrintDelegate(string str);
    class AnonymousMethodClass
    {
        public static void PrintMsg(string name)
        {
            Console.WriteLine($"Printed via normal method - Hello {name}");
        }

        public static void Main()
        {
            PrintDelegate printDelegate = new PrintDelegate(PrintMsg);
            printDelegate("Chandrahas");

            PrintDelegate printDelgateViaAnonymousMethod = delegate (string name)
            {
                Console.WriteLine($"Printed via Anonymous method - Hello {name}");
            };
            printDelgateViaAnonymousMethod("Chandrika");
            Console.ReadLine();
        }
    }

    class AnonymousMethodClass2
    {
        private delegate int CalculateDelegate(int a,int b);
        public static void Main()
        {
            CalculateDelegate addDelegate = delegate (int a, int b)
            {
                return a + b;
            };
            CalculateDelegate mulDelegate = delegate (int a, int b)
            {
                return a * b;
            };
            Console.WriteLine($"Add Delegate :> {addDelegate(10,20)}");
            Console.WriteLine($"Multiple Delegate :> {mulDelegate(10, 20)}");
            Console.ReadLine();
        }
    }

    public class AnonymousMethodClass3
    {
        public delegate void PrintNumberDelegate(int number);
        public void IncrementAndPrintNumber(PrintNumberDelegate printNumberDelegate, int incrementalNumber)
        {
            incrementalNumber += 200;
            printNumberDelegate(incrementalNumber);

        }
    }

    class Program2
    {
        public static void Main()
        {
            AnonymousMethodClass3 anonymousMethodClass3 = new AnonymousMethodClass3();
            //Passing Anonymous method as method parameter 
            anonymousMethodClass3.IncrementAndPrintNumber(
                    delegate (int number)
                    {
                        Console.WriteLine($"Incremented number :> {number}");
                    }, 100
                );
            Console.ReadLine();
        }
    }

    public class AnonymousMethodClass4
    {
        public event EventHandler MySaveSuccessMessage;
        public void Save()
        {
            // Saving Activity
            MySaveSuccessMessage(this, EventArgs.Empty);
            //MySaveSuccessMessage.Invoke(this, EventArgs.Empty);
        }
    }

    class Program3
    {
        public static void Main()
        {
            AnonymousMethodClass4 anonymousMethodClass4 = new AnonymousMethodClass4();
            //Anonymous method used by Event Handler
            anonymousMethodClass4.MySaveSuccessMessage += delegate(object sender, EventArgs eventArgs)
            {
                Console.WriteLine("Saved Successful");
            };
            anonymousMethodClass4.Save();

            Console.ReadLine();
        }
    }

}
