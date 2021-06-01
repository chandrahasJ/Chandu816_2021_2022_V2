using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionEg103
{
    public class Recurrsion
    {
        public int calculateSumOfNaturalNumberViaFormule(int n)
        {
            int part = n * n + n;
            return part / 2;
        }

        public int calculateSumofNatutalNumberViaRecurrsion(int n)
        {
            if (n == 1)
            {
                return n;
            }

            return calculateSumofNatutalNumberViaRecurrsion(n - 1) + n;
        }
    }
}
