using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdvanceAsyncAwaitV2_TPL
{
    class Program2
    {
        static async void ReadValuesAsync()
        {
            Console.WriteLine($"ReadValuesAsync Thread Id " +
                    $": {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Start Reading the values from DB");
            await Task.Delay(20000);
            Console.WriteLine("Completed Reading the values from DB");
        }

        static void WriteValues()
        {
            Console.WriteLine($"WriteValues Thread Id " +
                        $": {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Enter your First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine($"Your Name is {firstName} {lastName}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread Id " +
                    $": {Thread.CurrentThread.ManagedThreadId}");
            ReadValuesAsync();
            WriteValues();
            Console.ReadLine();
        }


    }
}
