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
                int k = n * n;
                Console.WriteLine(k);
                n = n - 1;
            }
        }

        public static void recurrsionMethod(int n)
        {
            if (n > 0)
            {
                int k = n * n;
                Console.WriteLine(k);
                n = n - 1;
                recurrsionMethod(n);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Checking iteration method...");

            iteration(5);


            Console.WriteLine("Checking recurrsive method...");

            recurrsionMethod(5);
            Console.ReadLine();
        }
    }
}
