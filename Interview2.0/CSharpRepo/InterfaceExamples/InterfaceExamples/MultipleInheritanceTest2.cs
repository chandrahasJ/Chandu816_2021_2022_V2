using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExamples
{
    interface IInterface3 { void Test();  }
    interface IInterface4 { void Test(); }
    class MultipleInheritanceTest2 : IInterface3, IInterface4
    {
        //Implemented only once hence Ambiguity problem doesn't arise 
        public void Test() 
        {
            Console.WriteLine("Interfaces method implemented in child class");
        }
    }
}
