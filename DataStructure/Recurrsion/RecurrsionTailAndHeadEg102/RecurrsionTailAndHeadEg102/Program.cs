using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionTailAndHeadEg102
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Recurrsion r = new Recurrsion();
            //r.calculateTailRecurrsion(4);
            Console.WriteLine("-------");
            r.calculateHeadRecurrsion(4);

            Console.ReadLine();
        }
    }
}
