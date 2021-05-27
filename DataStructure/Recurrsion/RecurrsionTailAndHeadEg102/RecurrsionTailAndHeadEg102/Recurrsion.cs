using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionTailAndHeadEg102
{
    /// <summary>
    /// Types of Recurrsion 
    /// Head , Tail , In-Direct & Tree Recurrsion
    /// </summary>
    public class Recurrsion
    {
        public void calculate(int n)
        {
            if (n > 0)
            {
                int k = n * n;
                Console.WriteLine(k);
                calculate(n-1);
            }
        }
    }
}
