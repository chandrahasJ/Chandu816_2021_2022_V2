using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionFactorialEg104
{
    class Program
    {
        static void Main(string[] args)
        {
            Factorial f = new Factorial();
            
            Console.WriteLine(f.factorialRecurise(5));
            Console.WriteLine("---------------------------------");
            Console.WriteLine(f.factorialIterative(5));

            Console.ReadLine();
        }
    }
}
