using System;

namespace InterfaceExamples
{
    public abstract class AbstractParent
    {
        public abstract void showMsg(string msg);
        public virtual void TestMethod2() { Console.WriteLine("Test  Method2"); }
    }
    public interface ICalculator1{  void Add(int x, int y); }

    public interface ICalculator2 : ICalculator1  { void Sub(int x, int y);  }

    class ChildClass : AbstractParent, ICalculator2
    {
        public void Add(int x, int y) { Console.WriteLine( x + y ); } //Interface - Abstract Method implementation Mandatory
        public void Sub(int x, int y) { Console.WriteLine(x - y); }   //Interface - Abstract Method implementation Mandatory
        public override void showMsg(string msg) { Console.WriteLine(msg); } //Abstract class- Abstract Method implementation Mandatory
        public override void TestMethod2() { Console.WriteLine("Child TestMethod2"); } //Abstract class - Method re-implementation optional

        static void Main(string[] args)
        {
            ChildClass childClass = new ChildClass(); //Object/instance of Child class
            childClass.Add(100, 50); childClass.Sub(100, 75);
            childClass.TestMethod2(); childClass.showMsg("Abstract method implementation");
            Console.WriteLine("------------------------------------");
            ICalculator2 calculator2 = childClass; //Reference of interface created using child class instance
            calculator2.Add(200, 50); childClass.Sub(200, 75);
            //Error - because the below methods are not the members of interface. access denied.
            //calculator2.TestMethod2(); calculator2.showMsg("Abstract method implementation"); //Error 

            Console.ReadLine();
        }        
    }


}
