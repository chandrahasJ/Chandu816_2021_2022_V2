using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionEg103
{
    class Program
    {
        static void Main(string[] args)
        {
            SumOfNumbers r = new SumOfNumbers();


            Console.WriteLine(r.calculateSumOfNaturalNumberViaFormule(5));
            Console.WriteLine("-------------------------");
            Console.WriteLine(r.calculateSumofNatutalNumberViaRecurrsion(5));
            Console.WriteLine("-------------------------");
            Console.WriteLine(r.calculateSumofNaturalNumberViaIterative(5));

            Console.ReadLine();
        }
    }
}
