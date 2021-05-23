using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionEg101
{
    class Program
    {
        public static void iteration(int n)
        {
            while (n > 0)
            {
                Console.WriteLine(n);
                n = n - 1;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Checking...");

            iteration(5);
            Console.ReadLine();
        }
    }
}
