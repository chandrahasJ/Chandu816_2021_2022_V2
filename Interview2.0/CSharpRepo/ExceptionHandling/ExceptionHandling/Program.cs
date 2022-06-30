using System;

namespace ExceptionHandling
{
    public class DivideByOddNumberException : ApplicationException
    {
        public override string Message => "Divisor cannot be odd number";
        public override string StackTrace => "E.g. of Odd number 1,3,5,7,10";
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the first number :> ");
                int x = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the second number :> ");
                int y = Int32.Parse(Console.ReadLine());
                if (y % 2 > 0) 
                    throw new DivideByOddNumberException();
                int z = x / y;
                Console.WriteLine($"Result is {z}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} \n {ex.StackTrace}");
            }
            finally { Console.WriteLine("Final block always executes"); }
            Console.WriteLine("End of Program- Abnormal Termination \n" +
                              "- This line will not be printed ");             
            Console.ReadLine();
        }
    }
}
