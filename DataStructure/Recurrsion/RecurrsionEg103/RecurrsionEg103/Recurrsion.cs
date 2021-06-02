using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionEg103
{
    public class SumOfNumbers
    {
        public int calculateSumOfNaturalNumberViaFormule(int n)
        {
            return n * (n+1) / 2;
        }

        public int calculateSumofNaturalNumberViaIterative(int n)
        {
            int total = 0;
            int i = 1;
            while (i <= n)
            {
                total = total + i;
                i = i + 1;
            }
            return total;
        }

        public int calculateSumofNatutalNumberViaRecurrsion(int n)
        {
            if (n == 0)
            {
                return n;
            }

            return calculateSumofNatutalNumberViaRecurrsion(n - 1) + n;
        }
    }
}
