using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessExamples_Demos
{
    class Program
    {
        private void Test1()
        {
            Console.WriteLine("Private Method");
        }

        internal void Test2()
        {
            Console.WriteLine("internal Method");
        }
        protected void Test3()
        {
            Console.WriteLine("protected Method");
        }

        protected internal void Test4()
        {
            Console.WriteLine("protected internal Method");
        }

        public void Test5()
        {
            Console.WriteLine("Public Method");
        }

        static void Main(string[] args)
        {
        }
    }
}
