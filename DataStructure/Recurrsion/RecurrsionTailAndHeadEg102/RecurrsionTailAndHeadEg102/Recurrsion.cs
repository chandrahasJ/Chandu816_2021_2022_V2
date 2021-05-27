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
        /// <summary>
        /// Tail Recurrsion
        /// </summary>
        /// <param name="n"></param>
        public void calculateTailRecurrsion(int n)
        {
            if (n > 0)
            {
                int k = n * n;
                Console.WriteLine(k);
                calculateTailRecurrsion(n-1);
            }
        }


        /// <summary>
        /// Head Recurrsion
        /// </summary>
        /// <param name="n"></param>
        public void calculateHeadRecurrsion(int n)
        {
            if (n > 0)
            {
                calculateHeadRecurrsion(n - 1);
                int k = n * n;
                Console.WriteLine(k);
            }
        }
    }


}
