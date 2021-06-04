using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionFactorialEg104
{
    public class Factorial
    {
        public int factorialIterative(int n)
        {
            int fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        public int factorialRecurise(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return factorialRecurise(n - 1) * n;
        }
    }
}
