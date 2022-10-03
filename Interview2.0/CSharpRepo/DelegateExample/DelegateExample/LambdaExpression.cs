using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateExample
{
    public class LambdaExpression
    {
        private delegate int CalculateDelegate(int a, int b);
        public static void Main()
        {
            //Type 1 - you can specify parameter type while declaring Lambda 
            CalculateDelegate addDelegate = (int a, int b) => { return a + b; };
            //Type 2 - you can ignore parameter type while declaring Lambda 
            CalculateDelegate mulDelegate = (a, b) => { return a * b; };

            Console.WriteLine($"Add Delegate :> {addDelegate(10, 20)}");
            Console.WriteLine($"Multiple Delegate :> {mulDelegate(10, 20)}");
            Console.ReadLine();
        }
    }

    public class LambdaExpression2
    {
        public delegate void PrintNumberDelegate(int number);
        public event EventHandler MySaveSuccessMessage;
        public void IncrementAndPrintNumber(PrintNumberDelegate printNumberDelegate, int incrementalNumber)
        {
            incrementalNumber += 200;
            printNumberDelegate(incrementalNumber);
        }       
        public void Save()
        {
            // Saving Activity
            MySaveSuccessMessage(this, EventArgs.Empty);
        }
    }
    class LEProgram
    {
        public static void Main()
        {
            LambdaExpression2 lambdaExpression2 = new LambdaExpression2();
            //Anonymous method used by Event Handler
            lambdaExpression2.MySaveSuccessMessage += (sender, eventArgs) =>
            {
                Console.WriteLine("Saved Successful");
            };
            //Passing Anonymous method as method parameter 
            lambdaExpression2.IncrementAndPrintNumber(
                    (int number) => { 
                        Console.WriteLine($"Incremented number :> {number}");
                        lambdaExpression2.Save();
                    }, 100
                );                      
            Console.ReadLine();
        }
    }

}
