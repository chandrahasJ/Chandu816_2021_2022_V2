using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExamples
{
    public interface IInterface1 
    { 
        void Test(); void Show(); 
    }
    public interface IInterface2 
    {  
        void Test();  void Show();   
    }
    class MultipleInheritanceTest : IInterface1, IInterface2
    {
        //Explicity Implementation of abstract method of interface
        void IInterface1.Show() { Console.WriteLine("Declared in interface1 and implemented in class"); }
        void IInterface2.Show() { Console.WriteLine("Declared in interface2 and implemented in class"); }
        //Implicity Implementation of abstract method of interface 
        //Both IInterface1, IInterface2 will assume the Test method belongs to them.
        public void Test() { Console.WriteLine("Interfaces method implemented in child class"); }
        public static void Main(string[] args)
        {
            MultipleInheritanceTest multipleInheritanceTest = new MultipleInheritanceTest();
            multipleInheritanceTest.Test();
            //Error - Since show method is implemented using explicity implementation 
            // it can only be called via reference of IInterface1 or IInterface2
            //multipleInheritanceTest.Show(); 
            Console.WriteLine("------------------------------------");
            IInterface1 interface1 = multipleInheritanceTest; //interface1 is reference of IInterface1
            interface1.Test();       interface1.Show(); 
            Console.WriteLine("------------------------------------");
            IInterface2 interface2 = multipleInheritanceTest; //interface2 is reference of IInterface2
            interface2.Test();       interface2.Show();
            Console.ReadLine();
        }
    }
}
