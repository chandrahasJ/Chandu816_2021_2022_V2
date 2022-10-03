using System;
using System.Collections.Generic;
using System.Text;

namespace MethodOverriding
{
    class ParentClass
    {
        public virtual void Test1() { Console.WriteLine("Parent Test1"); }
        public void Test2() { Console.WriteLine("Parent Test2"); }
        public void Test3() { Console.WriteLine("Parent Test3"); }
    }

    class ChildClass : ParentClass
    {
        public override void Test1() { Console.WriteLine("Child Test1"); } //Overridden
        public new void Test2() { Console.WriteLine("Child Test2"); } // Method hidding 
        //it is execute with warning - use new keyword if hiding is intended.
        public void Test3() { Console.WriteLine("Parent Test3"); } 
        public void ParentTest1() { base.Test1(); } // Calling Base/Parent Class method
        public void ParentTest2() { base.Test2(); } // Calling Base/Parent Class method
        static void Main(string[] args)
        {
            ParentClass parentClass = new ParentClass();
            parentClass.Test1(); parentClass.Test2(); // Calling Parent Class method using instance of Parent Class
            ChildClass childClass = new ChildClass();
            //Calling Parent class method using Child class instance but by base keyword in the method.
            childClass.ParentTest1(); childClass.ParentTest2();
            childClass.Test1(); childClass.Test2(); // Calling child class methods which are overridden & shadowed.
            Console.WriteLine("--------------------------------------------------------------------------------");
            ChildClass childClass1 = new ChildClass(); //childClass1 is the instance ChildClass
            //parentClass1 is reference of parent class by using instance of child class
            ParentClass parentClass1 = childClass1;
            parentClass1.Test1(); // Overridden method of child class is called i.e. "Child Test1"
            parentClass1.Test2(); // Parent class method is called.

            Console.ReadLine();
        }
    }
}
