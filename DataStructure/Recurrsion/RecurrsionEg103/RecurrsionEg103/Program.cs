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
            Recurrsion r = new Recurrsion();


            Console.WriteLine(r.calculateSumOfNaturalNumberViaFormule(5));
            Console.WriteLine("-------------------------");
            Console.WriteLine(r.calculateSumofNatutalNumberViaRecurrsion(5));

            Console.ReadLine();
        }
    }
}
