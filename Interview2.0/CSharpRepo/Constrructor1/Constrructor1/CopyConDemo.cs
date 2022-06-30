using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constrructor1
{
    public class CopyConDemo
    {
        int x;
        public CopyConDemo(int i)
        {
            x = i;
        }

        public CopyConDemo(CopyConDemo copyConDemo)
        {
            x = copyConDemo.x;
        }
        public void Display()
        {
            Console.WriteLine("Value of x :" + x);
        }
        public static void Main()
        {
            CopyConDemo copyConDemo = new CopyConDemo(10);
            copyConDemo.Display();
            CopyConDemo copyConDemo2 = new CopyConDemo(20);
            copyConDemo2.Display();

            CopyConDemo copyConDemo3 = new CopyConDemo(copyConDemo2);
            copyConDemo3.Display();

            Console.ReadLine();
        }
    }
}
